using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//uso las librerias de SQL
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class Acceso
    {
        //declaro el objeto del tipo conection
        private SqlConnection conexion;

        //creo el metodoAbrir,le paso la cadena de conexion para saber la direccion de la BD y la abro con la propiedad Open
        public void Abrir()
        {
            conexion = new SqlConnection();

            // le paso el conectiostring para saber a que BD me voy a conectar
            conexion.ConnectionString = @"Data Source=.\SQLEXPRESS02;Initial Catalog=MiBasev2;Integrated Security=True";
            conexion.Open();
        }
        //en caso de que use el constructor
        //private SqlConnection conexion = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MiBasev2;Integrated Security=True");

        //creo el metodoCerrar la conexion y limpio la misma de memoria con le Dispose.
        public void Cerrar()
        {
            conexion.Close();
            conexion.Dispose();
            conexion = null;
            GC.Collect();
        }

        // creo una funcion para saber el estado de la conexion
        public string TestConnection()
        {
            // Abrir();
            //si no uso el metodo Abrir puedo hacer el open 
            conexion = new SqlConnection();
           // conexion.Open();
            //Cerrar();
            if (conexion.State == ConnectionState.Open)
            {
                return "Conexion a la BD OK";
            }
            else
            {
                return "No se pudo conectar a la BD, que pacho???";
            }
        }


        public List<BLLLocalidad> LeerLocalidades()
        {
            //instancio la lista del tipoLocalidad
            List<BLLLocalidad> ListaLocades = new List<BLLLocalidad>();
            //abro la coneccion
            Abrir();
            //instancio el objeto command
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //envio la consulta
            cmd.CommandText = "Select Codigo,Nombre from Localidad";
            cmd.Connection = conexion;
             // instancio el objeto lector del tipo datareader
            SqlDataReader lector = cmd.ExecuteReader();
            //recorro toda la tabla y por cada registo creo un obeto del tipo Localidad y lo agrego a la lista
            while (lector.Read())
            {
                BLLLocalidad oLocalidad = new BLLLocalidad();
                oLocalidad.Codigo = Convert.ToInt32(lector[0]);
                oLocalidad.Localidad = lector[1].ToString();
                ListaLocades.Add(oLocalidad);
            }
            //cierro la conexion del datareader
            lector.Close();
            //cierro la conexion a la BD
            Cerrar();
            // devuelvo la lista llena
            return ListaLocades;
        }

        public bool Existe_Localidades_Asociadas(BLLLocalidad oLoc)
        {

            try
            {
                //abro la coneccion
                Abrir();
                //instancio el objeto command
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                //envio la consulta
                cmd.CommandText = "select count(CodLocalidad) from Alumno where CodLocalidad =" + oLoc.Codigo + "";
                cmd.Connection = conexion;
                //devuelve la cantidad 
                int Cantidad = Convert.ToInt32(cmd.ExecuteScalar());

                //si cantidad >0 entonces esta asociada minimo a un alumno
                if (Cantidad > 0)
                { return true; }
                else
                { return false; }
                //cierro la conexion a la BD


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            { Cerrar(); }
          
        }
        public int AltaLocalidad(BLLLocalidad oLocalidad)
        {
            int filasAfectadas = 0;
            Abrir();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conexion;
            cmd.CommandText = "Insert into Localidad (Nombre)values('" + oLocalidad.Localidad + "')";
            try
            { filasAfectadas = cmd.ExecuteNonQuery();}
            catch (SqlException ex)
            {  filasAfectadas = -1;
                throw ex;
            }

            Cerrar();
            return filasAfectadas;
        }

        public int ModificarLocalidad(BLLLocalidad oLocalidad)
        {
            int filasAfectadas = 0;
            Abrir();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conexion;
            cmd.CommandText = "update Localidad SET Nombre = '" + oLocalidad.Localidad + "' where Codigo = " + oLocalidad.Codigo + "";
            try
            { filasAfectadas = cmd.ExecuteNonQuery(); }
            catch (SqlException ex)
            { filasAfectadas = -1;
             throw ex;}

            Cerrar();
            return filasAfectadas;
        }

        public int BajaLocalidad(BLLLocalidad oLocalidad)
        {
            int filasAfectadas = 0;
            Abrir();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conexion;
            cmd.CommandText = "DELETE FROM Localidad where Codigo = " + oLocalidad.Codigo + "";
            try
            { filasAfectadas = cmd.ExecuteNonQuery(); }
            catch (SqlException ex)
            {
                filasAfectadas = -1;
                throw ex;
            }

             return filasAfectadas;
            
            }


        //metodo traer alumnos
        //creo una funcion del tipo lista de alumnos.
        public List<BLLAlumno> LeerAlumnos ()
        {
            //instancio la lista del tipoAlumno
            List<BLLAlumno> ListaAlumnos = new List<BLLAlumno>();
            //abro la coneccion
            Abrir();
            //instancio el objeto command
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //envio la consulta
            cmd.CommandText = "Select Alumno.Codigo,Alumno.Nombre,Apellido,DNI,FechaNac,Localidad.Codigo as CodLoc,Localidad.Nombre as Localidad from Alumno, Localidad where Alumno.CodLocalidad = Localidad.Codigo";
            cmd.Connection = conexion;
            // instancio el objeto lector del tipo datareader
            SqlDataReader lector = cmd.ExecuteReader();
            //recorro toda la tabla y por cada registo creo un obeto del tipo  alumno y lo agrego a la lista
            while (lector.Read())
            {
                BLLAlumno oAlumno = new BLLAlumno();
                oAlumno.Codigo = Convert.ToInt32(lector[0]);
                oAlumno.Nombre = lector[1].ToString();
                oAlumno.Apellido = lector["Apellido"].ToString();
                oAlumno.DNI = Convert.ToInt32(lector["DNI"]);
                oAlumno.FechaNac = Convert.ToDateTime(lector["FechaNac"]);
                oAlumno.Edad = oAlumno.Calcular_Edad();
                   BLLLocalidad oLoc = new BLLLocalidad();
                   oLoc.Codigo = Convert.ToInt32(lector["CodLoc"]);
                   oLoc.Localidad = lector["Localidad"].ToString();
                oAlumno.oLocalidad = oLoc;
                ListaAlumnos.Add(oAlumno);
            }
            //cierro la conexion del datareader
            lector.Close();
            //cierro la conexion a la BD
            Cerrar();
            // devuelvo la lista llena
            return ListaAlumnos;
        }

        //realizo un metodo escribir generico, dado que recibo un string q es la consulta de SQL
        public bool Escribir(string Consulta_SQL)
        {
           
            Abrir();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conexion;

            cmd.CommandText = Consulta_SQL;
            try
            {
                int respuesta = cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            { Cerrar(); }

            }
    }
}
