using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class BELocalidad
    {
        #region "Propiedades"
        //propiedades de Localidad

        public int Codigo { get; set; }
        public string Localidad { get; set; }

        //en la BE aparte de las propiedades los metodos propio de la clase que no pertenecen al negocio
         public override string ToString()
        {
            return Codigo + " " + Localidad;
        }

        #endregion
    }
}
