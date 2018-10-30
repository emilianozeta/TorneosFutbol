using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace Torneos_Futbol.Pages.Administracion
{
    public partial class ModificarTorneo : System.Web.UI.Page
    {
        futbolEntities torneo = new futbolEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlTorneo.DataValueField = "ID";
                ddlTorneo.DataTextField = "Nombre";
                ddlTorneo.DataSource = torneo.torneo.ToList();
                ddlTorneo.DataBind();
            }
        }
    }
}