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

        internal int addOneService(Service service)
        {
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("INSERT INTO `service`(`CODE`, `FEE`, `DESCRIPTION`) VALUES (@code, @fee, @description)", connection);

                    command.Parameters.AddWithValue("@lastname", service.Code);
                    command.Parameters.AddWithValue("@firstname", service.Fee);
                    command.Parameters.AddWithValue("@middlename", service.Description);

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
