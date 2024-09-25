using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BEJugador:Entidad
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public int CantidadAmarillas { get; set; }
        public int CantidadRojas { get; set; }
        public int GolesRealizados { get; set; }


    }
}
