using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;

namespace Torneos_Futbol.Negocio
{
    public class ClassTorneo
    {
        futbolEntities base_futbol = new futbolEntities();

        public void Insertar_Torneo(torneo to)
        {
            try
            {
                base_futbol.torneo.Add(to);
                base_futbol.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}