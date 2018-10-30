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
    public partial class RegistrarJugador : System.Web.UI.Page
    {
        futbolEntities base_futbol = new futbolEntities();
        Casteos        cast        = new Casteos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEquipo();
                CargarGenero();
                CargarProvincia();
                CargarLocalidad();
            }
        }

        private void CargarEquipo()
        {
            var      equi = base_futbol.equipo.ToList();
            ListItem item;

            ddlEquipo.Items.Insert(0, new ListItem("Seleccione un equipo...", "0"));

            foreach (equipo e in equi)
            {
                item = new ListItem(e.nombre, cast.IntToString(e.id));
                ddlEquipo.Items.Add(item);
            }

            ddlEquipo.SelectedIndex = 0;
        }

        private void CargarGenero()
        {
            var      gen = base_futbol.genero.ToList();
            ListItem item;

            ddlSexo.Items.Insert(0, new ListItem("Seleccione un genero...", "0"));

            foreach (genero g in gen)
            {
                item = new ListItem(g.descripcion, cast.IntToString(g.id));
                ddlSexo.Items.Add(item);
            }

            ddlSexo.SelectedIndex = 0;
        }

        private void CargarProvincia()
        {
            var      prov = base_futbol.provincia.ToList();
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
            var      loc = base_futbol.localidad.ToList();
            ListItem item;

            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione una localidad...", "0"));

            foreach (localidad l in loc)
            {
                item = new ListItem(l.descripcion, cast.IntToString(l.id));
                ddlLocalidad.Items.Add(item);
            }

            ddlLocalidad.SelectedIndex = 0;
        }

        protected void btnCrearJugador_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                try
                {
                    jugador      ju     = new jugador();
                    ClassJugador funJug = new ClassJugador();

                    ju.nombre       = txtNombre.Text;
                    ju.apellido     = txtApellido.Text;
                    ju.email        = txtMail.Text;
                    ju.fecha_nac    = cast.StringToDateTime(txtFecNacimiento.Text);
                    ju.provincia_id = cast.StringToInt(ddlProvincia.SelectedValue);
                    ju.localidad_id = cast.StringToInt(ddlLocalidad.SelectedValue);
                    ju.domicilio    = txtDireccion.Text;
                    ju.genero_id    = cast.StringToInt(ddlSexo.SelectedValue);
                    ju.equipo_id    = cast.StringToInt(ddlEquipo.SelectedValue);
                    ju.edad         = cast.StringToInt(txtEdad.Text);

                    funJug.Insertar_Jugador(ju);

                    //lblJugCreado.Text = "Jugador registrado exitosamente";
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}