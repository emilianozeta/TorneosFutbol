using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Datos;
using System.Collections.Generic;
using System.Linq;

namespace Torneos_Futbol.Negocio
{
    public class ClassListado
    {
        public List<EquipoTorneo> Listar_Equipo(futbolEntities ctx)
        {
            try
            {
                return (    from eq in ctx.equipo
                            join t in ctx.torneo on eq.torneo_id equals t.id into equi
                            from equiLeft in equi.DefaultIfEmpty()
                            orderby eq.nombre
                            select new EquipoTorneo
                            {
                                Equipos = eq.nombre,
                                Torneos = equiLeft.nombre,
                                Estado = equiLeft.flag_activo ? "Activo" : "Inactivo"
                            }
                        ).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EquipoTorneo> Listar_Equipo_Busqueda(futbolEntities ctx, string torneoB, string equipoB, bool activos)
        {
            try
            {
                return (from eq in ctx.equipo
                        join t in ctx.torneo on eq.torneo_id equals t.id into equi
                        from equiLeft in equi.DefaultIfEmpty()
                        where (eq.nombre.Contains(equipoB) && (equiLeft.flag_activo.Equals(activos)) /*&& equiLeft.nombre.Contains(torneoB)*/)
                        orderby eq.nombre
                        select new EquipoTorneo
                        {
                            Equipos = eq.nombre,
                            Torneos = equiLeft.nombre,
                            Estado = equiLeft.flag_activo ? "Activo" : "Inactivo"
                        }
                        ).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EquipoTorneo> Listar_Equipo_Busqueda_Act(futbolEntities ctx, string torneoB, string equipoB)
        {
            try
            {
                return (from eq in ctx.equipo
                        join t in ctx.torneo on eq.torneo_id equals t.id into equi
                        from equiLeft in equi.DefaultIfEmpty()
                        where (eq.nombre.Contains(equipoB) /*&& equiLeft.nombre.Contains(torneoB)*/)
                        orderby eq.nombre
                        select new EquipoTorneo
                        {
                            Equipos = eq.nombre,
                            Torneos = equiLeft.nombre,
                            Estado = equiLeft.flag_activo ? "Activo" : "Inactivo"
                        }
                        ).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public class EquipoTorneo
        {
            public string Equipos { get; set; }
            public string Torneos { get; set; }
            public string Estado { get; set; }
        }
    }
}
