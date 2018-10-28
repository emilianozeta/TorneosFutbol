using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace Torneos_Futbol.Pages.Administracion
{
    public partial class ModificarJugador : System.Web.UI.Page
    {
        TORNEOS_FUTBOLEntities torneo = new TORNEOS_FUTBOLEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlJugador.DataValueField = "ID";
                ddlJugador.DataTextField = "Nombre";
                ddlJugador.DataSource = torneo.Jugador.ToList();
                ddlJugador.DataBind();
            }
        }
    }
}