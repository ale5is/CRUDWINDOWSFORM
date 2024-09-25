using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BLLAlumno
    {

        #region "Propiedades"
        //propiedades de la clase Alumno
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public int DNI{ get; set; }

         public DateTime FechaNac { get; set; }
        public int Edad { get; set; }

        public BLLLocalidad oLocalidad { get; set; }


        #endregion

        #region "Metodos"        


        //Metodos de no
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
        //convierto a Lista lo que traigo del Dataset
        public List<BLLAlumno> CargarListaAlumnos()
        {  //instancio un objeto de la clase datos para operar con la BD
            List<BLLAlumno> ListaAlumnos = new List<BLLAlumno>();
            DataSet Ds;
            string Consulta = "Select Alumno.Codigo,Alumno.Nombre,Apellido,DNI,FechaNac,Localidad.Codigo as CodLoc,Localidad.Nombre as Localidad from Alumno, Localidad where Alumno.CodLocalidad = Localidad.Codigo;Select Codigo, nombre from Alumno where Nombre='Juan'";
            oDatos = new Acceso();
            Ds = oDatos.Leer2(Consulta);

            //rcorro la tabla dentro del Dataset y la paso a lista
            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    BLLAlumno oAlumno = new BLLAlumno();
                    oAlumno.Codigo = Convert.ToInt32(fila[0]);
                    oAlumno.Nombre = fila[1].ToString();
                    oAlumno.Apellido = fila["Apellido"].ToString();
                    oAlumno.DNI = Convert.ToInt32(fila["DNI"]);
                    oAlumno.FechaNac = Convert.ToDateTime(fila["FechaNac"]);
                    oAlumno.Edad = oAlumno.Calcular_Edad();
                        BLLLocalidad oLoc = new BLLLocalidad();
                        oLoc.Codigo = Convert.ToInt32(fila["CodLoc"]);
                        oLoc.Localidad = fila["Localidad"].ToString();
                    oAlumno.oLocalidad = oLoc;
                    ListaAlumnos.Add(oAlumno);
                }
            }
            else
            { ListaAlumnos = null; }
            return ListaAlumnos;
        }

        public bool AltaAlumno(BLLAlumno oAlu)
        {
            string Consulta_SQL = "Insert into Alumno (Nombre, Apellido,DNI, FechaNac,CodLocalidad) values('" + oAlu.Nombre + "', '" + oAlu.Apellido + "', " + oAlu.DNI + ",'"+(oAlu.FechaNac).ToString("MM/dd/yyyy")+"',"+oAlu.oLocalidad.Codigo+") ";
            //opcion 2
            // string Consulta_SQL = string.Format("Insert into Alumno(Nombre, Apellido,DNI, FechaNac,CodLocalidad) values ('{0}','{1}',{2},'{3}',{4})", oAlu.Nombre,oAlu.Apellido, oAlu.DNI,(oAlu.FechaNac).ToString("MM/dd/yyyy"),oAlu.oLocalidad.Codigo);
            oDatos = new Acceso();
            return oDatos.Escribir(Consulta_SQL);
        }

        public bool ModifAlumno(BLLAlumno oAlu)
        {
            string Consulta_SQL = "Update Alumno SET Nombre = '" + oAlu.Nombre + "', Apellido = '" + oAlu.Apellido + "', DNI = " + oAlu.Edad + ", FechaNac ='"+(oAlu.FechaNac).ToString("MM/dd/yyyy") + "', CodLocalidad = "+oAlu.oLocalidad.Codigo+" where codigo = " + oAlu.Codigo + "";
            // string COnsulta_SQL2= string.Format("update Alumno set Nombre = '{0}', Apellido = '{1}', DNI = {2} , FechaNac = '{3}', CodLocalidad = {4} where Codigo = {5}", oAlu.Nombre, oAlu.Apellido,oAlu.DNI,(oAlu.FechaNac).ToString("MM/dd/yyyy"),oAlu.oLocalidad.Codigo, oAlu.Codigo);
            oDatos = new Acceso();
            return oDatos.Escribir(Consulta_SQL);
        }

        public bool BajaAlumno(BLLAlumno oAlu)
        {
            string Consulta_SQL = "DELETE FROM Alumno where Codigo = " + oAlu.Codigo + "";
            oDatos = new Acceso();
            return oDatos.Escribir(Consulta_SQL);
        }

        #endregion
    }
}
