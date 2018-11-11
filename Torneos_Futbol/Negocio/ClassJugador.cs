using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;

namespace Torneos_Futbol.Negocio
{
    public class ClassJugador
    {
        public List<jugador> Recuperar_Jugador_Completo(futbolEntities ctx)
        {
            try
            {
                return ctx.jugador.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public jugador Recuperar_Jugador_Busqueda(futbolEntities ctx, int selJugador)
        {
            try
            {
                var eliJugador = (from t in ctx.jugador
                                 where t.id == selJugador
                                 select t).First();

                return eliJugador;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<genero> Recuperar_Genero(futbolEntities ctx)
        {
            try
            {
                return ctx.genero.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Insertar_Jugador(futbolEntities ctx, jugador ju)
        {
            try
            {
                ctx.jugador.Add(ju);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Actualizar_Jugador(futbolEntities ctx)
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

        public void Eliminar_JugadorEquipo(futbolEntities ctx, jugador ju)
        {
            try
            {
                ctx.jugador.Remove(ju);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar_Jugador(futbolEntities ctx, jugador ju)
        {
            try
            {
                ctx.jugador.Remove(ju);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}