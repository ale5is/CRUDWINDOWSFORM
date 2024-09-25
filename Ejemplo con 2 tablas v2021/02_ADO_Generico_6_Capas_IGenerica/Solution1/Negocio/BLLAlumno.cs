using System;
using System.Collections.Generic;
//para el dataset
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencia a la capa de BE y MPP
using BE;
using MPP;
//referncia a la capa de abstraccion
using Abstraccion;

namespace Negocio
{
    public class BLLAlumno:IGestor<BEAlumno>
    {
        public BLLAlumno()
        {//instancio el objeto mapper en el constructor de la clase Alumno
            oMPPAlu = new MPPAlumno();

        }

        MPPAlumno oMPPAlu;

        public List<BEAlumno> ListarTodo()
        {
            return oMPPAlu.ListarTodo();
        }

        public bool Guardar(BEAlumno oBEAlu)
        {
            return oMPPAlu.Guardar(oBEAlu);
        }

         public bool Baja(BEAlumno oBEAlu)
        {
            return oMPPAlu.Baja(oBEAlu);
        }

        public BEAlumno ListarObjeto(BEAlumno Objeto)
        {
            throw new NotImplementedException();
        }




    }
}
