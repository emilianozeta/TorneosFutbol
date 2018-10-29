using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Torneos_Futbol.Funciones_Comunes
{
    public class Casteos
    {
        public int StringToInt(String num)
        {
            int resCast1;
            Boolean resBool1;
            int result = 0;

            resBool1 = int.TryParse(num, out resCast1);

            if (resBool1)
                result = resCast1;

            return result;
        }

        public DateTime StringToDateTime(String fecha)
        {
            return DateTime.Parse(fecha);
        }
    }
}