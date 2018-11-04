using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Torneos_Futbol.Funciones_Comunes;

namespace Torneos_Futbol
{
    public partial class ucTorneo : System.Web.UI.UserControl
    {
        futbolEntities   base_futbol = new futbolEntities();
        FuncionesComunes funCom      = new FuncionesComunes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarProvincia();
                ddlLocalidad.Items.Insert(0, new ListItem("Seleccione una localidad...", "0"));
            }
        }

        private void CargarProvincia()
        {
            var prov = base_futbol.provincia.ToList();

            ddlProvincia.Items.Insert(0, new ListItem("Seleccione una provincia...", "0"));

            foreach (provincia p in prov)
            {
                ListItem item = new ListItem(p.descripcion, funCom.IntToString(p.id));
                ddlProvincia.Items.Add(item);
            }

            ddlProvincia.SelectedIndex = 0;
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selProv = funCom.StringToInt(ddlProvincia.SelectedItem.Value);

            var selecLoc = (from l in base_futbol.localidad
                            where l.provincia_id == selProv
                            select l).First();
            
            CargarLocalidad(selProv);
        }

        private void CargarLocalidad(int prov)
        {
            var loc = (from l in base_futbol.localidad
                       where l.provincia_id == prov
                       select l).ToList();

            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione una localidad...", "0"));

            foreach (localidad l in loc)
            {
                ListItem item = new ListItem(l.descripcion, funCom.IntToString(l.id));
                ddlLocalidad.Items.Add(item);
            }

            ddlLocalidad.SelectedIndex = 0;
        }

        public TextBox TxtNombre
        {
            get { return txtNombre; }
            set { txtNombre = TxtNombre; }
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

        public RadioButtonList RadBtnLstEstado
        {
            get { return radBtnLstEstado; }
            set { radBtnLstEstado = RadBtnLstEstado; }
        }
    }
}