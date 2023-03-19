using MySql.Data.MySqlClient;
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


        internal int addAppointmentByPatient(Appointment appointment)
        {
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("INSERT INTO `appointment`(`MONTH`, `DAY`, `YEAR`, `TIME`, `EXAM`, `FEE`, `patient_ID`) VALUES (@month, @day, @year, @time, @exam, @fee, @patient_id)", connection);

                    command.Parameters.AddWithValue("@month", appointment.Month);
                    command.Parameters.AddWithValue("@day", appointment.Day);
                    command.Parameters.AddWithValue("@year", appointment.Year);
                    command.Parameters.AddWithValue("@time", appointment.Time);
                    command.Parameters.AddWithValue("@exam", appointment.Exam);
                    command.Parameters.AddWithValue("@fee", appointment.Fee);
                    command.Parameters.AddWithValue("@patient_id", appointment.PatientID);
                    
                    

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
