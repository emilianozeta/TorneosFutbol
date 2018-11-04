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

        protected void Page_Load(object sender, EventArgs e)
        {
            divModificar.Visible = false;

            if (!Page.IsPostBack)
            {
                CargarJugador();
            }
        }

        private void CargarJugador()
        {
            var jug = base_futbol.jugador.ToList();

            ddlJugador.Items.Insert(0, new ListItem("Seleccione un Jugador...", "0"));

            foreach (jugador j in jug)
            {
                ListItem item = new ListItem(funCom.ContenarString(j.nombre,j.apellido), funCom.IntToString(j.id));
                ddlJugador.Items.Add(item);
            }

            ddlJugador.SelectedIndex = 0;
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            int seljugador  = funCom.StringToInt(ddlJugador.SelectedItem.Value);
            var seljugador2 = ddlJugador.SelectedItem.Text;

            divBuscar.Visible    = false;
            divModificar.Visible = true;

            var elijugador = (from j in base_futbol.jugador
                              where j.id == seljugador
                              select j).First();

            txtNombre.Text   = elijugador.nombre;
            txtApellido.Text = elijugador.apellido;

            var gener= base_futbol.genero.ToList();

            foreach (genero ge in gener)
            {
                ListItem item = new ListItem(ge.descripcion, funCom.IntToString(ge.id));
                ddlSexo.Items.Add(item);

                if (funCom.IntToString(ge.id) == elijugador.genero_id.ToString())
                    item.Selected = true;
            }

            txtEdad.Text = elijugador.edad.ToString();

            CargarProvincia(elijugador.provincia, elijugador.localidad);

            txtDireccion.Text = elijugador.domicilio.ToString();

            txtMail.Text = elijugador.email.ToString();

            var equi = base_futbol.equipo.ToList();

            foreach (equipo eq in equi)
            {
                ListItem item = new ListItem(eq.nombre, funCom.IntToString(eq.id));
                ddlEquipo.Items.Add(item);

                if (funCom.IntToString(eq.id) == elijugador.equipo_id.ToString())
                    item.Selected = true;
            }

            txtFecNacimiento.Text = elijugador.fecha_nac.ToString("dd/M/yyyy");
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selJugador = funCom.StringToInt(ddlJugador.SelectedItem.Value);

            divBuscar.Visible    = false;
            divModificar.Visible = true;

            var eliJugador = (from t in base_futbol.jugador
                             where t.id == selJugador
                             select t).First();

            CargarLocalidad(eliJugador.localidad);
        }

        private void CargarProvincia(provincia provi, localidad loc)
        {
            ddlProvincia.Items.Clear();

            var prov = base_futbol.provincia.ToList();

            ddlProvincia.Items.Insert(0, new ListItem("Seleccione una provincia...", "0"));

            foreach (provincia p in prov)
            {
                ListItem item = new ListItem(p.descripcion, funCom.IntToString(p.id));

                ddlProvincia.Items.Add(item);

                if (p == provi)
                    item.Selected = true;
            }

            //ddlProvincia.SelectedIndex = 0;

            CargarLocalidad(loc);
        }

        private void CargarLocalidad(localidad local)
        {
            ddlLocalidad.Items.Clear();

            int id_prov = Convert.ToInt16(ddlProvincia.SelectedValue);

            var loc = (from l in base_futbol.localidad where l.provincia_id == id_prov select l).ToList();

            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione una localidad...", "0"));

            foreach (localidad l in loc)
            {
                ListItem item = new ListItem(l.descripcion, funCom.IntToString(l.id));

                ddlLocalidad.Items.Add(item);

                if (l == local)
                    item.Selected = true;
            }
        }

        protected void btnModifJugador_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                try
                {
                    int selJugador = funCom.StringToInt(ddlJugador.SelectedItem.Value);

                    ClassJugador funJug = new ClassJugador();
                    jugador      jug    = (from ju in base_futbol.jugador where ju.id == selJugador select ju).FirstOrDefault();

                    jug.nombre       = txtNombre.Text;
                    jug.apellido     = txtApellido.Text;
                    jug.email        = txtMail.Text;
                    jug.fecha_nac    = funCom.StringToDateTime(txtFecNacimiento.Text);
                    jug.provincia_id = funCom.StringToInt(ddlProvincia.SelectedValue);
                    jug.localidad_id = funCom.StringToInt(ddlLocalidad.SelectedValue);
                    jug.domicilio    = txtDireccion.Text;
                    jug.genero_id    = funCom.StringToInt(ddlSexo.SelectedValue);
                    jug.equipo_id    = funCom.StringToInt(ddlEquipo.SelectedValue);
                    jug.edad         = funCom.StringToInt(txtEdad.Text);

                    funJug.Actualizar_Jugador(base_futbol);

                    //base_futbol.SaveChanges();

                    divBuscar.Visible = false;
                    divModificar.Visible = true;

                    //lblTorModificado.Text = "Torneo modificado exitosamente";
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}