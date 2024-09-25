using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//uso las librerias de SQL
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class Acceso
    {
        //declaro el objeto del tipo conection y uso el constructor para pasar el ConnectionString
        private SqlConnection oCnn = new SqlConnection(@"Data Source=.\SQLEXPRESS02;Initial Catalog=BD_Ejemplo_Null;Integrated Security=True");


        //Metodo Generico para leer
        public DataSet Leer2(string Consulta_SQL)
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
            SqlCommand cmd = new SqlCommand();
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
