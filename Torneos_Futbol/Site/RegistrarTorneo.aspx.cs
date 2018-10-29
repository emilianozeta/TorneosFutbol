using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace Torneos_Futbol.Pages.Administracion
{
    public partial class RegistrarTorneo : System.Web.UI.Page
    {
        TORNEOS_FUTBOLEntities torneo = new TORNEOS_FUTBOLEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            ddlProvincia.DataValueField = "id";
            ddlProvincia.DataValueField = "descripcion";
            ddlProvincia.DataSource = torneo.provincia.ToList();
            ddlProvincia.DataBind();
            //--------------------------------------------//
            ddlLocalidad.DataValueField = "id";
            ddlLocalidad.DataValueField = "descripcion";
            ddlLocalidad.DataSource = torneo.localidad.ToList();
            ddlLocalidad.DataBind();
        }

        protected void btnCrearTorneo_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                Page.Validate();

                if (Page.IsValid)
                {
                    try
                    {
                        torneo t = new torneo();

                        t.nombre = txtNombre.Text;

                        if (radBtnLstEstado.SelectedValue == "True")
                        {
                            t.flag_activo = true;
                        }
                        else if (radBtnLstEstado.SelectedValue == "False")
                        {
                            t.flag_activo = false;
                        }
                        else
                        {
                            throw new Exception("Error desconocido");
                        }

                        t.provincia_id = Convert.ToInt32(ddlProvincia.SelectedIndex); //SelectedValue
                        t.localidad_id = Convert.ToInt32(ddlLocalidad.SelectedIndex);

                        torneo.torneo.Add(t);
                        torneo.SaveChanges();

                        //lblTorCreado.Text = "Torneo registrado exitosamente";
                    }
                    catch (Exception ex)
                    {
                        //lblTorCreado.Text = ex.Message;
                        //throw;
                    }
                }
            }
        }
    }
}