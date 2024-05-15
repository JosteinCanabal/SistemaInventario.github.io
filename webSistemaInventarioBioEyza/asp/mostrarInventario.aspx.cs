using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using webSistemaInventarioBioEyza.Clases;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace webSistemaInventarioBioEyza.Html
{
    public partial class mostrarInventario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticacionID();

            mostrarIventario();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Obtener el ID del registro a eliminar
            int recordId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            // Obtener el ID del usuario de la sesión
            string userId = Session["UserID"] as string;

            // Obtener el tipo de inventario seleccionado de la sesión
            string tipoInventarioSeleccionado = tipoInventario.SelectedValue;

            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(tipoInventarioSeleccionado))
            {
                // consulta SQL para eliminar el registro según el tipo de inventario
                string deleteQuery = string.Empty;

                if (tipoInventarioSeleccionado == "Bioeyza")
                {
                    deleteQuery = "DELETE FROM cajaInventario WHERE id_usuario = @UserID AND id = @RecordID";
                }
                else if (tipoInventarioSeleccionado == "Lote")
                {
                    deleteQuery = "DELETE FROM cajaLote WHERE id_usuario = @UserID AND id = @RecordID";
                }
                else
                {
                    Response.Write("Tipo de inventario seleccionado no reconocido.");
                    return;
                }

                // Obtener la cadena de conexión desde la clase ConectionHelper
                string connectionStringHosting = ConnectionHelper.GetHostingConnectionString();

                // Crear una conexión a la base de datos MySQL
                using (MySqlConnection connection = new MySqlConnection(connectionStringHosting))
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear un comando para ejecutar la consulta de eliminación
                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        // Agregar los parámetros para el ID del usuario y el ID del registro a eliminar
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.Parameters.AddWithValue("@RecordID", recordId); // Asegúrate de obtener el ID del registro a eliminar

                        // Ejecutar la consulta de eliminación
                        int rowsAffected = command.ExecuteNonQuery();

                        // Verificar si se eliminó algún registro
                        if (rowsAffected > 0)
                        {

                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "setTimeout(function(){ alert('Registro eliminado correctamente'); window.location.href = 'mostrarInventario.aspx'; }, 1500);", true);

                        }
                        else
                        {

                            Response.Write("No se encontró ningún registro para eliminar con el ID proporcionado.");
                        }
                    }
                }
            }
            else
            {

                Response.Redirect("mostrarInventario.aspx");
            }


            //actualizarTabla();
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

        protected void btnMostrarInventario_Click(object sender, EventArgs e)
        {
            mostrarIventario();
        }

        public void mostrarIventario()
        {
            // Obtener el tipo de inventario seleccionado en el DropDownList
            string tipoInventarioSeleccionado = tipoInventario.SelectedValue;

            // Obtener la cadena de conexión desde la clase ConectionHelper
            string connectionStringHosting = ConnectionHelper.GetHostingConnectionString();

            // Crear una conexión a la base de datos MySQL
            using (MySqlConnection connection = new MySqlConnection(connectionStringHosting))
            {
                // Abrir la conexión
                connection.Open();

                // Crear un comando para ejecutar el procedimiento almacenado
                using (MySqlCommand command = new MySqlCommand("mostrar_registros", connection))
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

        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            // Llamar a DataBind() para asegurarse de que GridView se haya vinculado correctamente a sus datos antes de exportarlo
            GridView1.DataBind();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=EjemploGrid.xls");
            Response.ContentType = "application/vnd.xls"; // Retorna en formato excel

            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);

            // Renderizar solo las primeras 6 columnas
            GridView1.Columns[8].Visible = false; // Ocultar la séptima columna y siguientes

            // Renderizar el GridView
            GridView1.RenderControl(htmlTextWriter);

            // Restaurar la visibilidad de todas las columnas para futuras representaciones
            GridView1.Columns[8].Visible = true;

            Response.Write(stringWriter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {

        }

        protected void txtBuscarCaja_TextChanged(object sender, EventArgs e)
        {
            string tipoInventarioItem = tipoInventario.SelectedValue;
            string nombreCajaItem = txtBuscarCaja.Text;

            BuscarCajaEspecifica(tipoInventarioItem, nombreCajaItem);
        }

        protected void BuscarCajaEspecifica(string tipoInventarioItem, string nombreCajaItem)
        {
            // Establece la conexión a la base de datos
            string connectionStringHosting = ConnectionHelper.GetHostingConnectionString();
            using (MySqlConnection connection = new MySqlConnection(connectionStringHosting))
            {
                // Abre la conexión
                connection.Open();

                // Crea un nuevo comando para ejecutar el procedimiento almacenado
                MySqlCommand command = new MySqlCommand("buscar_caja_especifica", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Agrega los parámetros al comando
                command.Parameters.AddWithValue("@p_tipoInventario", tipoInventarioItem);
                command.Parameters.AddWithValue("@p_nombre_caja", nombreCajaItem);

                // Ejecuta el comando y obtén los resultados
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Enlazo los resultados con al GridView
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                }
            }
        }

    }
}