using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;

namespace Torneos_Futbol.Negocio
{
    public class ClassEquipo
    {
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