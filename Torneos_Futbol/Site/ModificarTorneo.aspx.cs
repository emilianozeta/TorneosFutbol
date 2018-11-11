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
        ClassTorneo      funTorn     = new ClassTorneo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                divModificar.Visible = false;
                CargarTorneo();
            }
            else
            {
                divBuscar.Visible = false;
                divModificar.Visible = true;
            }
        }

        private void CargarTorneo()
        {
            var torn = funTorn.Recuperar_Torneo_Completo(base_futbol);

            ddlTorneo.Items.Insert(0, new ListItem("Seleccione un Torneo...", "0"));

            foreach (torneo t in torn)
            {
                ListItem item = new ListItem(t.nombre, funCom.IntToString(t.id));
                ddlTorneo.Items.Add(item);
            }

            ddlTorneo.SelectedIndex = 0;
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            int seltorneo  = funCom.StringToInt(ddlTorneo.SelectedItem.Value);

            txtNombre.Text = ddlTorneo.SelectedItem.Text;

            torneo elitorneo = funTorn.Recuperar_Torneo_Busqueda(base_futbol, seltorneo);

            if (elitorneo.flag_activo == true)
                radBtnLstEstado.SelectedValue = "True";
            else
                radBtnLstEstado.SelectedValue = "False";

            ucProvLoc.DdlProvincia.SelectedIndex = elitorneo.provincia.id;
            ucProvLoc.CargarLocalidadMod(elitorneo.localidad);
        }

        protected void btnModificarTorneo_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                try
                {
                    int seltorneo = funCom.StringToInt(ddlTorneo.SelectedItem.Value);

                    torneo tor = funTorn.Recuperar_Torneo_Busqueda(base_futbol, seltorneo);

                    tor.nombre       = txtNombre.Text;
                    tor.provincia_id = funCom.StringToInt(ucProvLoc.DdlProvincia.SelectedValue);
                    tor.localidad_id = funCom.StringToInt(ucProvLoc.DdlLocalidad.SelectedValue);

                    if (radBtnLstEstado.SelectedValue == "True")
                        tor.flag_activo = true;
                    else
                        tor.flag_activo = false;

                    funTorn.Actualizar_Torneo(base_futbol);

                    divBuscar.Visible    = false;
                    divModificar.Visible = true;

                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Torneo modificado exitosamente');window.location.href = './ModificarTorneo.aspx';</script>");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}