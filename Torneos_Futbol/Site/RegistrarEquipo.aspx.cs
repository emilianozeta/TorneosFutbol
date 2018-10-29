using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Torneos_Futbol.Negocio;

namespace Torneos_Futbol.Pages.Administracion
{
    public partial class RegistrarEquipo : System.Web.UI.Page
    {
        TORNEOS_FUTBOLEntities torneo = new TORNEOS_FUTBOLEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlTorneo.DataValueField = "id";
                ddlTorneo.DataTextField = "nombre";
                ddlTorneo.DataSource = torneo.torneo.ToList();

                ddlTorneo.DataBind();
                this.ddlTorneo.Items.Insert(0, new ListItem("Seleccione un Torneo...", "0"));  //Agrego opcion 0 porque no es obligatorio
            }
        }

        protected void btnCrearEquipo_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                try
                {
                    String nombre = txtNombre.Text;
                    int torneo = Convert.ToInt32(ddlTorneo.SelectedIndex); //SelectedValue
                    int monto = Convert.ToInt32(txtMonto.Text);
                   

                    ClassEquipo jug = new ClassEquipo();

                    jug.Insertar_Equipo(nombre, torneo, monto);

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