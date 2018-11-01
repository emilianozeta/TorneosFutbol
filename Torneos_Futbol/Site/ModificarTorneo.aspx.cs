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
    public partial class ModificarTorneo : System.Web.UI.Page
    {
        futbolEntities   base_futbol = new futbolEntities();
        FuncionesComunes funCom      = new FuncionesComunes();

        protected void Page_Load(object sender, EventArgs e)
        {
            divModificar.Visible = false;

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

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            int seltorneo  = funCom.StringToInt(ddlTorneo.SelectedItem.Value);
            var seltorneo2 = ddlTorneo.SelectedItem.Text;

            divBuscar.Visible = false;
            divModificar.Visible = true;

            var elitorneo = (from t in base_futbol.torneo
                             where t.id == seltorneo
                             select t).First();

            txtNombre.Text = seltorneo2;

            if (elitorneo.flag_activo == true)
            {
                radBtnLstEstado.SelectedValue = "True";
            }
            else
            {
                radBtnLstEstado.SelectedValue = "False";
            }


            CargarProvincia(elitorneo.provincia, elitorneo.localidad);
         


        }

        private void CargarProvincia(provincia provi, localidad lo)
        {
            ddlProvincia.Items.Clear();
            var prov = base_futbol.provincia.ToList();
            ListItem item;

            ddlProvincia.Items.Insert(0, new ListItem("Seleccione una provincia...", "0"));

            foreach (provincia p in prov)
            {
                item = new ListItem(p.descripcion, funCom.IntToString(p.id));
                ddlProvincia.Items.Add(item);
                if (p == provi)
                    item.Selected = true;
            }
            CargarLocalidad(lo);
            //ddlProvincia.SelectedIndex = 0;
        }

        private void CargarLocalidad(localidad local)
        {
            ddlLocalidad.Items.Clear();
            int id_prov = Convert.ToInt16(ddlProvincia.SelectedValue);

            var loc = (from l in base_futbol.localidad where l.provincia_id == id_prov select l).ToList();
            ListItem item;

            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione una localidad...", "0"));

            foreach (localidad l in loc)
            {
                item = new ListItem(l.descripcion, funCom.IntToString(l.id));
                ddlLocalidad.Items.Add(item);
                if (l == local)
                    item.Selected = true;
            }

            //ddlLocalidad.SelectedIndex = 0;
        }

        protected void btnModificarTorneo_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                try
                {
                    int seltorneo = funCom.StringToInt(ddlTorneo.SelectedItem.Value);

                    torneo tor;
                    tor = (from to in base_futbol.torneo where to.id == seltorneo select to).FirstOrDefault();

                    tor.nombre = txtNombre.Text;
                    tor.provincia_id = Convert.ToInt32(ddlProvincia.SelectedValue);
                    tor.localidad_id = Convert.ToInt32(ddlLocalidad.SelectedValue);
                    if (radBtnLstEstado.SelectedValue == "True")
                        tor.flag_activo = true;
                    else
                        tor.flag_activo = false;



                    //var a = Convert.ToBoolean(radBtnLstEstado.SelectedValue);

                    //var query = from to in base_futbol.torneo
                    //            where to.id == seltorneo
                    //            select to;

                    //foreach (var to in query)
                    //    to.nombre = txtNombre.Text;

                    //foreach (var to in query)
                    //    to.flag_activo = a;

                    base_futbol.SaveChanges();

                    divBuscar.Visible    = false;
                    divModificar.Visible = true;

                    //lblTorModificado.Text = "Torneo modificado exitosamente";
                }
                catch (Exception ex)
                {
                    //lblTorModificado.Text = ex.Message;
                    throw;
                }
            }
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seltorneo = funCom.StringToInt(ddlTorneo.SelectedItem.Value);
            var seltorneo2 = ddlTorneo.SelectedItem.Text;

            divBuscar.Visible = false;
            divModificar.Visible = true;

            var elitorneo = (from t in base_futbol.torneo
                             where t.id == seltorneo
                             select t).First();
            CargarLocalidad(elitorneo.localidad);

        }
    }
}