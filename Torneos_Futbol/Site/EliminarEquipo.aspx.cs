using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Torneos_Futbol.Negocio;
using Datos;
using Torneos_Futbol.Funciones_Comunes;

namespace Torneos_Futbol.Pages.Administracion
{
    public partial class EliminarEquipo : System.Web.UI.Page
    {
        futbolEntities base_futbol = new futbolEntities();
        FuncionesComunes funCom    = new FuncionesComunes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEquipo();
            }
        }

        private void CargarEquipo()
        {
            var equi = base_futbol.equipo.ToList();

            ddlEquipo.Items.Insert(0, new ListItem("Seleccione un equipo...", "0"));

            foreach (equipo e in equi)
            {
                ListItem item = new ListItem(e.nombre, funCom.IntToString(e.id));
                ddlEquipo.Items.Add(item);
            }

            ddlEquipo.SelectedIndex = 0;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                if (ddlEquipo.SelectedItem.Value != "0")
                {
                    ClassEquipo  funEq = new ClassEquipo();
                    ClassJugador funJu = new ClassJugador();

                    int selequipo = funCom.StringToInt(ddlEquipo.SelectedItem.Value);

                    var eliequipo = (from eq in base_futbol.equipo
                                     where eq.id == selequipo
                                     select eq).First();

                    //Levanto todos los jugadores asociados al equipo, y los elimino
                    var query = from ju in base_futbol.jugador
                                where ju.equipo_id == selequipo
                                select ju;

                    foreach (var ju in query)
                    {
                        funJu.Eliminar_JugadorEquipo(base_futbol, ju);
                    }

                    funEq.Eliminar_Equipo(base_futbol, eliequipo);

                    //CargarEquipo();

                    //lblJugEliminado.Text = "Se ha eliminado exitosamente el jugador: " + seljugador2;
                }
            }
        }
    }
}