// documentation for 

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
    /// <summary>
    /// Separates queries / Invoice-related operations from business logic
    /// </summary>
    public class InvoiceDAO
    {
        // the connection string for the database
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=valenwu_db";

        /// <summary>
        /// Adds a single Invoice to the 'invoice' table in the database and returns its ID
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public int addOneInvoice(Invoice invoice)
        {
            int result = 0;
            int testid = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // opens the connection
                    connection.Open();

                    // Creates a new MySqlCommand object with the SQL query and the connection to insert a new record into the "invoice" table with the patient ID, service ID, fee, and total amount paid parameters.
                    MySqlCommand command = new MySqlCommand("INSERT INTO `invoice`(`patient_ID`, `service_ID`, `FEE`, `TOTAL_PAID`) VALUES (@patientID, @serviceID, @fee, @total_paid)", connection);

                    // columns in the invoice table, and their values are set to invoice.patientID, invoice.serviceID, and invoice.fee represent the patient ID, service ID, and fee of the invoice object
                    command.Parameters.AddWithValue("@patientID", invoice.patientID);
                    command.Parameters.AddWithValue("@serviceID", invoice.serviceID);
                    command.Parameters.AddWithValue("@fee", invoice.fee);
                    command.Parameters.AddWithValue("@total_paid", 0);

                    // executes the SQL command defined in the MySqlCommand object and saves the number of rows affected in the database into results
                    result = command.ExecuteNonQuery();

                    // returns the ID of the last inserted row in the table
                    testid = (int)command.LastInsertedId;
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            

            return testid;
        }

        /// <summary>
        /// Returns the list of JObject objects containing the invoice data for the specified patient ID
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public List<JObject> getAllInvoicesFromPatient(int patientID)
        {
            // Initializes an empty list of JObject objects to hold the returned invoice data for the patient
            List<JObject> returnInvoices = new List<JObject>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query
                    MySqlCommand command = new MySqlCommand("SELECT invoice.ID, patient.FIRST_NAME, patient.LAST_NAME, service.CODE, invoice.FEE, invoice.TOTAL_PAID FROM `invoice` inner join service on service.ID = invoice.service_ID inner join patient on patient.ID = invoice.patient_ID where invoice.patient_ID = @patientID AND invoice.FEE > 0", connection);

                    command.Parameters.AddWithValue("@patientID", patientID);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

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

        
        /// <summary>
        /// Method to delete an invoice when an appointment is deleted.
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <returns></returns>
        public int deleteInvoiceFromAppointment(int invoiceID)
        {
            // Variable to hold the number of invoices that were deleted
            int result = 0;

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

        /// <summary>
        /// Update an invoice with a new payment amount.
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="totalPayment"></param>
        /// <returns></returns>
        public int updateInvoice(JObject invoice, double totalPayment)
        {
            // Variable to hold number of invoices that were updated.
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("UPDATE `invoice` SET `FEE`= @fee, `TOTAL_PAID` = @total_paid  WHERE `ID` = @id", connection);

                    
                    command.Parameters.AddWithValue("@fee", 0);
                    command.Parameters.AddWithValue("@total_paid", totalPayment);
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
