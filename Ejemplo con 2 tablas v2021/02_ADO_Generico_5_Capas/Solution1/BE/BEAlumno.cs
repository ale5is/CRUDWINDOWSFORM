using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEAlumno
    {
        #region "Propiedades"
        //propiedades de la clase Alumno
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public int DNI { get; set; }

        public DateTime FechaNac { get; set; }
        public int Edad { get; set; }

        public BELocalidad oBELocalidad { get; set; }


        #endregion

        #region "Metodos propios de la clase alumno"
        public int Calcular_Edad()
        {
            Edad = DateTime.Now.Year - FechaNac.Year;
            if (DateTime.Now.Month < FechaNac.Month)
                Edad -= 1;
            if (DateTime.Now.Month == FechaNac.Month && DateTime.Now.Day < FechaNac.Day)
                Edad -= 1;

            return Edad;
            #endregion
        }
    }
}
