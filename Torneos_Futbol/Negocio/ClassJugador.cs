using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;

namespace Torneos_Futbol.Negocio
{
    public class ClassJugador
    {
        TORNEOS_FUTBOLEntities base_futbol = new TORNEOS_FUTBOLEntities();

        public void Insertar_Jugador(string nombre, string apellido, string email, DateTime fecha_nac, int provincia, int localidad, string direccion, int sexo, int equipo, int edad)
        {
            try
            {
                jugador j = new jugador
                {
                    nombre = nombre,
                    apellido = apellido,
                    email = email,
                    fecha_nac = fecha_nac,
                    provincia_id = provincia,
                    localidad_id = localidad,
                    domicilio = direccion,
                    genero_id = sexo,
                    equipo_id = equipo,
                    edad = edad
                };

                base_futbol.jugador.Add(j);
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