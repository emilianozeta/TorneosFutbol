using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Torneos_Futbol.Entidades;
using Torneos_Futbol.Negocio;
using Datos;
using Torneos_Futbol.Funciones_Comunes;

namespace Torneos_Futbol.Pages.Administracion
{
    public partial class RegistrarJugador : System.Web.UI.Page
    {
        TORNEOS_FUTBOLEntities torneo = new TORNEOS_FUTBOLEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlEquipo.DataValueField = "id";
                ddlEquipo.DataTextField = "nombre";
                ddlEquipo.DataSource = torneo.equipo.ToList();
                ddlEquipo.DataBind();
                //--------------------------------------------//
                ddlSexo.DataValueField = "id";
                ddlSexo.DataValueField = "descripcion";
                ddlSexo.DataSource = torneo.genero.ToList();
                ddlSexo.DataBind();
                //--------------------------------------------//
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
        }

        protected void btnCrearJugador_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                try
                {
                    Casteos cast = new Casteos();

                    String nombre      = txtNombre.Text;
                    String apellido    = txtApellido.Text;
                    String email       = txtMail.Text;
                    DateTime fecha_nac = cast.StringToDateTime(txtFecNacimiento.Text);
                    int provincia      = ddlProvincia.SelectedIndex;
                    int localidad      = ddlLocalidad.SelectedIndex;
                    String direccion   = txtDireccion.Text;
                    int sexo           = ddlSexo.SelectedIndex;
                    int equipo         = ddlEquipo.SelectedIndex;
                    int edad           = cast.StringToInt(txtEdad.Text);

                    ClassJugador jug = new ClassJugador();

                    jug.Insertar_Jugador(nombre, apellido, email, fecha_nac, provincia, localidad, direccion, sexo, equipo, edad);

                    //lblJugCreado.Text = "Jugador registrado exitosamente";
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    //lblJugCreado.Text = ex.Message;
                    //throw;
                }
            }
        }
    }
}