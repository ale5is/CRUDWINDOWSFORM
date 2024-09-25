using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencia a la DAL
using DAL;
//referencia a la BE
using BE;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;

namespace Negocio
{
    public class BLLUsuario
    {
        //Metodos de Usuario

      
        //convierto a Lista lo que traigo del Dataset
        public List<BEUsuario> CargarListaUsuarios()
        {  ///Declaro el objeto DataSet para guardar los datos y luego pasarlos a lista
            DataSet Ds;
            Acceso oDatos = new Acceso();
            string Consulta = "Select Codigo,Nombre,Apellido,mail,password from Persona";
            Ds = oDatos.Leer2(Consulta);
            List<BEUsuario> ListaUsuarios = new List<BEUsuario>();

            //rcorro la tabla dentro del Dataset y la paso a lista
            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in Ds.Tables[0].Rows)
                {
                    BEUsuario oBEusu = new BEUsuario();
                    oBEusu.Codigo = Convert.ToInt32(fila[0]);
                   oBEusu.Nombre = fila[1].ToString();
                    oBEusu.Apellido = fila["Apellido"].ToString();
                   if (fila["mail"] is DBNull)
                    { oBEusu.Usuario = null; }
                    else
                    { oBEusu.Usuario = fila["mail"].ToString(); }


                    if (fila["password"] is DBNull)
                    { oBEusu.Psw = null; }
                    else
                    {  oBEusu.Psw = fila["password"].ToString();  }
                    ListaUsuarios.Add(oBEusu);
                }
            }
            else
            { ListaUsuarios = null; }
            return ListaUsuarios;
        }

        public bool Guardar(BEUsuario oBEUsu)
        {
            string Consulta_SQL;
            if (oBEUsu.Codigo != 0)
            {   //modifico
                Consulta_SQL = string.Format("update Persona set Nombre = '{0}', Apellido = '{1}', mail = '{2}', password = '{3}' where Codigo = {4}", oBEUsu.Nombre, oBEUsu.Apellido, oBEUsu.Usuario, oBEUsu.Psw, oBEUsu.Codigo);
            }
            else 
            {   //inserto
                Consulta_SQL = "Insert into Persona(Nombre, Apellido,mail,password) values('" + oBEUsu.Nombre + "', '" + oBEUsu.Apellido + "','" + oBEUsu.Usuario + "','" + oBEUsu.Psw + "' )";
            }
            
            //instancio un objeto de la clase datos para operar con la BD
                    
            Acceso oDatos = new Acceso();
              return oDatos.Escribir(Consulta_SQL);
        }

              

        public bool BajaUsuario(BEUsuario oBEusu)
        {//instancio un objeto de la clase datos para operar con la BD
            Acceso oDatos = new Acceso();
            string Consulta_SQL = "DELETE FROM Persona where Codigo = " + oBEusu.Codigo + "";
            return oDatos.Escribir(Consulta_SQL);
        }
    }
}
