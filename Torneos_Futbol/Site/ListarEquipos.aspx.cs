using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

namespace Torneos_Futbol.Pages.Equipos
{
    public partial class ListarEquipos : System.Web.UI.Page
    {
        futbolEntities torneo = new futbolEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscarB_Click(object sender, EventArgs e)
        {
            string torneoB = txtTorneoB.Text;
            string equipoB = txtEquipoB.Text;
            bool activos   = chkActivos.Checked;

            var busqueda = (from eq in torneo.equipo
                            join t in torneo.torneo on
                            eq.torneo_id equals t.id
                            where eq.nombre.Contains(equipoB) || t.nombre.Contains(torneoB) && t.flag_activo.Equals(activos)
                            select new { EQUIPO_NOMBRE = eq.nombre, TORNEO_NOMBRE = t.nombre }
                            ).ToList();

            dgvListado.DataSource = busqueda;
            dgvListado.DataBind();
        }
    }
}