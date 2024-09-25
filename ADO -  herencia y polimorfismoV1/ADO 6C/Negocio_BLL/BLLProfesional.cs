using BE;
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
   public class BLLProfesional: BLLJugador, IGestor<BEProfesional>
    {
        public BLLProfesional()
        {
            oMPPJProf = new MPPProfesional();
        }

        MPPProfesional oMPPJProf;
        public override int ObtenerPuntaje(BEJugador oBEJug)
        {
            int puntaje = 0;
            puntaje = 20 * oBEJug.GolesRealizados - 4 * oBEJug.CantidadRojas - 2 * oBEJug.CantidadAmarillas;
            return puntaje;
        }

        public bool Guardar_JugadorXEquipo(BEProfesional oBEProf, BEEquipo oBEEqui)
        {
            return oMPPJProf.Guardar_JugadorXEquipo(oBEEqui, oBEProf);

        }

        public bool Guardar(BEProfesional oBEProf)
        {
            return oMPPJProf.Guardar(oBEProf);
        }

        public bool Baja(BEProfesional Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEProfesional> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public BEProfesional ListarObjeto(BEProfesional oBEProf)
        {
            return oMPPJProf.ListarObjeto(oBEProf);
        }
    }
}
