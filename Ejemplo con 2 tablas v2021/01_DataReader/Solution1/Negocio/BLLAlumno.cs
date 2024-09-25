using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BLLAlumno
    {
        //propiedades de la clase Alumno
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public int DNI{ get; set; }

         public DateTime FechaNac { get; set; }
        public int Edad { get; set; }

        public BLLLocalidad oLocalidad { get; set; }


        //Metodos de Alumno
        public int Calcular_Edad()
        {
            Edad = DateTime.Now.Year - FechaNac.Year;
            if (DateTime.Now.Month < FechaNac.Month)
                Edad -= 1;
            if (DateTime.Now.Month == FechaNac.Month && DateTime.Now.Day < FechaNac.Day)
                Edad -= 1;

            return Edad;
        }

        Acceso oDatos;
        public List<BLLAlumno> CargarAlumnos()
        {  //llamo al metodo leer alumnos que me devuelve una lista de alumnos
            oDatos = new Acceso();
            return oDatos.LeerAlumnos();
        
        }

        public bool AltaAlumno(BLLAlumno oAlu)
        {//instancio un objeto de la clase datos para operar con la BD
          oDatos = new Acceso();
            string Consulta_SQL = "Insert into Alumno (Nombre, Apellido,DNI, FechaNac,CodLocalidad) values('" + oAlu.Nombre + "', '" + oAlu.Apellido + "', " + oAlu.DNI + ",'"+(oAlu.FechaNac).ToString("MM/dd/yyyy")+"',"+oAlu.oLocalidad.Codigo+") ";
            //opcion 2
            // string Consulta_SQL = string.Format("Insert into Alumno(Nombre, Apellido,DNI, FechaNac,CodLocalidad) values ('{0}','{1}',{2},'{3}',{4})", oAlu.Nombre,oAlu.Apellido, oAlu.DNI,(oAlu.FechaNac).ToString("MM/dd/yyyy"),oAlu.oLocalidad.Codigo);
            return oDatos.Escribir(Consulta_SQL);
        }

        public bool ModifAlumno(BLLAlumno oAlu)
        {//instancio un objeto de la clase datos para operar con la BD
            oDatos = new Acceso();
            string Consulta_SQL = "Update Alumno SET Nombre = '" + oAlu.Nombre + "', Apellido = '" + oAlu.Apellido + "', DNI = " + oAlu.DNI + ", FechaNac ='"+(oAlu.FechaNac).ToString("MM/dd/yyyy") + "', CodLocalidad = "+oAlu.oLocalidad.Codigo+" where codigo = " + oAlu.Codigo + "";
            // string COnsulta_SQL2= string.Format("update Alumno set Nombre = '{0}', Apellido = '{1}', DNI = {2} , FechaNac = '{3}', CodLocalidad = {4} where Codigo = {5}", oAlu.Nombre, oAlu.Apellido,oAlu.DNI,(oAlu.FechaNac).ToString("MM/dd/yyyy"),oAlu.oLocalidad.Codigo, oAlu.Codigo);
            return oDatos.Escribir(Consulta_SQL);
        }

        public bool BajaAlumno(BLLAlumno oAlu)
        {//instancio un objeto de la clase datos para operar con la BD
            oDatos = new Acceso();
            string Consulta_SQL = "DELETE FROM Alumno where Codigo = " + oAlu.Codigo + "";
            return oDatos.Escribir(Consulta_SQL);
        }
    }
}
