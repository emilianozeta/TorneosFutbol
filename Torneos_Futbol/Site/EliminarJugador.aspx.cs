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
    public partial class EliminarJugador : System.Web.UI.Page
    {
        futbolEntities   base_futbol = new futbolEntities();
        FuncionesComunes funCom      = new FuncionesComunes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarJugador();
            }
        }

        private void CargarJugador()
        {
            var jug = base_futbol.jugador.ToList();
            ListItem item;

            ddlJugador.Items.Insert(0, new ListItem("Seleccione un jugador...", "0"));

            foreach (jugador j in jug)
            {
                item = new ListItem(funCom.ContenarString(j.nombre,j.apellido), funCom.IntToString(j.id));
                ddlJugador.Items.Add(item);
            }

            ddlJugador.SelectedIndex = 0;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                if (ddlJugador.SelectedItem.Value != "0")
                {
                    int seljugador = funCom.StringToInt(ddlJugador.SelectedItem.Value);

                    var elijugador = (from j in base_futbol.jugador
                                      where j.id == seljugador
                                      select j).First();

                    base_futbol.jugador.Remove(elijugador);
                    base_futbol.SaveChanges();

                    //CargarJugador();

                    //lblJugEliminado.Text = "Se ha eliminado exitosamente el jugador: " + seljugador2;
                }
            }
        }
    }
}