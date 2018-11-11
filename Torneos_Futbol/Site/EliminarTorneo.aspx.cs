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
    public partial class EliminarTorneo : System.Web.UI.Page
    {
        futbolEntities   base_futbol = new futbolEntities();
        FuncionesComunes funCom      = new FuncionesComunes();
        ClassEquipo      funEqui     = new ClassEquipo();
        ClassTorneo      funTorn     = new ClassTorneo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTorneo();
            }
        }

        private void CargarTorneo()
        {
            ddlTorneo.Items.Clear();

            var torn = funTorn.Recuperar_Torneo_Completo(base_futbol);

            ddlTorneo.Items.Insert(0, new ListItem("Seleccione un Torneo...", "0"));

            foreach (torneo t in torn)
            {
                ListItem item = new ListItem(t.nombre, funCom.IntToString(t.id));
                ddlTorneo.Items.Add(item);
            }

            ddlTorneo.SelectedIndex = 0;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                if (ddlTorneo.SelectedItem.Value != "0")
                {
                    int seltorneo = funCom.StringToInt(ddlTorneo.SelectedItem.Value);

                    torneo elitorneo = funTorn.Recuperar_Torneo_Busqueda(base_futbol, seltorneo);

                    //Levanto todos los equipos asociados al torneo, y les seteo torneo = NULL
                    var selEquipo = funTorn.Recuperar_Torneo_Equipo(base_futbol, seltorneo);

                    foreach (var eq in selEquipo)
                        eq.torneo_id = null;

                    funEqui.Actualizar_Equipo(base_futbol);

                    //Elimino el torneo seleccionado
                    funTorn.Eliminar_Torneo(base_futbol, elitorneo);

                    CargarTorneo();

                    //lblTorEliminado.Text = "Se ha eliminado exitosamente el torneo: " + seltorneo2;
                }
            }
        }
    }
}