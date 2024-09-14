using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatabaseDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=**************;Initial Catalog=*********;Integrated Security=*********";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Bağlantı başarılı");

                    string sqlQuery = "SELECT * FROM Employees";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["EmployeeID"]}, {reader["FirstName"]}, {reader["LastName"]}, {reader["BirthDate"]}");
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Bir hata oluştu : " + ex.Message);
                }

            }
        }
    }
}
