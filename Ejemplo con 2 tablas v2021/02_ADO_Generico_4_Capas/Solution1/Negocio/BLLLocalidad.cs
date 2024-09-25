using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//uso la libreria de system.Data, para instanciar Datatable
using System.Data;
//referencia a la capa de Datos
using DAL;
//referencia a la capa de Entidades
using BE;


namespace Negocio
{
   public class BLLLocalidad
    {

       

        //Metodos de la clase Localidad

        #region "Metodos"

              
        Acceso oDatos;
        public List<BELocalidad> CargarListaLocalidades()
        {  //Declaro el objeto datatable para guardar los datos y luego pasarlos a lista
            DataTable Tabla;
            oDatos = new Acceso();
            Tabla = oDatos.Leer("Select Codigo,Nombre  as Localidadlalala From Localidad");
            List<BELocalidad> ListaLocalidad = new List<BELocalidad>();

            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in Tabla.Rows)
                {
                    BELocalidad oBELoc = new BELocalidad();
                    oBELoc.Codigo = Convert.ToInt32(fila[0]);
                    oBELoc.Localidad = fila["Localidadlalala"].ToString();
                    ListaLocalidad.Add(oBELoc);
                }
            }
            else
            { ListaLocalidad = null; }
            return ListaLocalidad;
        }

        public bool Guardar(BELocalidad oBELocalidad)
        {     string Consulta_SQL;
            if (oBELocalidad.Codigo == 0)
            { Consulta_SQL = "Insert into Localidad (Nombre)values('" + oBELocalidad.Localidad + "')"; }

            else
            { Consulta_SQL = "update Localidad SET Nombre = '" + oBELocalidad.Localidad + "' where Codigo = " + oBELocalidad.Codigo + ""; }
            oDatos = new Acceso();
            return oDatos.Escribir(Consulta_SQL);
        }

        public bool Baja(BELocalidad oBELocalidad)
        {    
            if (Existe_Localidad_Asociada(oBELocalidad) == false)
            {
                string Consulta_SQL;
                Consulta_SQL = "DELETE FROM Localidad where Codigo = " + oBELocalidad.Codigo + "";
                //si lo escribe bien devuelve true
                oDatos = new Acceso();
                return oDatos.Escribir(Consulta_SQL);
            }
            else
            { return false; }
        }

        //busco si existe alguna localidad asociada a un alumno
        public bool Existe_Localidad_Asociada(BELocalidad oBELoc)
        {  //instancio un objeto de la clase datos para operar con la BD
            oDatos = new Acceso();
            return oDatos.LeerScalar("select count(CodLocalidad) from Alumno where CodLocalidad =" + oBELoc.Codigo + "");

        }
        #endregion
    }
}
