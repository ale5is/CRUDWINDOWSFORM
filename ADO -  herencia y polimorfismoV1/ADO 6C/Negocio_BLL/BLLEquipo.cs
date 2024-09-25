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
    public class BLLEquipo:IGestor<BEEquipo>
    {
        public BLLEquipo()
        {
            oMPPEquipo = new MPPEquipo();
        }

        MPPEquipo oMPPEquipo;

        #region "Metodo Propio"
        public int ObtenerPuntajeEquipo(BEEquipo oBEEquipo)
        {
            int ptos = 0;

            foreach (BEJugador jugador in oBEEquipo.ListaJugadores)
            {
                if (jugador is BEPrincipiante)
                {
                    BLLPrincipiante oBLLprin = new BLLPrincipiante();
                    ptos = oBLLprin.ObtenerPuntaje(jugador) + ptos;

                }
                else
                {
                    BLLProfesional oBLLprof = new BLLProfesional();
                    ptos = oBLLprof.ObtenerPuntaje(jugador) + ptos;
                }

            }
            return ptos;
        }
        #endregion

        public List<BEEquipo> ListarTodo()
        {
            return oMPPEquipo.ListarTodo();
        }

        public bool Guardar(BEEquipo oBEEquipo)
        {
            return oMPPEquipo.Guardar(oBEEquipo);
        }

        public bool Baja(BEEquipo Objeto)
        {
            throw new NotImplementedException();
        }

        public BEEquipo ListarObjeto(BEEquipo Objeto)
        {
            throw new NotImplementedException();
        }

       

    }
}
