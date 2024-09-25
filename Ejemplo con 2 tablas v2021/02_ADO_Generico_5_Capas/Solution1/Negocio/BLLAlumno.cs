using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencia a la capa de BE y MPP
using BE;
using MPP;


namespace Negocio
{
    public class BLLAlumno
    {
        public BLLAlumno()
        {//instancio el objeto mapper en el constructor de la clase Alumno
            oMPPAlu = new MPPAlumno();

        }

        MPPAlumno oMPPAlu;

        public List<BEAlumno> CargarListaAlumnos()
        {
            return oMPPAlu.CargarListaAlumnos();
        }

        public bool Guardar(BEAlumno oBEAlu)
        {
            return oMPPAlu.Guardar(oBEAlu);
        }

         public bool BajaAlumno(BEAlumno oBEAlu)
        {
            return oMPPAlu.BajaAlumno(oBEAlu);
        }




    }
}
