using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace Torneos_Futbol.Pages.Administracion
{
    public partial class RegistrarJugador : System.Web.UI.Page
    {
        TORNEOS_FUTBOLEntities base_futbol = new TORNEOS_FUTBOLEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlEquipo.DataValueField = "ID";
                ddlEquipo.DataTextField = "Nombre";
                ddlEquipo.DataSource = base_futbol.Equipo.ToList();
                ddlEquipo.DataBind();
            }
        }

        protected void btnCrearJugador_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                try
                {
                    Datos.Jugador j = new Datos.Jugador();

                    j.Nombre = txtNombre.Text;
                    j.Apellido = txtApellido.Text;
                    j.Edad = Convert.ToInt32(txtEdad.Text);
                    j.IdEquipo = Convert.ToInt32(ddlEquipo.SelectedValue);

                    base_futbol.Jugador.Add(j);
                    base_futbol.SaveChanges();

                    //lblJugCreado.Text = "Jugador registrado exitosamente";
                }
                catch (Exception ex)
                {
                    //lblJugCreado.Text = ex.Message;
                    //throw;
                }
            }
        }
    }
}