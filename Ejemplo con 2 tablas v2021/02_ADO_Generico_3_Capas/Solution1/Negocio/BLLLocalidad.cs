using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//uso la libreria de system.Data, para instanciar Datatable
using System.Data;
//referencia a la capa de Datos
using DAL;


namespace Negocio
{
   public class BLLLocalidad
    {

        #region "Propiedades"
        //propiedades de Localidad

        public int Codigo { get; set; }
        public string Localidad { get; set; }


        #endregion

        //Metodos de la clase Localidad

        #region "Metodos"

        public override string ToString()
        {
            return Codigo + " " + Localidad;
        }

 
        
        Acceso oDatos;
        public List<BLLLocalidad> CargarListaLocalidades()
        {  //Declaro el objeto datatable para guardar los datos y luego pasarlos a lista
            DataTable Tabla;
            oDatos = new Acceso();
            Tabla = oDatos.Leer("Select Codigo,Nombre  as Localidadlalala From Localidad");
            List<BLLLocalidad> ListaLocalidad = new List<BLLLocalidad>();

            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in Tabla.Rows)
                {
                    BLLLocalidad oLoc = new BLLLocalidad();
                    oLoc.Codigo = Convert.ToInt32(fila[0]);
                    oLoc.Localidad = fila["Localidadlalala"].ToString();
                    ListaLocalidad.Add(oLoc);
                }
            }
            else
            { ListaLocalidad = null; }
            return ListaLocalidad;
        }

          public bool Guardar(BLLLocalidad oLocalidad)
        {     string Consulta_SQL;
            if (oLocalidad.Codigo == 0)
            { Consulta_SQL = "Insert into Localidad (Nombre)values('" + oLocalidad.Localidad + "')"; }

            else
            { Consulta_SQL = "update Localidad SET Nombre = '" + oLocalidad.Localidad + "' where Codigo = " + oLocalidad.Codigo + ""; }
            oDatos = new Acceso();
            return oDatos.Escribir(Consulta_SQL);
        }

        public bool Baja(BLLLocalidad oLocalidad)
        {
            if (Existe_Localidad_Asociada(oLocalidad) == false)
            {
                string Consulta_SQL;
                Consulta_SQL = "DELETE FROM Localidad where Codigo = " + oLocalidad.Codigo + "";
                //si lo escribe bien devuelve true
                oDatos = new Acceso();
                return oDatos.Escribir(Consulta_SQL);
            }
            else
            { return false; }
        }

        //busco si existe alguna localidad asociada a un alumno
        public bool Existe_Localidad_Asociada(BLLLocalidad oLoc)
        {  //instancio un objeto de la clase datos para operar con la BD
            oDatos = new Acceso();
            return oDatos.LeerScalar("select count(CodLocalidad) from Alumno where CodLocalidad =" + oLoc.Codigo + "");

        }

        #endregion

        #region "Metodo Generico NO usar con Objetos"

        ////Metodo generico depende la operacion se envia la consulta
        ////pero no corresponde aplicarlo con objetos
        //public bool Operacion (BLLLocalidad oLocalidad, int a)
        //{   
        //    string Consulta_SQL;
        //    switch (a)
        //    {
        //        case 1:
        //            Consulta_SQL = "Insert into Localidad (Nombre)values('" + oLocalidad.Localidad + "')"; 
        //            break;
        //        case 2:
        //            Consulta_SQL = "update Localidad SET Nombre = '" + oLocalidad.Localidad + "' where Codigo = " + oLocalidad.Codigo + "";
        //            break;
        //        case 3:
        //            Consulta_SQL = "DELETE FROM Localidad where Codigo = "+ oLocalidad.Codigo + "";
        //            break;
        //        default:
        //            Consulta_SQL = null;
        //            break;
        //    }

        //    //instancio un objeto de la clase datos para operar con la BD
        //    Acceso oDatos = new Acceso();
        //    return oDatos.Escribir(Consulta_SQL);
        //}


        #endregion
    }
}
