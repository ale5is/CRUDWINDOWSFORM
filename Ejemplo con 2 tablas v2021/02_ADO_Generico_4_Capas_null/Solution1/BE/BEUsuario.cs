using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
  public  class BEUsuario:BEPersona
    {
        #region "Propiedades de Usuario"
        

        public string Usuario { get; set; }

        public string Psw { get; set; }

        #endregion
    }
}
