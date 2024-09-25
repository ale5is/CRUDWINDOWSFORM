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
        //declaro el objeto del tipo conection y uso el constructor para pasar el ConnectionString
        private SqlConnection oCnn = new SqlConnection(@"Data Source =.\SQLEXPRESS02; Initial Catalog = MiBaseV2; Integrated Security = True");
        //Creo el objeto command
        SqlCommand cmd;

        // creo una funcion para saber el estado de la conexion
        public string TestConnection()
        {
            oCnn.Open();
            //si no uso el metodo Abrir puedo hacer el open 
            //conexion.Open();
            //Cerrar();
            if (oCnn.State == ConnectionState.Open)
            {
                return "Conexion a la BD OK";
            }
            else
            {  
                return "No se pudo conectar a la BD, que pacho???";
            }
         
        }

        
    
        //Metodo Generico para leer
         public DataTable Leer(string consulta)
        {
            DataTable tabla = new DataTable();
            try
            {
                //creo el data adapter le paso la consulta y la conexion
                SqlDataAdapter Da = new SqlDataAdapter(consulta, oCnn);
                //lleno la tabla con el metodo fill
                Da.Fill(tabla);
               
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
            finally
            { //cierro la Conexion
                oCnn.Close();
            }
            return tabla;
        }

        //leo un escalar-
        public bool LeerScalar(string consulta)
        {
            oCnn.Open();
            //uso el constructor del objeto Command al instanciar el objeto
            cmd = new SqlCommand(consulta, oCnn);
            cmd.CommandType = CommandType.Text;
            try
            {
                int Respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                oCnn.Close();
                if (Respuesta > 0)
                { return true; }
                else
                { return false; }
            }
            catch (SqlException ex)
            { throw ex;}
        }
  
        public DataSet Leer2 (string Consulta_SQL)
        {
            DataSet Ds = new DataSet();
            try
            {
                //creo el data adapter le paso la consulta y la conexion
                SqlDataAdapter Da = new SqlDataAdapter(Consulta_SQL, oCnn);
                //lleno el DataSet con el metodo fill
                Da.Fill(Ds);
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
            finally
            { //cierro la Conexion
                oCnn.Close();
            }
            return Ds;
        }

        //realizo un método escribir generico, dado que recibo un string q es la consulta de SQL
        public bool Escribir(string Consulta_SQL)
        {
            
            oCnn.Open();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = oCnn;
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

            finally
            { oCnn.Close(); }

           

        }
    }
}
