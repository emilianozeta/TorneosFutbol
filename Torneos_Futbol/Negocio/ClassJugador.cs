using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;

namespace Torneos_Futbol.Negocio
{
    public class ClassJugador
    {
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