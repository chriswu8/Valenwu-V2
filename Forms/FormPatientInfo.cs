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
    public partial class FormPatientInfo : Form
    {
        BindingSource patientBinding = new BindingSource();
        PatientDAO patientDAO = new PatientDAO();
        FormPatient formPatient;
        Patient patient;
        List<string> titles = new List<string>() { "Mr.", "Mrs.", "Ms.", "Miss", "Dr.", "Prof." };


        public FormPatientInfo(FormPatient fp)
        {
            InitializeComponent();
            formPatient = fp;
            TitlesComboBox.Items.AddRange(titles.ToArray());
        }


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

        private void form_patient_info_save_Click(object sender, EventArgs e)
        {
            
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

            // merge to main

            // Update the patient record in the database
            int result = patientDAO.addOnePatient( patient );
            MessageBox.Show(result + " patient updated!");

            // Refresh the DataGridView control on the FormPatient form
            formPatient.DisplayAllPatientsOnLoad();

            this.Close();
        }

    }

}
