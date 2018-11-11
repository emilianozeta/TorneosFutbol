using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Torneos_Futbol.Funciones_Comunes;

namespace Torneos_Futbol.WebUserControls
{
    public partial class ucProvLoc : System.Web.UI.UserControl
    {
        futbolEntities base_futbol = new futbolEntities();
        FuncionesComunes funCom = new FuncionesComunes();

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
            ddlProvincia.Items.Clear();

            var prov = base_futbol.provincia.ToList();

            ddlProvincia.Items.Insert(0, new ListItem("Seleccione una provincia...", "0"));

            foreach (provincia p in prov)
            {
                ListItem item = new ListItem(p.descripcion, funCom.IntToString(p.id));

                ddlProvincia.Items.Add(item);
            }

            ddlProvincia.SelectedIndex = 0;
        }

        internal void CargarLocalidadMod(localidad local)
        {
            ddlLocalidad.Items.Clear();

            int id_prov = funCom.StringToInt(ddlProvincia.SelectedValue);

            var loc = (from l in base_futbol.localidad where l.provincia_id == id_prov select l).ToList();

            //ddlLocalidad.Items.Insert(0, new ListItem("Seleccione una localidad...", "0"));

            foreach (localidad l in loc)
            {
                ListItem item = new ListItem(l.descripcion, funCom.IntToString(l.id));

                ddlLocalidad.Items.Add(item);

                if (l == local)
                    item.Selected = true;
            }
        }

        private void CargarLocalidad()
        {
            //ddlLocalidad.Items.Clear();

            //var loc = base_futbol.localidad.ToList();

            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione una localidad...", "0"));

            //foreach (localidad l in loc)
            //{
            //    ListItem item = new ListItem(l.descripcion, funCom.IntToString(l.id));

            //    ddlLocalidad.Items.Add(item);
            //}

            //ddlLocalidad.SelectedIndex = 0;
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLocalidad.Items.Clear();

            int id_prov = Convert.ToInt16(ddlProvincia.SelectedValue);

            var loc = (from l in base_futbol.localidad where l.provincia_id == id_prov select l).ToList();

            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione una localidad...", "0"));

            foreach (localidad l in loc)
            {
                ListItem item = new ListItem(l.descripcion, funCom.IntToString(l.id));

                ddlLocalidad.Items.Add(item);
            }
        }

        public DropDownList DdlProvincia
        {
            get { return ddlProvincia; }
            set { ddlProvincia = DdlProvincia; }
        }

        public DropDownList DdlLocalidad
        {
            get { return ddlLocalidad; }
            set { ddlLocalidad = DdlLocalidad; }
        }
    }
}