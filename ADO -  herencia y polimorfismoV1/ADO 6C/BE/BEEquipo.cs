using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEEquipo:Entidad
    {
        #region "Propiedades"
        public string Nombre { get; set; }
        public string Color { get; set; }

        //relacion 1 a 1
        public BETecnico Tecnico { get; set; }

        //relacion de 1 a muchos
        public List<BEJugador> ListaJugadores { get; set; }
        #endregion

    }
}
