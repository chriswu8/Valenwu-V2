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
    public class PatientDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=valenwu_db";

        public List<Patient> getAllPatients()
        {
            List<Patient> returnPatients = new List<Patient>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query
                    MySqlCommand command = new MySqlCommand("SELECT * FROM PATIENT", connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Patient p = new Patient
                            {
                                ID = reader.GetInt32(0),
                                LastName = reader.GetString(1),
                                FirstName = reader.GetString(2),
                                MiddleName = reader.GetString(3),
                                Address = reader.GetString(4),
                                Province = reader.GetString(5),
                                City = reader.GetString(6),
                                PostalCode = reader.GetString(7),
                                BirthDate = reader.GetString(8),
                                PHN = reader.GetString(9),
                                Phone = reader.GetString(10),
                                Email = reader.GetString(11),
                                Occupation = reader.GetString(12),
                                Insurance = reader.GetString(13),
                                Misc = reader.GetString(14),
                                LastVisit = reader.GetString(15),
                                FirstVisit = reader.GetString(16)
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


        internal int addOnePatient(Patient patient)
        {
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("INSERT INTO `patient`(`LAST_NAME`, `FIRST_NAME`, `MIDDLE_NAME`, `ADDRESS`, `PROVINCE`, `CITY`, `POSTAL_CODE`, `BIRTH_DATE`, `PHN`, `PHONE`, `EMAIL`, `OCCUPATION`, `INSURANCE`, `MISC`, `LAST_VISIT`, `FIRST_VISIT`) VALUES (@lastname, @firstname, @middlename, @address, @province, @city, @postalcode, @birthdate, @phn, @phone, @email, @occupation, @insurance, @misc, @lastvisit, @firstvisit)", connection);

                    command.Parameters.AddWithValue("@lastname", patient.LastName);
                    command.Parameters.AddWithValue("@firstname", patient.FirstName);
                    command.Parameters.AddWithValue("@middlename", patient.MiddleName);
                    command.Parameters.AddWithValue("@address", patient.Address);
                    command.Parameters.AddWithValue("@province", patient.Province);
                    command.Parameters.AddWithValue("@city", patient.City);
                    command.Parameters.AddWithValue("@postalcode", patient.PostalCode);
                    command.Parameters.AddWithValue("@birthdate", patient.BirthDate);
                    command.Parameters.AddWithValue("@phn", patient.PHN);
                    command.Parameters.AddWithValue("@phone", patient.Phone);
                    command.Parameters.AddWithValue("@email", patient.Email);
                    command.Parameters.AddWithValue("@occupation", patient.Occupation);
                    command.Parameters.AddWithValue("@insurance", patient.Insurance);
                    command.Parameters.AddWithValue("@misc", patient.Misc);
                    command.Parameters.AddWithValue("@lastvisit", patient.LastVisit);
                    command.Parameters.AddWithValue("@firstvisit", patient.FirstVisit);

                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return result;
        }

        public int deleteOnePatient(Patient patient)
        {
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("DELETE FROM `patient` WHERE `ID` = @id", connection);

                    command.Parameters.AddWithValue("@id", patient.ID);

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