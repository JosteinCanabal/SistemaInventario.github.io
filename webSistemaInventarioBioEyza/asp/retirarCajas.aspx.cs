using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webSistemaInventarioBioEyza.Clases;

namespace webSistemaInventarioBioEyza.Html
{
    public partial class retirarCajas : System.Web.UI.Page
    {
        int cantidadUnidadRetirada, codigoFacturaValidacion;
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticacionID();
        }

        protected void btnRetirarCajas(object sender, EventArgs e)
        {
            string userId = Session["UserID"] as string;

            if (string.IsNullOrEmpty(txtNombreCaja.Text) ||
                string.IsNullOrEmpty(txtCantidadRetirar.Text) ||
                string.IsNullOrEmpty(txtCodigoFactura.Text) ||
                string.IsNullOrEmpty(txtDestinatario.Text) ||
                string.IsNullOrEmpty(txtEtiquetaCaja.Text))

            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Algun campo esta vacío');", true);
                return; // Salir del método si hay campos vacíos
            }
            if (!int.TryParse(txtCantidadRetirar.Text, out cantidadUnidadRetirada) || !int.TryParse(txtCodigoFactura.Text, out codigoFacturaValidacion))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Campo de Codigo de Factura O cantidad a Retirar solo permite números enteros');", true);
            }
            DateTime fechaRetiroo;
            if (!DateTime.TryParseExact(txtFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaRetiroo))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('La fecha no es válida');", true);
                return; // Salir del método si la fecha no es válida
            }
            string nombreCaja = txtNombreCaja.Text;
            string destinatario = txtDestinatario.Text;
            string comentario = txtComentario.Text;
            string etiquetaCaja = txtEtiquetaCaja.Text;
            DateTime fechaRetiro = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string tipoInventarioSeleccionado = tipoInventario.SelectedValue;

            // Llamar al procedimiento almacenado
            string connectionStringHosting = ConnectionHelper.GetHostingConnectionString();
            using (MySqlConnection connection = new MySqlConnection(connectionStringHosting))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("retirar_caja", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Pasar los parámetros al procedimiento almacenado
                command.Parameters.AddWithValue("@p_nombre", nombreCaja);
                command.Parameters.AddWithValue("@p_tipoInventario", tipoInventarioSeleccionado);
                command.Parameters.AddWithValue("@p_cantidadRetirarUnidades", cantidadUnidadRetirada);
                command.Parameters.AddWithValue("@p_destinatario", destinatario);
                command.Parameters.AddWithValue("@p_codigoFactura", codigoFacturaValidacion);
                command.Parameters.AddWithValue("@p_etiquetaCaja", etiquetaCaja);
                command.Parameters.AddWithValue("@p_comentario", comentario);
                command.Parameters.AddWithValue("@p_fecha_salida", fechaRetiro);
                command.Parameters.AddWithValue("@p_id_usuario", userId);

                // Parámetro de salida para el mensaje
                command.Parameters.Add("@p_message", MySqlDbType.VarChar, 100);
                command.Parameters["@p_message"].Direction = ParameterDirection.Output;

                // Ejecutar el comando
                command.ExecuteNonQuery();

                // Obtener el mensaje de salida
                string message = command.Parameters["@p_message"].Value.ToString();

                // Mostrar el mensaje al usuario
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('.{message}');", true);

                txtNombreCaja.Text = "";
                txtCantidadRetirar.Text = "";
                txtDestinatario.Text = "";
                txtCodigoFactura.Text = "";
                txtFecha.Text = "";
                txtEtiquetaCaja.Text = "";
                txtComentario.Text = "";

                connection.Close();
            }
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

    }
}