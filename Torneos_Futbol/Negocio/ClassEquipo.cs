using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;

namespace Torneos_Futbol.Negocio
{
    public class ClassEquipo
    {
        futbolEntities base_futbol = new futbolEntities();

        public void Insertar_Equipo(equipo eq)
        {
            try
            {
                base_futbol.equipo.Add(eq);
                base_futbol.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}