using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;

namespace Torneos_Futbol.Negocio
{
    public class ClassTorneo
    {
        public List<torneo> Recuperar_Torneo_Completo(futbolEntities ctx)
        {
            try
            {
                return ctx.torneo.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public torneo Recuperar_Torneo_Busqueda(futbolEntities ctx, int seltorneo)
        {
            try
            {
                var elitorneo = (from t in ctx.torneo
                                 where t.id == seltorneo
                                 select t).First();

                return elitorneo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<equipo> Recuperar_Torneo_Equipo(futbolEntities ctx, int seltorneo)
        {
            try
            {
                var selEquipo = (from eq in ctx.equipo
                                where eq.torneo_id == seltorneo
                                select eq).ToList();

                return selEquipo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public void Insertar_Torneo(futbolEntities ctx, torneo to)
        {
            try
            {
                ctx.torneo.Add(to);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Actualizar_Torneo(futbolEntities ctx)
        {
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar_Torneo(futbolEntities ctx, torneo to)
        {
            try
            {
                ctx.torneo.Remove(to);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}