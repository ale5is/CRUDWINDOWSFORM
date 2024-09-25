﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referebcia a las capa BE, DAL y libreria system.Data para Datables o Dataset
using BE;
using DAL;
using System.Data;
//referencia a la capa de abstraccion
using Abstraccion;

namespace MPP
{
    public class MPPAlumno: IGestor<BEAlumno>

    {
        Acceso oDatos;
        public List<BEAlumno> ListarTodo()
        {  //instancio un objeto de la clase datos para operar con la BD
            List<BEAlumno> ListaAlumnos = new List<BEAlumno>();
            //Declaro el objeto DataSet para guardar los datos y luego pasarlos a lista
            DataSet Ds;
            string Consulta = "Select Alumno.Codigo,Alumno.Nombre,Apellido,DNI,FechaNac,Localidad.Codigo as CodLoc,Localidad.Nombre as Localidad from Alumno, Localidad where Alumno.CodLocalidad = Localidad.Codigo;Select Codigo, nombre from Alumno where Nombre='Juan'";
            oDatos = new Acceso();
            Ds = oDatos.Leer2(Consulta);

            //rcorro la tabla dentro del Dataset y la paso a lista
            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    BEAlumno oBEAlumno = new BEAlumno();
                    oBEAlumno.Codigo = Convert.ToInt32(fila[0]);
                    oBEAlumno.Nombre = fila[1].ToString();
                    oBEAlumno.Apellido = fila["Apellido"].ToString();
                    oBEAlumno.DNI = Convert.ToInt32(fila["DNI"]);
                    oBEAlumno.FechaNac = Convert.ToDateTime(fila["FechaNac"]);
                    oBEAlumno.Edad = oBEAlumno.Calcular_Edad();
                    BELocalidad oBELoc = new BELocalidad();
                    oBELoc.Codigo = Convert.ToInt32(fila["CodLoc"]);
                    oBELoc.Localidad = fila["Localidad"].ToString();
                    oBEAlumno.oBELocalidad = oBELoc;
                    ListaAlumnos.Add(oBEAlumno);
                }
            }
            else
            { ListaAlumnos = null; }
            return ListaAlumnos;
        }

        public bool Guardar(BEAlumno oBEAlu)
        {
            string Consulta_SQL;
            if (oBEAlu.Codigo != 0)
            {
                Consulta_SQL = "Update Alumno SET Nombre = '" + oBEAlu.Nombre + "', Apellido = '" + oBEAlu.Apellido + "', DNI = " + oBEAlu.DNI + ", FechaNac ='" + (oBEAlu.FechaNac).ToString("MM/dd/yyyy") + "', CodLocalidad = " + oBEAlu.oBELocalidad.Codigo + " where codigo = " + oBEAlu.Codigo + "";
                // string COnsulta_SQL2= string.Format("update Alumno set Nombre = '{0}', Apellido = '{1}', DNI = {2} , FechaNac = '{3}', CodLocalidad = {4} where Codigo = {5}", oAlu.Nombre, oAlu.Apellido,oAlu.DNI,(oAlu.FechaNac).ToString("MM/dd/yyyy"),oAlu.oLocalidad.Codigo, oAlu.Codigo);
            }
            else
            {
                Consulta_SQL = "Insert into Alumno (Nombre, Apellido,DNI, FechaNac,CodLocalidad) values('" + oBEAlu.Nombre + "', '" + oBEAlu.Apellido + "', " + oBEAlu.DNI + ",'" + (oBEAlu.FechaNac).ToString("MM/dd/yyyy") + "'," + oBEAlu.oBELocalidad.Codigo + ") ";
                //opcion 2
                // string Consulta_SQL = string.Format("Insert into Alumno(Nombre, Apellido,DNI, FechaNac,CodLocalidad) values ('{0}','{1}',{2},'{3}',{4})", oAlu.Nombre,oAlu.Apellido, oAlu.DNI,(oAlu.FechaNac).ToString("MM/dd/yyyy"),oAlu.oLocalidad.Codigo);
            }
            oDatos = new Acceso();
            return oDatos.Escribir(Consulta_SQL);
        }


        public bool Baja(BEAlumno oBEAlu)
        {
            string Consulta_SQL = "DELETE FROM Alumno where Codigo = " + oBEAlu.Codigo + "";
            oDatos = new Acceso();
            return oDatos.Escribir(Consulta_SQL);
        }

        public BEAlumno ListarObjeto(BEAlumno Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
