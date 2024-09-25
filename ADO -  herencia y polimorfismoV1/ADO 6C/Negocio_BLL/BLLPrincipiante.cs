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
   public class BLLPrincipiante: BLLJugador,IGestor<BEPrincipiante>
    {
        public BLLPrincipiante()
        {
            oMPPJPrin = new MPPPrincipiante();
        }

        MPPPrincipiante oMPPJPrin;
      public override int ObtenerPuntaje(BEJugador oBEJug)
        {
            int puntaje = 0;
            puntaje = 10 * oBEJug.GolesRealizados - 2 * oBEJug.CantidadRojas - 2 * oBEJug.CantidadAmarillas;
            return puntaje;
        }

        public bool Guardar_JugadorXEquipo(BEPrincipiante oBEPrin, BEEquipo oBEEqui)
        {    
             return oMPPJPrin.Guardar_JugadorXEquipo(oBEEqui, oBEPrin);
          
        }
        public List<BEPrincipiante> ListarTodo()
        {
            throw new NotImplementedException();
        }


        public bool Guardar(BEPrincipiante oBEPrin)
        {
            return oMPPJPrin.Guardar(oBEPrin);
        }

        public bool Baja(BEPrincipiante Objeto)
        {
            throw new NotImplementedException();
        }

        public BEPrincipiante ListarObjeto(BEPrincipiante oBEPrin)
        {
            return oMPPJPrin.ListarObjeto(oBEPrin);
        }
    }
}
