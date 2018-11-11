using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Datos;
using System.Collections.Generic;
using System.Linq;

namespace Torneos_Futbol.Negocio
{
    public class ClassLogin
    {
        public usuario Recuperar_Usuario(futbolEntities ctx, String user, String pass)
        {
            try
            {
                var usua = ( from u in ctx.usuario
                             where u.contraseña == pass && u.usuario1 == user
                             select u).FirstOrDefault();

                return usua;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
