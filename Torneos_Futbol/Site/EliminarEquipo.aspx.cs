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
        futbolEntities   base_futbol = new futbolEntities();
        FuncionesComunes funCom      = new FuncionesComunes();
        ClassEquipo      funEqui     = new ClassEquipo();
        ClassJugador     funJug      = new ClassJugador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEquipo();
            }
        }

        private void CargarEquipo()
        {
            ddlEquipo.Items.Clear();

            var equi = funEqui.Recuperar_Equipo_Completo(base_futbol);

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
                    int selequipo = funCom.StringToInt(ddlEquipo.SelectedItem.Value);

                    equipo eliequipo = funEqui.Recuperar_Equipo_Busqueda(base_futbol, selequipo);

                    //Levanto todos los jugadores asociados al equipo, y los elimino
                    var selJugador = funEqui.Recuperar_Equipo_Jugador(base_futbol, selequipo);

                    foreach (var ju in selJugador)
                    {
                        funJug.Eliminar_JugadorEquipo(base_futbol, ju);
                    }

                    funEqui.Eliminar_Equipo(base_futbol, eliequipo);

                    CargarEquipo();

                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Se ha eliminado exitosamente el equipo');window.location.href = './EliminarEquipo.aspx';</script>");
                }
            }
        }
    }
}