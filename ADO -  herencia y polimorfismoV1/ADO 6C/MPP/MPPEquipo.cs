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
    public class MPPEquipo : IGestor<BEEquipo>
    {
        public MPPEquipo()
        {
            oDatos = new Datos();
        }

        Datos oDatos;


        public List<BEEquipo> ListarTodo()
        {
            List<BEEquipo> LEquipo = new List<BEEquipo>();
         
            string Consulta_SQL = "Select Equipo.Codigo,Equipo.Nombre as Equipo, Equipo.Color, Tecnico.Nombre,Tecnico.Apellido,Tecnico.DNI  from Equipo,Tecnico where Equipo.CodTecnico= Tecnico.Codigo";

             DataTable Tabla = oDatos.Leer(Consulta_SQL);

            //rcorro la tabla dentro del Dataset y la paso a lista
            if (Tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in Tabla.Rows)
                {
                    BEEquipo oBEEquipo = new BEEquipo();
                    oBEEquipo.Codigo = Convert.ToInt32(fila["Codigo"]);
                    oBEEquipo.Nombre = fila["Equipo"].ToString();
                    oBEEquipo.Color = fila["Color"].ToString();
                    //busco al tecnico
                    //lo cargo usando el constrcutor sobrecargado
                    BETecnico oBETec = new BETecnico(fila["Nombre"].ToString(), fila["Apellido"].ToString(), Convert.ToInt32(fila["DNI"]));
                    //oBETec.Nombre = fila["Nombre"].ToString();
                    //oBETec.Apellido = fila["Apellido"].ToString();
                    //oBETec.DNI = Convert.ToInt32(fila["DNI"]);
                    oBEEquipo.Tecnico = oBETec;
                    //busco la lista de jugadores
                    Datos oDatos2 = new Datos();
                    DataTable Tabla2 = oDatos2.Leer("Select J.Codigo,J.Nombre,J.Apellido,J.DNI,J.Rapado, J.TRoja, J.TAmarilla,J.Goles" +
                                                    " from Equipo_Jugador, Jugador as J, Equipo as E " +
                                                     "Where Equipo_Jugador.CodJugador = J.Codigo and Equipo_Jugador.CodEquipo= E.Codigo and E.Codigo=" + oBEEquipo.Codigo);
                    List<BEJugador> LJugador = new List<BEJugador>();
                    if (Tabla2.Rows.Count > 0)
                    {
                        foreach (DataRow fila2 in Tabla2.Rows)
                        {
                            //si el campo rapado es NULL entonces es un jugador Profesional
                            if (fila2["Rapado"] is DBNull)
                          
                            {
                            BEProfesional oBEPro = new BEProfesional(); 
                            oBEPro.Codigo = Convert.ToInt32(fila2["Codigo"]);
                            oBEPro.Nombre = fila2["Nombre"].ToString();
                            oBEPro.Apellido = fila2["Apellido"].ToString();
                            oBEPro.DNI = Convert.ToInt32(fila2["DNI"]);
                            oBEPro.CantidadRojas = Convert.ToInt32(fila2["TRoja"]);
                            oBEPro.CantidadAmarillas = Convert.ToInt32(fila2["TAmarilla"]);
                            oBEPro.GolesRealizados = Convert.ToInt32(fila2["Goles"]);
                            LJugador.Add(oBEPro);
                            }

                            else
                            {//si el campo rapado es distinto de null entonces es true y es principiant
                                BEPrincipiante oBEPrin = new BEPrincipiante();
                                oBEPrin.Rapado = true;
                                oBEPrin.Codigo = Convert.ToInt32(fila2["Codigo"]);
                                oBEPrin.Nombre = fila2["Nombre"].ToString();
                                oBEPrin.Apellido = fila2["Apellido"].ToString();
                                oBEPrin.DNI = Convert.ToInt32(fila2["DNI"]);
                                oBEPrin.CantidadRojas = Convert.ToInt32(fila2["TRoja"]);
                                oBEPrin.CantidadAmarillas = Convert.ToInt32(fila2["TAmarilla"]);
                                oBEPrin.GolesRealizados = Convert.ToInt32(fila2["Goles"]);
                                LJugador.Add(oBEPrin);

                            }
                        }

                        oBEEquipo.ListaJugadores = LJugador;
                    }
                    LEquipo.Add(oBEEquipo);
                }
            }
            return LEquipo;
        }




        public bool Guardar(BEEquipo oBEEq)
        {
            string Consulta_SQL = string.Format("Insert into Equipo(Nombre, Color, CodTecnico) values ('{0}','{1}',{2})", oBEEq.Nombre, oBEEq.Color, oBEEq.Tecnico.Codigo);
            return oDatos.Escribir(Consulta_SQL);
        }
        public bool Baja(BEEquipo Objeto)
        {
            throw new NotImplementedException();
        }

        public BEEquipo ListarObjeto(BEEquipo Objeto)
        {
            throw new NotImplementedException();
        }


    }
}
