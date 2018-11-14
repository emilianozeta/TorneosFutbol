using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Torneos_Futbol.Negocio;
using Datos;
using Torneos_Futbol.Funciones_Comunes;

namespace Torneos_Futbol.Pages.Equipos
{
    public partial class ListarEquipos : System.Web.UI.Page
    {
        futbolEntities base_futbol = new futbolEntities();
        FuncionesComunes funCom = new FuncionesComunes();
        ClassListado funList = new ClassListado();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLista();
            }
        }

        private void CargarLista()
        {
            var busqueda = funList.Listar_Equipo(base_futbol);

            dgvListado.DataSource = busqueda;
            dgvListado.DataBind();
        }

        protected void btnBuscarB_Click(object sender, EventArgs e)
        {
            string equipoB = txtEquipoB.Text;
            bool activos = chkActivos.Checked;

            var busqueda = (dynamic)null;

            if (activos)
            {
                busqueda = funList.Listar_Equipo_Busqueda(base_futbol, equipoB, activos);
            }
            else
            {
                busqueda = funList.Listar_Equipo_Busqueda_Act(base_futbol, equipoB);
            }

            dgvListado.DataSource = busqueda;
            dgvListado.DataBind();
        }
    }
}