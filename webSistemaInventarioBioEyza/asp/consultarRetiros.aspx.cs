using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webSistemaInventarioBioEyza.Clases;

namespace webSistemaInventarioBioEyza.asp
{
    public partial class consultarRetiros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticacionID();
        }

        public void mostrarSalidas() 
        {
            string tipoInventarioSeleccionado = tipoInventario.SelectedValue;
            string connectionStringHosting = ConnectionHelper.GetHostingConnectionString();

            // Crear una conexión a la base de datos MySQL
            using (MySqlConnection connection = new MySqlConnection(connectionStringHosting))
            {
                // Abrir la conexión
                connection.Open();

                // Crear un comando para ejecutar el procedimiento almacenado
                using (MySqlCommand command = new MySqlCommand("mostrar_registro_retiro_caja", connection))
                {
                    // Establecer el tipo de comando como procedimiento almacenado
                    command.CommandType = CommandType.StoredProcedure;

                    // Pasar el parámetro necesario al procedimiento almacenado (p_tipoInventario)
                    command.Parameters.AddWithValue("@p_tipoInventario", tipoInventarioSeleccionado);

                    // Crear un MySqlDataAdapter para obtener los resultados del procedimiento almacenado
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    // Crear un DataTable para almacenar los resultados
                    DataTable dataTable = new DataTable();

                    // Llenar el DataTable con los resultados del procedimiento almacenado
                    adapter.Fill(dataTable);

                    // Enlazar el DataTable al GridView
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }
            }
        }

        protected void btnMostrarSalidas_Click(object sender, EventArgs e)
        {
            mostrarSalidas();
        }

        protected void CerrarSesion()
        {
            // Elimina todas las variables de sesión
            Session.Clear();

            // Redirige al usuario a la página de inicio de sesión o a cualquier otra página que desees
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Usted ha cerrado sesión, ingrese nuevamente');", true);
            Response.Redirect("login.aspx");
        }

        protected void btnCerrarSesión_Click(object sender, EventArgs e)
        {
            // Llama al método para cerrar sesión
            CerrarSesion();
        }
                                                                
        public void autenticacionID()
        {
            if (!IsPostBack)
            {
                // Verifica si el usuario está autenticado
                if (Session["UserID"] == null)
                {
                    // Si el usuario no está autenticado, redirige a la página de inicio de sesión

                    Response.Redirect("login.aspx");
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "setTimeout(function(){ alert('Ha cerrado sesión, vuelva a loguarse'); window.location.href = 'Login.aspx'; }, 30);", true);
                }
                else
                {
                    // Si el usuario está autenticado, muestra el botón de cerrar sesión
                    btnCerrarSesion.Visible = true;
                }
            }

        }

        protected void btnFiltrarCodigoFactura_Click(object sender, EventArgs e)
        {

            try
            {
                // Obtener el código de factura ingresado por el usuario
                string codigoFactura = txtCodigoFactura.Text;
               

                // Validar que el código de factura no esté vacío
                if (string.IsNullOrEmpty(codigoFactura))
                {
                    // Manejar el caso en que el código de factura esté vacío
                    return;
                }
                else
                {
                    // Obtener la cadena de conexión desde el archivo Web.config
                    string connectionStringHosting = ConnectionHelper.GetHostingConnectionString();

                    // Crear una conexión a la base de datos MySQL
                    using (MySqlConnection connection = new MySqlConnection(connectionStringHosting))
                    {
                        // Abrir la conexión
                        connection.Open();

                        // Crear un comando para ejecutar el procedimiento almacenado
                        using (MySqlCommand command = new MySqlCommand("mostrar_registro_codigo", connection))
                        {
                            // Establecer el tipo de comando como procedimiento almacenado
                            command.CommandType = CommandType.StoredProcedure;

                            // Agregar el parámetro de código de factura al comando
                            command.Parameters.AddWithValue("@p_codigo", codigoFactura);

                            // Crear un MySqlDataAdapter para obtener los resultados del procedimiento almacenado
                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                            {
                                // Crear un DataTable para almacenar los resultados
                                DataTable dataTable = new DataTable();

                                // Llenar el DataTable con los resultados del procedimiento almacenado
                                adapter.Fill(dataTable);

                                // Enlazar el DataTable al GridView
                                GridView2.DataSource = dataTable;
                                GridView2.DataBind();
                            }
                        }
                    }

                    // Limpiar el valor del campo de texto después de la consulta
                    txtCodigoFactura.Text = "";
                    }
            }catch (Exception ex){
                // Manejar la excepción, mostrar un mensaje de error al usuario

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Ha ocurrido un error al procesar su solicitud: {ex.Message}');", true);

            }
        }

        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=EjemploGrid.xls");
            Response.ContentType = "application/vnd.xls";

            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);

            // Renderiza directamente el GridView
            GridView1.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string tipoInventarioItem = tipoInventario.SelectedValue;
            string nombreCajaItem = txtBuscarCaja.Text;

            BuscarCajaEspecifica(tipoInventarioItem, nombreCajaItem);
            
        }

        protected void BuscarCajaEspecifica(string tipoInventarioItem, string nombreCajaItem)
        {
            // Este metodo busca cajas por nombre o etiqueta
            // Establece la conexión a la base de datos
            string connectionStringHosting = ConnectionHelper.GetHostingConnectionString();
            using (MySqlConnection connection = new MySqlConnection(connectionStringHosting))
            {
                // Abre la conexión
                connection.Open();

                // Crea un nuevo comando para ejecutar el procedimiento almacenado
                MySqlCommand command = new MySqlCommand("buscar_caja_retirada", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Agrega los parámetros al comando
                command.Parameters.AddWithValue("@p_tipoInventario", tipoInventarioItem);
                command.Parameters.AddWithValue("@p_caja_retirada", nombreCajaItem);

                // Ejecuta el comando y obtén los resultados
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Enlaza los resultados al GridView
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                }
            }
        }


        protected void btnBuscar2_Click(object sender, EventArgs e)
        {
            string tipoInventarioItem = tipoInventario.SelectedValue;
            string nombreCajaItem = txtBuscarCaja2.Text;

            BuscarCajaEspecifica2(tipoInventarioItem, nombreCajaItem);

        }
        protected void BuscarCajaEspecifica2(string tipoInventarioItem2, string nombreCajaItem2)
        {
            // Este metodo busca cajas por codigo de factura
            string connectionStringHosting = ConnectionHelper.GetHostingConnectionString();
            using (MySqlConnection connection = new MySqlConnection(connectionStringHosting))
            {
                // Abre la conexión
                connection.Open();

                // Crea un nuevo comando para ejecutar el procedimiento almacenado
                MySqlCommand command = new MySqlCommand("buscar_codigo_factura", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Agrega los parámetros al comando
                command.Parameters.AddWithValue("@p_tipoInventario", tipoInventarioItem2);
                command.Parameters.AddWithValue("@p_codigo", nombreCajaItem2);

                // Ejecuta el comando y obtén los resultados
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Enlaza los resultados al GridView
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                }
            }
        }

        protected void btnFiltrarFecha_Click(object sender, EventArgs e)
        {
            string tipoInventarioItem3 = tipoInventario.SelectedValue;
            DateTime fechaInicioo, fechaFinaal;
            if (!DateTime.TryParseExact(txtFechaInicio.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaInicioo) ||
                !DateTime.TryParseExact(txtFechaFinal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaFinaal))
            {
                // Mostrar mensaje de error si el formato de la fecha es incorrecto
                Response.Write("Formato de fecha incorrecto. Por favor, ingrese las fechas en formato dd/MM/yyyy.");
                return;
            }
            
                DateTime fechaInicio = DateTime.ParseExact(txtFechaInicio.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime fechaFinal = DateTime.ParseExact(txtFechaFinal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                BuscarRangoFecha(tipoInventarioItem3, fechaInicio, fechaFinal);
                
        }

        protected void BuscarRangoFecha(string tipoInventarioItem3, DateTime fechaInicio, DateTime fechaFinal) 
        {

            // Este metodo busca cajas por rango de fecha
            string connectionStringHosting = ConnectionHelper.GetHostingConnectionString();
            using (MySqlConnection connection = new MySqlConnection(connectionStringHosting))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("rango_de_fechas", connection);
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.AddWithValue("@p_tipoInventario", tipoInventarioItem3);
                command.Parameters.AddWithValue("@p_fecha_inicio", fechaInicio);
                command.Parameters.AddWithValue("@p_fecha_final", fechaFinal);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Enlaza los resultados al GridView
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                }

            }


        }
    }
}