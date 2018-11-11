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
    public partial class RegistrarTorneo : System.Web.UI.Page
    {
        futbolEntities   base_futbol = new futbolEntities();
        FuncionesComunes funCom      = new FuncionesComunes();
        ClassTorneo      funTorn     = new ClassTorneo();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrearTorneo_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                try
                {
                    torneo tor = new torneo();

                    tor.nombre = txtNombre.Text;

                    if (radBtnLstEstado.SelectedValue == "True")
                    {
                        tor.flag_activo = true;
                    }
                    else if (radBtnLstEstado.SelectedValue == "False")
                    {
                        tor.flag_activo = false;
                    }

                    tor.provincia_id = funCom.StringToInt(ucProvLoc.DdlProvincia.SelectedValue);
                    tor.localidad_id = funCom.StringToInt(ucProvLoc.DdlLocalidad.SelectedValue);

                    funTorn.Insertar_Torneo(base_futbol, tor);

                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Torneo registrado exitosamente');window.location.href = './RegistrarTorneo.aspx';</script>");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}