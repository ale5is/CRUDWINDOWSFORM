using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Abstraccion;
using MPP;

namespace Negocio_BLL
{

    public class BLLTecnico : IGestor<BETecnico>
    {
        public BLLTecnico()
        {
            oMPPTec = new MPPTecnico();
        }

       MPPTecnico oMPPTec;

        public List<BETecnico> ListarTodo()
        {
            return oMPPTec.ListarTodo();
        }

        public bool Baja(BETecnico Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BETecnico oBETec)
        {
            return oMPPTec.Guardar(oBETec);
        }

        public BETecnico ListarObjeto(BETecnico Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
