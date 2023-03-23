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

        internal int addOneInvoice(Invoice invoice)
        {
            int result = 0;
            int testid = 0;

            
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("INSERT INTO `invoice`(`patient_ID`, `service_ID`, `FEE`) VALUES (@patientID, @serviceID, @fee)", connection);

                    command.Parameters.AddWithValue("@patientID", invoice.patientID);
                    command.Parameters.AddWithValue("@serviceID", invoice.serviceID);
                    command.Parameters.AddWithValue("@fee", invoice.fee);


                    result = command.ExecuteNonQuery();
                    testid = (int)command.LastInsertedId;
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            

            return testid;
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
                    MySqlCommand command = new MySqlCommand("SELECT invoice.ID, patient.FIRST_NAME, patient.LAST_NAME, service.CODE, invoice.FEE FROM `invoice` inner join service on service.ID = invoice.service_ID inner join patient on patient.ID = invoice.patient_ID where invoice.patient_ID = @patientID AND invoice.FEE > 0", connection);

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

        

        internal int deleteInvoiceFromAppointment(int invoiceID)
        {
            int result = 0;

            // TIME, FIRST_NAME, LAST_NAME, "EXAM", "PHONE", "EMAIL"
            /*string firstName = patientDetails["FIRST_NAME"].ToString();
            string lastName = patientDetails["LAST_NAME"].ToString();
            string phone = patientDetails["PHONE"].ToString();
            string email = patientDetails["EMAIL"].ToString();*/

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("DELETE FROM `invoice` WHERE ID = @id", connection);

                    command.Parameters.AddWithValue("@id", invoiceID);

                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return result;
        }

        public int updateInvoice(JObject invoice)
        {
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("UPDATE `invoice` SET `FEE`= @fee WHERE `ID` = @id", connection);

                    
                    command.Parameters.AddWithValue("@fee", 0);
                    command.Parameters.AddWithValue("@id", invoice["ID"]);
                    

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
