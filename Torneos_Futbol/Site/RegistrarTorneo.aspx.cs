using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Torneos_Futbol.Funciones_Comunes;
using Torneos_Futbol.Negocio;

namespace Torneos_Futbol.Pages.Administracion
{
    public partial class RegistrarTorneo : System.Web.UI.Page
    {
        futbolEntities base_futbol = new futbolEntities();
        Casteos        cast        = new Casteos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarProvincia();
                CargarLocalidad();
            }
        }

        private void CargarProvincia()
        {
            var prov = base_futbol.provincia.ToList();
            ListItem item;

            ddlProvincia.Items.Insert(0, new ListItem("Seleccione una provincia...", "0"));

            foreach (provincia p in prov)
            {
                item = new ListItem(p.descripcion, cast.IntToString(p.id));
                ddlProvincia.Items.Add(item);
            }

            ddlProvincia.SelectedIndex = 0;
        }

        private void CargarLocalidad()
        {
            var loc = base_futbol.localidad.ToList();
            ListItem item;

            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione una localidad...", "0"));

            foreach (localidad l in loc)
            {
                item = new ListItem(l.descripcion, cast.IntToString(l.id));
                ddlLocalidad.Items.Add(item);
            }

            ddlLocalidad.SelectedIndex = 0;
        }

        protected void btnCrearTorneo_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                try
                {
                    torneo      to    = new torneo();
                    ClassTorneo funTo = new ClassTorneo();

                    to.nombre = txtNombre.Text;

                    if (radBtnLstEstado.SelectedValue == "True")
                    {
                        to.flag_activo = true;
                    }
                    else if (radBtnLstEstado.SelectedValue == "False")
                    {
                        to.flag_activo = false;
                    }

                    to.provincia_id = cast.StringToInt(ddlProvincia.SelectedValue);
                    to.localidad_id = cast.StringToInt(ddlLocalidad.SelectedValue);

                    funTo.Insertar_Torneo(to);

                    //lblTorCreado.Text = "Torneo registrado exitosamente";
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}