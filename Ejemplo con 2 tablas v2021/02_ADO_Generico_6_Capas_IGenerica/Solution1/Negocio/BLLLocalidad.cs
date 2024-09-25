using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//uso la libreria de system.Data, para instanciar Datatable
using System.Data;
//referencia a la capa de BE y MPP
using BE;
using MPP;
using Abstraccion;

namespace Negocio
{
   public class BLLLocalidad: IGestor<BELocalidad>
    {

        public BLLLocalidad()
            //instancio el objeto mapper en el constructor de la clase localidad
        { oMPPLoc = new MPPLocalidad(); }

        MPPLocalidad oMPPLoc;
        public List<BELocalidad> ListarTodo()
        {
            return oMPPLoc.ListarTodo();
        }

        public bool Guardar(BELocalidad oBELocalidad)
        {
            return oMPPLoc.Guardar(oBELocalidad);
        }

        public bool Baja(BELocalidad oBELocalidad)
        {
            return oMPPLoc.Baja(oBELocalidad);
        }

        public BELocalidad ListarObjeto(BELocalidad Objeto)
        {
            throw new NotImplementedException();
        }

    }
}
