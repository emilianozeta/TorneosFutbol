using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Torneos_Futbol.Entidades
{
    public class Jugador
    {
        private string nombre; //{ get; set; }
        private String apellido; 
        private String email;
        private DateTime fecha_nac;
        private int provincia_id;
        private int localidad_id;
        private String domicilio;
        private int genero_id;
        private int equipo_id;
        private int edad;


        public Jugador(string nombre, string apellido, string email, DateTime fecha_nac, int provincia_id, int localidad_id, string domicilio, int genero_id, int equipo_id, int edad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.fecha_nac = fecha_nac;
            this.provincia_id = provincia_id;
            this.localidad_id = localidad_id;
            this.domicilio = domicilio;
            this.genero_id = genero_id;
            this.equipo_id = equipo_id;
            this.edad = edad;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            var jugador = obj as Jugador;
            return jugador != null &&
                   nombre == jugador.nombre &&
                   apellido == jugador.apellido &&
                   email == jugador.email &&
                   fecha_nac == jugador.fecha_nac &&
                   provincia_id == jugador.provincia_id &&
                   localidad_id == jugador.localidad_id &&
                   domicilio == jugador.domicilio &&
                   genero_id == jugador.genero_id &&
                   equipo_id == jugador.equipo_id &&
                   edad == jugador.edad;
        }

        public override int GetHashCode()
        {
            var hashCode = 146797297;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(apellido);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(email);
            hashCode = hashCode * -1521134295 + fecha_nac.GetHashCode();
            hashCode = hashCode * -1521134295 + provincia_id.GetHashCode();
            hashCode = hashCode * -1521134295 + localidad_id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(domicilio);
            hashCode = hashCode * -1521134295 + genero_id.GetHashCode();
            hashCode = hashCode * -1521134295 + equipo_id.GetHashCode();
            hashCode = hashCode * -1521134295 + edad.GetHashCode();
            return hashCode;
        }
    }
}