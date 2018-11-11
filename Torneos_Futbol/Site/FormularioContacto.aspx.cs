using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Torneos_Futbol.Negocio;
using Datos;
using Torneos_Futbol.Funciones_Comunes;

namespace Torneos_Futbol.Pages.Equipos
{
    public partial class FormularioContacto : System.Web.UI.Page
    {
        futbolEntities   base_futbol = new futbolEntities();
        FuncionesComunes funCom      = new FuncionesComunes();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                try
                {
                    contacto co = new contacto();

                    co.nombre = txtNombre.Text;
                    co.email = txtMail.Text;
                    co.comentario = txtComentario.Text;

                    base_futbol.contacto.Add(co);
                    base_futbol.SaveChanges();

                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Nuestro personal se pondrá en contacto con usted a la mayor brevedad posible');window.location.href = './FormularioContacto.aspx';</script>");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}