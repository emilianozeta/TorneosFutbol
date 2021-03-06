﻿using System;
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
    public partial class RegistrarEquipo : System.Web.UI.Page
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
            var torn = funTorn.Recuperar_Torneo_Completo(base_futbol);

            ddlTorneo.Items.Insert(0, new ListItem("Seleccione un Torneo...", "0"));

            foreach (torneo t in torn)
            {
                ListItem item = new ListItem(t.nombre, funCom.IntToString(t.id));
                ddlTorneo.Items.Add(item);
            }

            ddlTorneo.SelectedIndex = 0;
        }

        protected void btnCrearEquipo_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                try
                {
                    equipo eq       = new equipo();

                    eq.nombre       = txtNombre.Text;
                    eq.montoabonado = funCom.StringToInt(txtMonto.Text);

                    if (funCom.StringToInt(ddlTorneo.SelectedValue) == 0)
                        eq.torneo_id = null;
                    else
                        eq.torneo_id    = funCom.StringToInt(ddlTorneo.SelectedValue);

                    funEqui.Insertar_Equipo(base_futbol, eq);

                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Equipo registrado exitosamente');window.location.href = './RegistrarEquipo.aspx';</script>");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}