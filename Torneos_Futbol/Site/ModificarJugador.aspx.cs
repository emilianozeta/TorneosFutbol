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
    public partial class ModificarJugador : System.Web.UI.Page
    {
        futbolEntities   base_futbol = new futbolEntities();
        FuncionesComunes funCom      = new FuncionesComunes();
        ClassJugador     funJug      = new ClassJugador();
        ClassEquipo      funEqui     = new ClassEquipo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                divModificar.Visible = false;
                CargarJugador();
            }
            else
            {
                divBuscar.Visible = false;
                divModificar.Visible = true;
            }
        }

        private void CargarJugador()
        {
            var jug = funJug.Recuperar_Jugador_Completo(base_futbol);

            //ddlJugador.Items.Insert(0, new ListItem("Seleccione un Jugador...", "0"));

            foreach (jugador j in jug)
            {
                ListItem item = new ListItem(funCom.ContenarString(j.nombre,j.apellido), funCom.IntToString(j.id));
                ddlJugador.Items.Add(item);
            }

            ddlJugador.SelectedIndex = 0;
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            int selJugador  = funCom.StringToInt(ddlJugador.SelectedItem.Value);

            jugador elijugador = funJug.Recuperar_Jugador_Busqueda(base_futbol, selJugador);

            txtNombre.Text   = elijugador.nombre;
            txtApellido.Text = elijugador.apellido;

            var gener = funJug.Recuperar_Genero(base_futbol);

            foreach (genero ge in gener)
            {
                ListItem item = new ListItem(ge.descripcion, funCom.IntToString(ge.id));
                ddlSexo.Items.Add(item);

                if (funCom.IntToString(ge.id) == funCom.IntToString(elijugador.genero_id))
                    item.Selected = true;
            }

            txtEdad.Text = funCom.IntToString(elijugador.edad);

            ucProvLoc.DdlProvincia.SelectedIndex = elijugador.provincia.id;
            ucProvLoc.CargarLocalidadMod(elijugador.localidad);

            txtDireccion.Text = elijugador.domicilio;

            txtMail.Text = elijugador.email;

            var equi = funEqui.Recuperar_Equipo_Completo(base_futbol);

            foreach (equipo eq in equi)
            {
                ListItem item = new ListItem(eq.nombre, funCom.IntToString(eq.id));
                ddlEquipo.Items.Add(item);

                if (funCom.IntToString(eq.id) == elijugador.equipo_id.ToString())
                    item.Selected = true;
            }

            txtFecNacimiento.Text = elijugador.fecha_nac.ToString("dd/M/yyyy");
        }

        protected void btnModifJugador_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                try
                {
                    int selJugador = funCom.StringToInt(ddlJugador.SelectedItem.Value);

                    jugador jug      = (from ju in base_futbol.jugador where ju.id == selJugador select ju).FirstOrDefault();

                    jug.nombre       = txtNombre.Text;
                    jug.apellido     = txtApellido.Text;
                    jug.email        = txtMail.Text;
                    jug.fecha_nac    = funCom.StringToDateTime(txtFecNacimiento.Text);
                    jug.provincia_id = funCom.StringToInt(ucProvLoc.DdlProvincia.SelectedValue);
                    jug.localidad_id = funCom.StringToInt(ucProvLoc.DdlLocalidad.SelectedValue);
                    jug.domicilio    = txtDireccion.Text;
                    jug.genero_id    = funCom.StringToInt(ddlSexo.SelectedValue);
                    jug.equipo_id    = funCom.StringToInt(ddlEquipo.SelectedValue);
                    jug.edad         = funCom.StringToInt(txtEdad.Text);

                    funJug.Actualizar_Jugador(base_futbol);

                    divBuscar.Visible    = false;
                    divModificar.Visible = true;

                    this.Page.Response.Write("<script language='JavaScript'>window.alert('Jugador modificado exitosamente');window.location.href = './ModificarJugador.aspx';</script>");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}