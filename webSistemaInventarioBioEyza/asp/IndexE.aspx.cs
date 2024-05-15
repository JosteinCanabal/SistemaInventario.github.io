using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webSistemaInventarioBioEyza.asp
{
    public partial class IndexE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticacionID();


            if (!IsPostBack)
            {
                autenticacionID(); // Asumo que esta función maneja la autenticación y almacena el ID del usuario en Session["UserID"]
                string userId = Session["UserID"] as string;

                if (userId == "1")
                {
                    RegistrarEmpleadosLink.Enabled = true;

                }
                else
                {
                    // El usuario no es administrador, deshabilitar la opción para registrar empleados
                    RegistrarEmpleadosLink.Enabled = false;
                }
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

        protected void RegistrarEmpleadosLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}