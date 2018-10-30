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
        futbolEntities torneo = new futbolEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlJugador.DataValueField = "ID";
                ddlJugador.DataTextField = "Nombre";
                ddlJugador.DataSource = torneo.jugador.ToList();
                ddlJugador.DataBind();
            }
        }
    }
}