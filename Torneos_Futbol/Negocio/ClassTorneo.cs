using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;

namespace Torneos_Futbol.Negocio
{
    public class ClassTorneo
    {
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