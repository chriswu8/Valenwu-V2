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
    /// Separates queries / Patient-related operations from business logic
    /// </summary>
    public class PatientDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=valenwu_db";

        /// <summary>
        /// Returns a list of all patients stored in the Patient table.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Adds one patient to the Patient table by its Patient object.
        /// </summary>
        /// <returns></returns>
        internal int addOnePatient(Patient patient)
        {
            // Stores the number of rows that were changed in the Patient table.
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand("INSERT INTO `patient`(`LAST_NAME`, `FIRST_NAME`, `MIDDLE_NAME`, `ADDRESS`, `PROVINCE`, `CITY`, `POSTAL_CODE`, `BIRTH_DATE`, `PHN`, `PHONE`, `EMAIL`, `OCCUPATION`, `INSURANCE`, `MISC`, `LAST_VISIT`, `FIRST_VISIT`) VALUES (@lastname, @firstname, @middlename, @address, @province, @city, @postalcode, @birthdate, @phn, @phone, @email, @occupation, @insurance, @misc, @lastvisit, @firstvisit)", connection);

                    // Add values to each corresponding columns
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

        /// <summary>
        /// Delete one patient by its corresponding patient object
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public int deleteOnePatient(Patient patient)
        {
            // Variable to return number of new rows that were deleted.
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Delete patient with corresponding ID
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

        /// <summary>
        /// Updates a patient by the updated Patient object.
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public int updateOnePatient(Patient patient)
        {
            int result = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL code to update a patient
                    MySqlCommand command = new MySqlCommand("UPDATE `patient` SET `LAST_NAME` = @lastname, `FIRST_NAME` = @firstname, `MIDDLE_NAME` = @middlename, `ADDRESS` = @address, `PROVINCE` = @province, `CITY` = @city, `POSTAL_CODE` = @postalcode, `BIRTH_DATE` = @birthdate, `PHN` = @phn, `PHONE` = @phone, `EMAIL` = @email, `OCCUPATION` = @occupation, `INSURANCE` = @insurance, `MISC` = @misc, `LAST_VISIT` = @lastvisit, `FIRST_VISIT` = @firstvisit WHERE `ID` = @id", connection);

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

        /// <summary>
        /// Get one patient by their patient ID.
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public Patient getOnePatient(int patientID)
        {
            // Variable to store updated patient object
            Patient patient = new Patient();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Define the SQL query (@id is the user-selected appointment-directed patient's id)
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `patient` WHERE patient.ID = @id;", connection);

                    // Assign variable id to patientID
                    command.Parameters.AddWithValue("@id", patientID);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patient = new Patient
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
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return patient;
        }
    }
}