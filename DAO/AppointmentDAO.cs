using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Valenwu.Entities;

namespace Valenwu.DAO
{
    /// <summary>
    /// Separates queries / Appointment-related operations from business logic
    /// </summary>
    internal class AppointmentDAO
    {
        // the connection string for the database
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=valenwu_db";

        /// <summary>
        /// Get a corresponding appointment for a patient.
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<Appointment> getAppointmentsForPatient(int month, int day, int year)
        {
            List<Appointment> returnPatients = new List<Appointment>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query
                    MySqlCommand command = new MySqlCommand("SELECT * FROM APPOINTMENT WHERE MONTH = @month AND DAY = @day AND YEAR = @year", connection);

                    command.Parameters.AddWithValue("@month", month);
                    command.Parameters.AddWithValue("@day", day);
                    command.Parameters.AddWithValue("@year", year);



                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Appointment p = new Appointment
                            {
                                ID = reader.GetInt32(0),
                                Month = reader.GetString(1),
                                Day = reader.GetString(2),
                                Year = reader.GetString(3),
                                Time = reader.GetString(4),
                                Exam = reader.GetString(5),
                                Fee = reader.GetString(6),
                                PatientID = reader.GetInt32(7)
                            };

                            returnPatients.Add(p);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return returnPatients;
        }

        /// <summary>
        ///  Retrieve appointments for a specific patient ID
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public List<Appointment> getAppointmentFromPatientID(int patientID)
        {
            List<Appointment> returnAppointments= new List<Appointment>();

            try 
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Opening the connection
                    connection.Open();

                    // Define the SQL query
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `appointment` WHERE appointment.patient_ID = @id", connection);

                    // Sets the value of the parameter named "@id" in the MySqlCommand object to the value of the patientID variable. This parameter is used to filter the results based on the given patient ID.
                    command.Parameters.AddWithValue("@id", patientID);
                   
                    // reads the results of the SQL query via the MySqlDataReader 
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // loop executs as long as there are rows left to read
                        while (reader.Read())
                        {
                            Appointment p = new Appointment
                            {
                                ID = reader.GetInt32(0),
                                Month = reader.GetString(1),
                                Day = reader.GetString(2),
                                Year = reader.GetString(3),
                                Time = reader.GetString(4),
                                Exam = reader.GetString(5),
                                Fee = reader.GetString(6),
                                PatientID = reader.GetInt32(7),
                                InvoiceID = reader.GetInt32(8)
                            };
                            //  add this Appointment object to the returnAppointments list.
                            returnAppointments.Add(p);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            // returns the list of Appointment objects that were read from the database
            return returnAppointments;
        }

        /// <summary>
        /// Returns a list of JObject representing appointments. 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<JObject> getAppointmentsForEOD(int month, int day, int year)
        {
            // Create a new list of JObject to store the retrieved appointments
            List<JObject> returnAppointments = new List<JObject>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Opens the connection
                    connection.Open();

                    // An SQL query that selects appointment time, patient's first and last name, exam code, and the total amount paid from three tables: "appointment", "patient", and "invoice".
                    MySqlCommand command = new MySqlCommand("SELECT appointment.TIME, patient.FIRST_NAME, patient.LAST_NAME, appointment.EXAM, invoice.TOTAL_PAID FROM `appointment` inner join patient on appointment.patient_ID = patient.ID inner join invoice on invoice.ID = appointment.invoice_ID where appointment.MONTH = @month and appointment.DAY = @day and appointment.YEAR = @year and invoice.FEE = 0", connection);

                    // Add parameters to the MySqlCommand object command (@month, @day, and @year will be replaced by the actual values when the query executes).
                    command.Parameters.AddWithValue("@month", month);
                    command.Parameters.AddWithValue("@day", day);
                    command.Parameters.AddWithValue("@year", year);


                    // Executes the SQL query and reads the results using a MySqlDataReader object
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // iterates through each row of the result set
                        while (reader.Read())
                        {
                            // iterates through each ROW of the result set
                            JObject newAppointment = new JObject();

                            // iterates through each COLUMN of the row
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                // key-value pair added to the JObject; key is the name of the column;  value is the value of the column (a string)
                                newAppointment.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                            }
                            // JObject added to the returnAppointments list
                            returnAppointments.Add(newAppointment);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            // JObjects list returned when all rows processed
            return returnAppointments;
        }

        /// <summary>
        /// Retrieves appointments for a specific date by querying the appointment and patient tables with an inner join
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<JObject> getAppointmentsForPatientInnerJoin(int month, int day, int year)
        {
            // list of JObject; JObject contains appointment details for a specific patient    
            List<JObject> returnPatients = new List<JObject>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // open the connection
                    connection.Open();

                    // MySqlCommand object created with an SQL query that joins the appointment and patient tables on the patient_ID field and filters by month, day, and year
                    MySqlCommand command = new MySqlCommand("SELECT appointment.ID, appointment.TIME, patient.FIRST_NAME, patient.LAST_NAME, appointment.EXAM, patient.PHONE, patient.EMAIL, appointment.invoice_ID, appointment.patient_ID FROM `appointment` inner join patient where appointment.patient_ID = patient.ID and appointment.MONTH = @month and appointment.DAY = @day and appointment.YEAR = @year", connection);

                    // @month, @day, and @year parameters are assigned values
                    command.Parameters.AddWithValue("@month", month);
                    command.Parameters.AddWithValue("@day", day);
                    command.Parameters.AddWithValue("@year", year);

                    // MySqlDataReader object is created
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        //  iterates over each row of the reader
                        while (reader.Read())
                        {
                            // a new JObject created for each row
                            JObject newAppointment = new JObject();

                            // extracts the data from each column 
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                newAppointment.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                            }
                            // JObject added to returnPatients list
                            returnPatients.Add(newAppointment);
                        }
                    }
                    // close the connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            // returnPatients list is returned
            return returnPatients;
        }

        /// <summary>
        /// Adds an appointment to the database for a given patient.
        /// Takes an Appointment object and returns an integer that indicates the number of rows affected by the SQL command
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        internal int addAppointmentByPatient(Appointment appointment)
        {
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // opens the connection
                    connection.Open();

                    //  appointment month, day, year, time, exam, fee, patient ID, and invoice ID are inserted into the 'appointment' table of the database
                    MySqlCommand command = new MySqlCommand("INSERT INTO `appointment`(`MONTH`, `DAY`, `YEAR`, `TIME`, `EXAM`, `FEE`, `patient_ID`, `invoice_ID`) VALUES (@month, @day, @year, @time, @exam, @fee, @patient_id, @invoice_id)", connection);

                    // set the values of the parameters in the command to the values of the properties of the appointment object
                    command.Parameters.AddWithValue("@month", appointment.Month);
                    command.Parameters.AddWithValue("@day", appointment.Day);
                    command.Parameters.AddWithValue("@year", appointment.Year);
                    command.Parameters.AddWithValue("@time", appointment.Time);
                    command.Parameters.AddWithValue("@exam", appointment.Exam);
                    command.Parameters.AddWithValue("@fee", appointment.Fee);
                    command.Parameters.AddWithValue("@patient_id", appointment.PatientID);
                    command.Parameters.AddWithValue("@invoice_id", appointment.InvoiceID);

                    // executes the SQL command and returns the number of rows affected by the command
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
        /// Delete an appointment by its ID
        /// </summary>
        /// <param name="appointmentID"></param>
        /// <returns></returns>
        internal int deleteOneAppointment(int appointmentID)
        {
            // variable to store number of deleted rows
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // opens the connection
                    connection.Open();

                    // Define SQL query
                    MySqlCommand command = new MySqlCommand("DELETE FROM `appointment` WHERE ID = @id", connection);

                    command.Parameters.AddWithValue("@id", appointmentID);

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
        /// Update an appointment.
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        internal int updateOneAppointment(Appointment appointment)
        {
            // variable to store number of updated rows
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("UPDATE `appointment` SET `MONTH`=@month,`DAY`=@day,`YEAR`=@year,`TIME`=@time,`EXAM`=@exam,`FEE`=@fee WHERE appointment.ID = 21", connection);

                    // Set parameters with values in the MySQL database
                    command.Parameters.AddWithValue("@id", appointment.ID);
                    command.Parameters.AddWithValue("@month", appointment.Month);
                    command.Parameters.AddWithValue("@day", appointment.Day);
                    command.Parameters.AddWithValue("@year", appointment.Year);
                    command.Parameters.AddWithValue("@time", appointment.Time);
                    command.Parameters.AddWithValue("@exam", appointment.Exam);
                    command.Parameters.AddWithValue("@fee", appointment.Fee);

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
