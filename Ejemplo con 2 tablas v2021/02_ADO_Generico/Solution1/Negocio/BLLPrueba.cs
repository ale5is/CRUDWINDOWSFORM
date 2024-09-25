using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BLLPrueba
    {
        public string TestCX()
        {
            //creo un objeto de la clase Acceso de la Dal
            Acceso oDatos = new Acceso();
            return oDatos.TestConnection();

        }
    }
}
