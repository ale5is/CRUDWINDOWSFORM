using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class BELocalidad: Entidad
    {
        #region "Propiedades"
        //propiedades de Localidad

      
        public string Localidad { get; set; }

        //en la BE aparte de las propiedades los metodos propio de la clase que no pertenecen al negocio
         public override string ToString()
        {
            return Codigo + " " + Localidad;
        }

        #endregion
    }
}
