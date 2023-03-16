using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valenwu.Entities;

namespace Valenwu.DAO
{
    public class ServiceDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=valenwu_db";
        public List<Service> getAllServices()
        {
            List<Service> returnServices = new List<Service>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query
                    MySqlCommand command = new MySqlCommand("SELECT * FROM SERVICE", connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Service s = new Service
                            {
                                Id = reader.GetInt32(0),
                                Code = reader.GetString(1),
                                Fee = reader.GetInt32(2),
                                Description = reader.GetString(3)
                                
                            };

                            returnServices.Add(s);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return returnServices;
        }

        internal int addOneService(Service service)
        {
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("INSERT INTO `service`(`CODE`, `FEE`, `DESCRIPTION`) VALUES (@code, @fee, @description)", connection);

                    command.Parameters.AddWithValue("@code", service.Code);
                    command.Parameters.AddWithValue("@fee", service.Fee);
                    command.Parameters.AddWithValue("@description", service.Description);

                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return result;
        }
    }
}
