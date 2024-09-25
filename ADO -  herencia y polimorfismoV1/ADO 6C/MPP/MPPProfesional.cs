using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Abstraccion;
using BE;
using System.Data;

namespace MPP
{
    public class MPPProfesional:IGestor<BEProfesional>
    {

        public MPPProfesional()
        {
            oDatos = new Datos();
        }

        Datos oDatos;



        public bool Guardar(BEProfesional oBEProf)
        {
            string Consulta = string.Format("Insert into Jugador(TAmarilla, TRoja, Goles, Nombre, Apellido,DNI) values({0},{1},{2},'{3}','{4}',{5})", oBEProf.CantidadAmarillas, oBEProf.CantidadRojas, oBEProf.GolesRealizados, oBEProf.Nombre, oBEProf.Apellido, oBEProf.DNI);
            return oDatos.Escribir(Consulta);
        }

        public BEProfesional ListarObjeto(BEProfesional oBEProf)
        {
            string Consulta = "Select * from Jugador where DNI=" + oBEProf.DNI;
            DataTable Tabla = oDatos.Leer(Consulta);

            if (Tabla.Rows.Count > 0)

            {
                foreach (DataRow fila in Tabla.Rows)
                {
                    BEProfesional oBEP = new BEProfesional();
                    oBEP.Codigo = Convert.ToInt32(fila["Codigo"]);
                    oBEP.Nombre = fila["Nombre"].ToString();
                    oBEP.Apellido = fila["Apellido"].ToString();
                    oBEP.DNI = Convert.ToInt32(fila["DNI"]);
                    return oBEP;
                }

            }
            return null;
        }

        public bool Guardar_JugadorXEquipo(BEEquipo oBEEq, BEProfesional oBEEProf)
        { //para graabar en la tabla intermedia necesito el codigo de equipo y el codigo de jugador
          //como al jugador lo di de alta recien, necesito el codigo, por eso listo el obejto por DNI
          //si se grabo lo recupero y escribo en la tabla intermedia
          //sino devuelvo falso
            string Consulta;
            BEProfesional oBEProfBuscado = new BEProfesional();
            oBEProfBuscado = ListarObjeto(oBEEProf);
            if (oBEProfBuscado.Codigo != 0)
            {
                Consulta = string.Format("Insert Into Equipo_Jugador(CodEquipo,CodJugador) values({0},{1})", oBEEq.Codigo, oBEProfBuscado.Codigo);
                return oDatos.Escribir(Consulta);
            }
            else
            {
                return false;
            }

        }

        public bool Baja(BEProfesional Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEProfesional> ListarTodo()
        {
            throw new NotImplementedException();
        }

 
    }
}
