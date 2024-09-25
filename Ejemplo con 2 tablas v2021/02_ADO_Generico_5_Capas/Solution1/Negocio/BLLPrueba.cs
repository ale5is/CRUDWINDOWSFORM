using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;

namespace Negocio
{
    public class BLLPrueba
    {
        public string TestCX()
        {
            //creo un objeto de la clase Acceso al Mapper
            MPPPrueba oMMPrueba = new MPPPrueba();
            return oMMPrueba.TestCX();

        }
    }
}
