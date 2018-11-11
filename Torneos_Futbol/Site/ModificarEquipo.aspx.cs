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
    public partial class ModificarEquipo : System.Web.UI.Page
    {
        futbolEntities   base_futbol = new futbolEntities();
        FuncionesComunes funCom      = new FuncionesComunes();
        ClassEquipo      funEquip    = new ClassEquipo();
        ClassTorneo      funTonr     = new ClassTorneo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divModificar.Visible = false;
                CargarEquipo();
            }
            else
            {
                divBuscar.Visible = false;
                divModificar.Visible = true;
            }
        }

        private void CargarEquipo()
        {
            var equi = funEquip.Recuperar_Equipo_Completo(base_futbol);

            ddlEquipo.Items.Insert(0, new ListItem("Seleccione un equipo...", "0"));

            foreach (equipo e in equi)
            {
                ListItem item = new ListItem(e.nombre, funCom.IntToString(e.id));
                ddlEquipo.Items.Add(item);
            }

            ddlEquipo.SelectedIndex = 0;
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            int selequipo  = funCom.StringToInt(ddlEquipo.SelectedItem.Value);

            equipo eliequipo = funEquip.Recuperar_Equipo_Busqueda(base_futbol, selequipo);

            txtNombre.Text = eliequipo.nombre;
            txtMonto.Text  = eliequipo.montoabonado.ToString();

            var tor = funTonr.Recuperar_Torneo_Completo(base_futbol);

            foreach (torneo to in tor)
            {
                ListItem item = new ListItem(to.nombre, funCom.IntToString(to.id));
                ddlTorneo.Items.Add(item);

                if (funCom.IntToString(to.id) == eliequipo.torneo_id.ToString())
                    item.Selected = true;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                try
                {
                    int selequipo = funCom.StringToInt(ddlEquipo.SelectedItem.Value);

                    equipo equi       = (from eq in base_futbol.equipo where eq.id == selequipo select eq).FirstOrDefault();

                    equi.nombre       = txtNombre.Text;
                    equi.montoabonado = funCom.StringToInt(txtMonto.Text);
                    equi.torneo_id    = funCom.StringToInt(ddlTorneo.SelectedValue);

                    funEquip.Actualizar_Equipo(base_futbol);

                    divBuscar.Visible    = false;
                    divModificar.Visible = true;

                    //lblEquModificado.Text = "Equipo modificado exitosamente";*/
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}