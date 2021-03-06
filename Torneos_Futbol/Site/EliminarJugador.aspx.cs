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
    public partial class EliminarJugador : System.Web.UI.Page
    {
        futbolEntities   base_futbol = new futbolEntities();
        FuncionesComunes funCom      = new FuncionesComunes();
        ClassJugador     funJug      = new ClassJugador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarJugador();
            }
        }

        private void CargarJugador()
        {
            ddlJugador.Items.Clear();

            var jug = funJug.Recuperar_Jugador_Completo(base_futbol);

            ddlJugador.Items.Insert(0, new ListItem("Seleccione un jugador...", "0"));

            foreach (jugador j in jug)
            {
                ListItem item = new ListItem(funCom.ContenarString(j.nombre,j.apellido), funCom.IntToString(j.id));
                ddlJugador.Items.Add(item);
            }

            ddlJugador.SelectedIndex = 0;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                if (ddlJugador.SelectedItem.Value != "0")
                {
                    int seljugador = funCom.StringToInt(ddlJugador.SelectedItem.Value);

                    jugador elijugador = funJug.Recuperar_Jugador_Busqueda(base_futbol, seljugador);

                    funJug.Eliminar_Jugador(base_futbol, elijugador);

                    CargarJugador();

                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Se ha eliminado exitosamente el jugador');window.location.href = './EliminarJugador.aspx';</script>");
                }
            }
        }
    }
}