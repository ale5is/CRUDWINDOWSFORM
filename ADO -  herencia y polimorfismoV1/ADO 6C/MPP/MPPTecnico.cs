using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Abstraccion;
using DAL;
using System.Data;

namespace MPP
{
    public class MPPTecnico : IGestor<BETecnico>
    {
        public MPPTecnico()
        {
            oDatos = new Datos();
        }

       Datos oDatos;
        public List<BETecnico> ListarTodo()
        {
            //instancio un objeto de la clase datos para operar con la BD
            List<BETecnico> ListaTecnicos = new List<BETecnico>();
     
            string Consulta = "Select Codigo,Nombre,Apellido,DNI From Tecnico where Estado = 'False'";
    
            DataTable Tabla = oDatos.Leer(Consulta);

            //rcorro la tabla dentro del Dataset y la paso a lista
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in Tabla.Rows)
                {
                    BETecnico oBETec = new BETecnico();
                    oBETec.Codigo = Convert.ToInt32(fila[0]);
                    oBETec.Nombre = fila[1].ToString();
                    oBETec.Apellido = fila["Apellido"].ToString();
                    oBETec.DNI = Convert.ToInt32(fila["DNI"]);
                    ListaTecnicos.Add(oBETec);
                }
            }
            return ListaTecnicos;
        }
 

        public bool Guardar(BETecnico oBETec)
        {
             //hago el update del campo estado cuando se asigna el tecnico a un equipo
            oBETec.Estado = true;
            string Consulta_SQL= string.Format("update Tecnico set Estado= '{0}' where Codigo = {1}", oBETec.Estado, oBETec.Codigo);
            return oDatos.Escribir(Consulta_SQL);
        }

        public bool Baja(BETecnico Objeto)
        {
            throw new NotImplementedException();
        }
        public BETecnico ListarObjeto(BETecnico Objeto)
        {
            throw new NotImplementedException();
        }

     
    }
}
