using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Valenwu.DAO;
using Valenwu.Entities;

namespace Valenwu
{
    /// <summary>
    /// The FormPatientInfo class is responsible for displaying the form to update patient details. Contained within this class are methods to perform CRUD operations for patient information.
    /// </summary>
    public partial class FormPatientInfo : Form
    {
        // Declare and instantiate required attributes and objects to communicate with the database.
        BindingSource patientBinding = new BindingSource();
        PatientDAO patientDAO = new PatientDAO();
        AppointmentDAO appointmentDAO = new AppointmentDAO();
        FormPatient formPatient;
        Patient patient;
        List<string> titles = new List<string>() { "Mr.", "Mrs.", "Ms.", "Miss", "Dr.", "Prof." };

        /// <summary>
        /// Constructor which takes in a FormPatient.
        /// </summary>
        /// <param name="fp"></param>
        public FormPatientInfo(FormPatient fp)
        {
            InitializeComponent();
            formPatient = fp;
            TitlesComboBox.Items.AddRange(titles.ToArray());
        }

        /// <summary>
        /// Constructor which takes in a custom object.
        /// </summary>
        /// <param name="obj"></param>
        public FormPatientInfo(JObject obj)
        {
            InitializeComponent();
            TitlesComboBox.Items.AddRange(titles.ToArray());

            // selected Patient from FormPage
            Patient thePatient = patientDAO.getOnePatient(Int32.Parse(obj["patient_ID"].ToString()));

            // Set patient object to textbox label
            LastNameTextbox.Text = thePatient.LastName;
            FirstNameTextbox.Text = thePatient.FirstName;
            MiddleNameTextbox.Text = thePatient.MiddleName;
            AddressTextbox.Text = thePatient.Address;
            ProvinceTextbox.Text = thePatient.Province;
            CityTextbox.Text = thePatient.City;
            PostalCodeTextbox.Text = thePatient.PostalCode;
            BirthdayTextbox.Text = thePatient.BirthDate;
            PHNTextbox.Text = thePatient.PHN;
            PhoneTextbox.Text = thePatient.Phone;
            EmailTextbox.Text = thePatient.Email;
            OccupationTextbox.Text = thePatient.Occupation;
            InsuranceTextbox.Text = thePatient.Insurance;
            LastVistTextbox.Text = thePatient.LastVisit;
            FirstVisitTextbox.Text = thePatient.FirstVisit;
            MiscTextbox.Text = thePatient.Misc;

            patientBinding.DataSource = appointmentDAO.getAppointmentFromPatientID(Int32.Parse(obj["ID"].ToString()));

            dataGridViewDiary.DataSource = patientBinding;

        }


        /// <summary>
        /// Set a the FormPatient textbox labels with information from a patient object.
        /// </summary>
        /// <param name="p"></param>
        public void SetPatient(Patient p)
        {
            patient = p;

            // Populate the form fields with the selected patient's information
            LastNameTextbox.Text = patient.LastName;
            FirstNameTextbox.Text = patient.FirstName;
            MiddleNameTextbox.Text = patient.MiddleName;
            AddressTextbox.Text = patient.Address;
            ProvinceTextbox.Text = patient.Province;
            CityTextbox.Text = patient.City;
            PostalCodeTextbox.Text = patient.PostalCode;
            BirthdayTextbox.Text = patient.BirthDate;
            PHNTextbox.Text = patient.PHN;
            PhoneTextbox.Text = patient.Phone;
            EmailTextbox.Text = patient.Email;
            OccupationTextbox.Text = patient.Occupation;
            InsuranceTextbox.Text = patient.Insurance;
            LastVistTextbox.Text = patient.LastVisit;
            FirstVisitTextbox.Text = patient.FirstVisit;
            MiscTextbox.Text = patient.Misc;
        }

        /// <summary>
        /// Save a patient to the database upon the Save button press.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_patient_info_save_Click(object sender, EventArgs e)
        {
            if (sender == form_patient_info_save)
            {
                // Assign patient object with information from the form.
                Patient patient = new Patient
                {
                    LastName = LastNameTextbox.Text,
                    FirstName = FirstNameTextbox.Text,
                    MiddleName = MiddleNameTextbox.Text,
                    Address = AddressTextbox.Text,
                    Province = ProvinceTextbox.Text,
                    City = CityTextbox.Text,
                    PostalCode = PostalCodeTextbox.Text,
                    BirthDate = BirthdayTextbox.Text,
                    PHN = PHNTextbox.Text,
                    Phone = PhoneTextbox.Text,
                    Email = EmailTextbox.Text,
                    Occupation = OccupationTextbox.Text,
                    Insurance = InsuranceTextbox.Text,
                    LastVisit = LastVistTextbox.Text,
                    FirstVisit = FirstVisitTextbox.Text,
                    Misc = MiscTextbox.Text
                };

                // Update the patient record in the database
                int result = patientDAO.addOnePatient(patient);
                MessageBox.Show(result + " patient updated!");

                // Refresh the DataGridView control on the FormPatient form
                formPatient.DisplayAllPatientsOnLoad();
            }

            this.Close();
        }
    }
}
