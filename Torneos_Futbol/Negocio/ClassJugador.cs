﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Datos;

namespace Torneos_Futbol.Negocio
{
    public class ClassJugador
    {
        futbolEntities base_futbol = new futbolEntities();

        public void Insertar_Jugador(jugador ju)
        {
            try
            {
                base_futbol.jugador.Add(ju);
                base_futbol.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}