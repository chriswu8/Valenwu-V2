using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valenwu.Entities;

namespace Valenwu.DAO
{
    internal class InvoiceDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=valenwu_db";

        internal int addOneInvoice(int servicePrimaryKey, int patientPrimaryKey)
        {
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("INSERT INTO `invoice`(`patient_ID`, `service_ID`) VALUES (@patientID, @serviceID)", connection);

                    command.Parameters.AddWithValue("@patientID", patientPrimaryKey);
                    command.Parameters.AddWithValue("@serviceID", servicePrimaryKey);
                    

                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return result;
        }

        public List<JObject> getAllInvoicesFromPatient(int patientID)
        {
            List<JObject> returnInvoices = new List<JObject>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query
                    MySqlCommand command = new MySqlCommand("SELECT patient.FIRST_NAME, patient.LAST_NAME, service.CODE, service.FEE FROM `invoice` inner join service on service.ID = invoice.service_ID inner join patient on patient.ID = invoice.patient_ID where invoice.patient_ID = @patientID", connection);

                    command.Parameters.AddWithValue("@patientID", patientID);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            /*Service s = new Service
                            {
                                Id = reader.GetInt32(0),
                                Code = reader.GetString(1),
                                Fee = reader.GetInt32(2),
                                Description = reader.GetString(3)

                            };*/

                            JObject newInvoice = new JObject();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                newInvoice.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                            }

                            

                            returnInvoices.Add(newInvoice);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            

            return returnInvoices;
        }



    }
}
