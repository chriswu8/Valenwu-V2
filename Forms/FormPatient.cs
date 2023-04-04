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
    /// The FormPatient class contains methods for retrieving and performing CRUD operations on a Patient. 
    /// </summary>
    public partial class FormPatient : Form
    {
        // Declare and instantiate required attributes and code to communicate with the database.
        BindingSource patientBinding = new BindingSource();
        PatientDAO patientDAO = new PatientDAO();

        /// <summary>
        /// Default constructor
        /// </summary>
        public FormPatient() {
            InitializeComponent();
            DisplayAllPatientsOnLoad();
        }

        /// <summary>
        /// This is run when this form is instantiated.
        /// All patients in the database are retrieved and displayed onto the FormPatient.
        /// </summary>
        public void DisplayAllPatientsOnLoad()
        {
            patientBinding.DataSource = patientDAO.getAllPatients();

            // Attach data source into a data grid view
            dataGridView1.DataSource = patientBinding;
        }

        /// <summary>
        /// This method displays an individual patient.
        /// </summary>
        /// <param name="patientDAO"></param>
        public void DisplayAllPatients(PatientDAO patientDAO)
        {
            patientBinding.DataSource = patientDAO.getAllPatients();
            dataGridView1.DataSource = patientBinding; 
        }

        /// <summary>
        /// This method handles all button presses for a FormPatient.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patient_button_Click(object sender, EventArgs e)
        {
            if (sender != exit_patient_button)
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    // Error handling
                    MessageBox.Show("You have selected a cell. Please select a row (patient).");
                    return;
                }
            }

            if (sender == add_new_patient)
            {
                // Open the FormPatientInfo
                FormPatientInfo fp = new FormPatientInfo(this);
                fp.MdiParent = this.MdiParent;
                fp.Show();
                DisplayAllPatientsOnLoad();
            }
            else if (sender == edit_patient)
            {
                // Retrieve the selected Patient object from the DataGridView control
                Patient selectedPatient = (Patient)dataGridView1.SelectedRows[0].DataBoundItem;

                // Create a new instance of the FormPatientInfo form with the FormPatient object as its parameter
                FormPatientInfo fp = new FormPatientInfo(this);

                // Set the MdiParent property of the new form and display it
                fp.MdiParent = this.MdiParent;

                // Set the Patient property of the new form with the selected Patient object
                fp.SetPatient(selectedPatient);

                fp.Show();
            }
            else if (sender == delete_patient)
            {
                // Retrieve the selected Patient object from the DataGridView control
                Patient selectedPatient = (Patient)dataGridView1.SelectedRows[0].DataBoundItem;

                // Prompt the user to confirm the deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this patient?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If the user confirms the deletion, delete the patient record from the database
                if (result == DialogResult.Yes)
                {
                    int rowsAffected = patientDAO.deleteOnePatient(selectedPatient);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Patient deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayAllPatientsOnLoad();
                    }
                    else
                    {
                        MessageBox.Show("This patient currently has an appointment or outstanding invoice.\nCannot delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (sender == view_invoice)
            {
                // Open the FormInvoice for the selected patient.
                Patient selectedPatient = (Patient)dataGridView1.SelectedRows[0].DataBoundItem;
                FormInvoice fp = new FormInvoice(this, selectedPatient);
                fp.MdiParent = this.MdiParent;
                fp.Show();
            }
            else if (sender ==  schedule_patient)
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("You have selected a cell. Please select a row (patient) before scheduling.");
                    return;
                }

                Patient selectedPatient = (Patient)dataGridView1.SelectedRows[0].DataBoundItem;
                FormConfirmAppointment fp = new FormConfirmAppointment(selectedPatient);
                fp.MdiParent = this.MdiParent;
                fp.Show();
            }
            else if (sender == exit_patient_button)
            {
                this.Close();
            }
        }
    }
}
