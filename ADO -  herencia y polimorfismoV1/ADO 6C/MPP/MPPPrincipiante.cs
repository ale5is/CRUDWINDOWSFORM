using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Abstraccion;
using BE;

namespace MPP
{
    public class MPPPrincipiante : IGestor<BEPrincipiante>
    {

        public MPPPrincipiante()      
        {
            oDatos = new Datos();
        }

        Datos oDatos;

        public bool Guardar(BEPrincipiante oBEPrin)
        {
            string Consulta = string.Format("Insert into Jugador(TAmarilla, TRoja, Goles, Rapado, Nombre, Apellido,DNI) values({0},{1},{2},'{3}','{4}','{5}',{6})", oBEPrin.CantidadAmarillas, oBEPrin.CantidadRojas, oBEPrin.GolesRealizados, oBEPrin.Rapado, oBEPrin.Nombre, oBEPrin.Apellido,oBEPrin.DNI);
            return oDatos.Escribir(Consulta);
        }

        public BEPrincipiante ListarObjeto(BEPrincipiante oBEprin)
        {
            string Consulta = "Select * from Jugador where DNI=" + oBEprin.DNI;
            DataTable Tabla = oDatos.Leer(Consulta);

            if (Tabla.Rows.Count > 0)

            {
                foreach (DataRow fila in Tabla.Rows)
                {
                    BEPrincipiante oBEP = new BEPrincipiante();
                    oBEP.Codigo = Convert.ToInt32(fila["Codigo"]);
                    oBEP.Nombre = fila["Nombre"].ToString();
                    oBEP.Apellido = fila["Apellido"].ToString();
                    oBEP.DNI = Convert.ToInt32(fila["DNI"]);
                    return oBEP;
                }
               
            }
            return null;
        }

        public bool Guardar_JugadorXEquipo(BEEquipo oBEEq, BEPrincipiante oBEEPri)
        { //para graabar en la tabla intermedia necesito el codigo de equipo y el codigo de jugador
           //como al jugador lo di de alta recien, necesito el codigo, por eso listo el obejto por DNI
           //si se grabo lo recupero y escribo en la tabla intermedia
           //sino devuelvo falso
            string Consulta;
            BEPrincipiante oBEPriBuscado = new BEPrincipiante();
            oBEPriBuscado = ListarObjeto(oBEEPri);
            if (oBEPriBuscado.Codigo != 0)
            {
                Consulta = string.Format("Insert Into Equipo_Jugador(CodEquipo,CodJugador) values({0},{1})", oBEEq.Codigo, oBEPriBuscado.Codigo);
                return oDatos.Escribir(Consulta);
            }
            else
            {
                return false;
            }
            
        }
  
        public List<BEPrincipiante> ListarTodo()
        {
            throw new NotImplementedException();
        }

      
        public bool Baja(BEPrincipiante Objeto)
        {
            throw new NotImplementedException();
        }

    }
}
