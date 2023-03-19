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
