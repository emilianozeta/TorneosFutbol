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
        futbolEntities   base_futbol = new futbolEntities();
        FuncionesComunes funCom      = new FuncionesComunes();
        ClassEquipo      funEqui     = new ClassEquipo();
        ClassJugador     funJug      = new ClassJugador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarEquipo();
                CargarGenero();
            }
        }

        private void CargarEquipo()
        {
            var equi = funEqui.Recuperar_Equipo_Completo(base_futbol);

            ddlEquipo.Items.Insert(0, new ListItem("Seleccione un equipo...", "0"));

            foreach (equipo e in equi)
            {
                ListItem item = new ListItem(e.nombre, funCom.IntToString(e.id));
                ddlEquipo.Items.Add(item);
            }

            ddlEquipo.SelectedIndex = 0;
        }

        private void CargarGenero()
        {
            var gen = funJug.Recuperar_Genero(base_futbol);

            ddlSexo.Items.Insert(0, new ListItem("Seleccione un genero...", "0"));

            foreach (genero g in gen)
            {
                ListItem item = new ListItem(g.descripcion, funCom.IntToString(g.id));
                ddlSexo.Items.Add(item);
            }

            ddlSexo.SelectedIndex = 0;
        }

        protected void btnCrearJugador_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                try
                {
                    jugador ju      = new jugador();
                   
                    ju.nombre       = txtNombre.Text;
                    ju.apellido     = txtApellido.Text;
                    ju.email        = txtMail.Text;
                    ju.fecha_nac    = funCom.StringToDateTime(txtFecNacimiento.Text);
                    ju.provincia_id = funCom.StringToInt(ucProvLoc.DdlProvincia.SelectedValue);
                    ju.localidad_id = funCom.StringToInt(ucProvLoc.DdlLocalidad.SelectedValue);
                    ju.domicilio    = txtDireccion.Text;
                    ju.genero_id    = funCom.StringToInt(ddlSexo.SelectedValue);
                    ju.equipo_id    = funCom.StringToInt(ddlEquipo.SelectedValue);
                    ju.edad         = funCom.StringToInt(txtEdad.Text);

                    funJug.Insertar_Jugador(base_futbol, ju);

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