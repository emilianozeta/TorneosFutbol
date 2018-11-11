using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;

namespace Torneos_Futbol.Negocio
{
    public class ClassEquipo
    {
        public List<equipo> Recuperar_Equipo_Completo(futbolEntities ctx)
        {
            try
            {
                return ctx.equipo.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public equipo Recuperar_Equipo_Busqueda(futbolEntities ctx, int selEquipo)
        {
            try
            {
                var eliEquipo = (from t in ctx.equipo
                                  where t.id == selEquipo
                                  select t).First();

                return eliEquipo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<jugador> Recuperar_Equipo_Jugador(futbolEntities ctx, int selEquipo)
        {
            try
            {
                var eliJugador = (from ju in ctx.jugador
                                  where ju.equipo_id == selEquipo
                                  select ju).ToList();

                return eliJugador;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public void Insertar_Equipo(futbolEntities ctx, equipo eq)
        {
            try
            {
                ctx.equipo.Add(eq);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Actualizar_Equipo(futbolEntities ctx)
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

        public void Eliminar_Equipo(futbolEntities ctx, equipo eq)
        {
            try
            {
                ctx.equipo.Remove(eq);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}