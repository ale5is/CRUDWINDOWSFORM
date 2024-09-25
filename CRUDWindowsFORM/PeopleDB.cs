using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Remoting.Contexts;
using static CRUDWindowsFORM.PeopleDB;



namespace CRUDWindowsFORM
{
    public class PeopleDB
    {
        private string connectionString = "Data Source=KERNELOS-PC;Initial Catalog = CrudWindowsForm; " +
            "Integrated Security = True; Connect Timeout = 30; " +
            "Encrypt=False";


        public bool Ok()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // This line remains unchanged
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;

        }

        public List<People> Get()
        {
            List<People> people = new List<People>();

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT id, Name, Age FROM People", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    People p = new People();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Age = reader.GetInt32(2);
                    people.Add(p);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }
            return people;
        }

        public void Add(String Name, int Edad)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO people (name, age) VALUES " +
                    "(@name, @age) ", connection);
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@age", Edad);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();

            }
            
        }

        public void Update(String Name, int Edad, int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE people SET name=@name, age=@age WHERE id=@id", connection);
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@age", Edad);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM people WHERE id=@id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public People Get(int id)
        {
            People people = new People();
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT id, Name, Age FROM People WHERE id=@id", connection);
                command.Parameters.AddWithValue("@id", id); // Agregar el parámetro @id
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) // Asegurarse de que hay datos antes de leer
                {
                    people.ID = reader.GetInt32(0);
                    people.Name = reader.GetString(1);
                    people.Age = reader.GetInt32(2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return people;
        }
        public class People
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }

        }
    }
}
