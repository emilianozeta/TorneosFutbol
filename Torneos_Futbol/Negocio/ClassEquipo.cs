using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;

namespace Torneos_Futbol.Negocio
{
    public class ClassEquipo
    {
        TORNEOS_FUTBOLEntities base_futbol = new TORNEOS_FUTBOLEntities();

        public void Insertar_Equipo(string nombre, int monto, int torneo)
        {
            try
            {
                equipo t = new equipo()
                {
                    nombre = nombre,
                    montoabonado = monto,
                    torneo_id = torneo
                };

                base_futbol.equipo.Add(t);
                base_futbol.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //lblJugCreado.Text = ex.Message;
                //throw;
            }
        }
    }
}