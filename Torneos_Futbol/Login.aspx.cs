using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Torneos_Futbol.Funciones_Comunes;
using Torneos_Futbol.Negocio;

namespace SiCoVe
{
    public partial class Login : System.Web.UI.Page
    {
        futbolEntities base_futbol = new futbolEntities();
        usuario        usu         = new usuario();
        ClassLogin     funLog      = new ClassLogin();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;

            if (!VerificarLogin())
            {
                lblMensaje.Visible = true;
            }
            else
            {
                lblMensaje.Visible = false;

                FormsAuthentication.SetAuthCookie(usu.id.ToString(), false);
                Session["Usuario"] = usu;

                Response.Redirect("~/Index", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        private bool VerificarLogin()
        {
            try
            {
                string usuario  = txtUsuario.Text;
                string password = txtPassword.Text;

                var user = funLog.Recuperar_Usuario(base_futbol, password, usuario);

                if (user != null)
                {
                    usu = user;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}