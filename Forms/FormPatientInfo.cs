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
        FormPatient formPatient;

        public FormPatientInfo(FormPatient f)
        {
            InitializeComponent();
            formPatient = f;
        }

        private void form_patient_info_save_Click(object sender, EventArgs e)
        {
            PatientDAO patientDAO = new PatientDAO();
            

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

            
            int result = patientDAO.addOnePatient(patient);
            MessageBox.Show(result + " new patient added!");

            patientBinding.DataSource = patientDAO.getAllPatients();

            // pass the data from the patientDAO into the constructor

            formPatient.DisplayAllPatients(patientDAO);

            this.Close();

        }
    }
}
