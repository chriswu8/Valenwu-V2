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
    internal class AppointmentDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=valenwu_db";

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

        public List<JObject> getAppointmentsForEOD(int month, int day, int year)
        {
            List<JObject> returnAppointments = new List<JObject>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query
                    MySqlCommand command = new MySqlCommand("SELECT appointment.TIME, patient.FIRST_NAME, patient.LAST_NAME, appointment.EXAM, invoice.TOTAL_PAID FROM `appointment` inner join patient on appointment.patient_ID = patient.ID inner join invoice on invoice.ID = appointment.invoice_ID where appointment.MONTH = @month and appointment.DAY = @day and appointment.YEAR = @year and invoice.FEE = 0", connection);

                    command.Parameters.AddWithValue("@month", month);
                    command.Parameters.AddWithValue("@day", day);
                    command.Parameters.AddWithValue("@year", year);



                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            JObject newAppointment = new JObject();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                newAppointment.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                            }



                            returnAppointments.Add(newAppointment);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return returnAppointments;
        }

        public List<JObject> getAppointmentsForPatientInnerJoin(int month, int day, int year)
        {
            List<JObject> returnPatients = new List<JObject>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query
                    MySqlCommand command = new MySqlCommand("SELECT appointment.ID, appointment.TIME, patient.FIRST_NAME, patient.LAST_NAME, appointment.EXAM, patient.PHONE, patient.EMAIL, appointment.invoice_ID FROM `appointment` inner join patient where appointment.patient_ID = patient.ID and appointment.MONTH = @month and appointment.DAY = @day and appointment.YEAR = @year", connection);

                    command.Parameters.AddWithValue("@month", month);
                    command.Parameters.AddWithValue("@day", day);
                    command.Parameters.AddWithValue("@year", year);



                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        

                        while (reader.Read())
                        {

                            JObject newAppointment = new JObject();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                newAppointment.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                            }

                            returnPatients.Add(newAppointment);
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            

            return returnPatients;
        }


        internal int addAppointmentByPatient(Appointment appointment)
        {
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("INSERT INTO `appointment`(`MONTH`, `DAY`, `YEAR`, `TIME`, `EXAM`, `FEE`, `patient_ID`, `invoice_ID`) VALUES (@month, @day, @year, @time, @exam, @fee, @patient_id, @invoice_id)", connection);

                    command.Parameters.AddWithValue("@month", appointment.Month);
                    command.Parameters.AddWithValue("@day", appointment.Day);
                    command.Parameters.AddWithValue("@year", appointment.Year);
                    command.Parameters.AddWithValue("@time", appointment.Time);
                    command.Parameters.AddWithValue("@exam", appointment.Exam);
                    command.Parameters.AddWithValue("@fee", appointment.Fee);
                    command.Parameters.AddWithValue("@patient_id", appointment.PatientID);
                    command.Parameters.AddWithValue("@invoice_id", appointment.InvoiceID);



                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return result;
        }

        internal int deleteOneAppointment(int appointmentID)
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

    }
}
