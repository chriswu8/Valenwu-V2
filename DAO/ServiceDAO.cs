using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valenwu.Entities;

namespace Valenwu.DAO
{
    /// <summary>
    /// Separates queries / Service-related operations from business logic
    /// </summary>
    public class ServiceDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=valenwu_db";

        /// <summary>
        /// Returns a list of all services stored in the Service table.
        /// </summary>
        /// <returns></returns>
        public List<Service> getAllServices()
        {
            // Initialize a list of Services to be returned.
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

        /// <summary>
        /// Get one service from the Service table by its service code.
        /// </summary>
        /// <param name="serviceCode"></param>
        /// <returns></returns>
        public Service getOneService(string serviceCode)
        {
            // Initialize a service to be returned.
            Service service = new Service();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query
                    MySqlCommand command = new MySqlCommand("SELECT `ID`, `CODE`, `FEE`, `DESCRIPTION` FROM `service` WHERE CODE = @serviceID", connection);

                    command.Parameters.AddWithValue("@serviceID", serviceCode);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Create temporary service object and fill in parameters from service from Service table
                            Service s = new Service
                            {
                                Id = reader.GetInt32(0),
                                Code = reader.GetString(1),
                                Fee = reader.GetInt32(2),
                                Description = reader.GetString(3)

                            };

                            service = s;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return service;
        }

        /// <summary>
        /// Add one service to the service table.
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        internal int addOneService(Service service)
        {
            // Variable to return number of new rows that were added.
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Delete all records with the same code
                    MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM `service` WHERE `CODE` = @code", connection);
                    deleteCommand.Parameters.AddWithValue("@code", service.Code);
                    deleteCommand.ExecuteNonQuery();

                    // Insert the new service record
                    MySqlCommand insertCommand = new MySqlCommand("INSERT INTO `service`(`CODE`, `FEE`, `DESCRIPTION`) VALUES (@code, @fee, @description)", connection);
                    insertCommand.Parameters.AddWithValue("@code", service.Code);
                    insertCommand.Parameters.AddWithValue("@fee", service.Fee);
                    insertCommand.Parameters.AddWithValue("@description", service.Description);
                    result = insertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Delete one service by its ID.
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        internal int deleteOneService(Service service)
        {
            // Variable to display number of columns that were modified.
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Define SQL Query
                    MySqlCommand command = new MySqlCommand("DELETE FROM `service` WHERE `ID` = @id", connection);

                    command.Parameters.AddWithValue("@id", service.Id);

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
