using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencia a la capa de BE y MPP
using BE;
using MPP;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Negocio
{
   public class BLLLocalidad
    {

        public BLLLocalidad()
            //instancio el objeto mapper en el constructor de la clase localidad
        { oMPPLoc = new MPPLocalidad(); }

        MPPLocalidad oMPPLoc;
        public List<BELocalidad> CargarListaLocalidades()
        {
            return oMPPLoc.CargarListaLocalidades();
        }

        public bool Guardar(BELocalidad oBELocalidad)
        {
            return oMPPLoc.Guardar(oBELocalidad);
        }

        public bool Baja(BELocalidad oBELocalidad)
        {
            return oMPPLoc.Baja(oBELocalidad);
        }
    }
}
