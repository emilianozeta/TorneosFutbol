using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace Torneos_Futbol.Pages.Administracion
{
    public partial class RegistrarEquipo : System.Web.UI.Page
    {
        TORNEOS_FUTBOLEntities torneo = new TORNEOS_FUTBOLEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlTorneo.DataValueField = "ID";
                ddlTorneo.DataTextField = "Nombre";
                ddlTorneo.DataSource = torneo.Torneo.ToList();

                ddlTorneo.DataBind();
                this.ddlTorneo.Items.Insert(0, new ListItem("Seleccione un Torneo...", "0"));  //Agrego opcion 0 porque no es obligatorio
            }
        }
    }
}