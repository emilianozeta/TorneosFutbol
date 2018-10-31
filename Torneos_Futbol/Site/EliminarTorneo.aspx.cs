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
        futbolEntities base_futbol = new futbolEntities();
        FuncionesComunes funCom    = new FuncionesComunes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTorneo();
            }
        }

        private void CargarTorneo()
        {
            var torn = base_futbol.torneo.ToList();
            ListItem item;

            ddlTorneo.Items.Insert(0, new ListItem("Seleccione un Torneo...", "0"));

            foreach (torneo t in torn)
            {
                item = new ListItem(t.nombre, funCom.IntToString(t.id));
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

                    var elitorneo = (from t in base_futbol.torneo
                                     where t.id == seltorneo
                                     select t).First();

                    //Levanto todos los equipos asociados al torneo, y les seteo torneo = NULL
                    var query = from eq in base_futbol.equipo
                                where eq.torneo_id == seltorneo
                                select eq;

                    foreach (var eq in query)
                        eq.torneo_id = null;

                    base_futbol.SaveChanges();

                    //Elimino el torneo seleccionado
                    base_futbol.torneo.Remove(elitorneo);
                    base_futbol.SaveChanges();

                    //CargarTorneo();

                    //lblTorEliminado.Text = "Se ha eliminado exitosamente el torneo: " + seltorneo2;
                }
            }
        }
    }
}