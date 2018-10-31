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
        futbolEntities   base_futbol = new futbolEntities();
        FuncionesComunes funCom      = new FuncionesComunes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLista();
            } 
        }

        private void CargarLista()
        {
            var busqueda = (from eq in base_futbol.equipo
                            join t in base_futbol.torneo on eq.torneo_id equals t.id into equi
                            from equiLeft in equi.DefaultIfEmpty()
                            orderby eq.nombre
                            select new { Equipos = eq.nombre, Torneos = equiLeft.nombre, Estado = equiLeft.flag_activo ? "Activo" : "Inactivo" }
                            ).ToList();

            dgvListado.DataSource = busqueda;
            dgvListado.DataBind();
        }

        protected void btnBuscarB_Click(object sender, EventArgs e)
        {
            string torneoB = txtTorneoB.Text;
            string equipoB = txtEquipoB.Text;
            bool   activos = chkActivos.Checked;

            var busqueda = (dynamic)null;

            if (activos)
            {
                busqueda = (from eq in base_futbol.equipo
                            join t in base_futbol.torneo on eq.torneo_id equals t.id into equi
                            from equiLeft in equi.DefaultIfEmpty()
                            where(eq.nombre.Contains(equipoB) && (equiLeft.flag_activo.Equals(activos)) /*&& equiLeft.nombre.Contains(torneoB)*/)
                            orderby eq.nombre
                            select new { Equipos = eq.nombre, Torneos = equiLeft.nombre, Estado = equiLeft.flag_activo ? "Activo" : "Inactivo" }
                            ).ToList();
            }
            else
            {
                busqueda = (from eq in base_futbol.equipo
                            join t in base_futbol.torneo on eq.torneo_id equals t.id into equi
                            from equiLeft in equi.DefaultIfEmpty()
                            where (eq.nombre.Contains(equipoB) /*&& equiLeft.nombre.Contains(torneoB)*/)
                            orderby eq.nombre
                            select new { Equipos = eq.nombre, Torneos = equiLeft.nombre, Estado = equiLeft.flag_activo ? "Activo" : "Inactivo" }
                            ).ToList();
            }

            dgvListado.DataSource = busqueda;
            dgvListado.DataBind();
        }
    }
}