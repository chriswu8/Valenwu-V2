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
    public partial class FormPatient : Form
    {
        BindingSource patientBinding = new BindingSource();
        PatientDAO patientDAO = new PatientDAO();
        public FormPatient() {
            InitializeComponent();
            DisplayAllPatientsOnLoad();
        }

        public void DisplayAllPatientsOnLoad()
        {
            patientBinding.DataSource = patientDAO.getAllPatients();
            dataGridView1.DataSource = patientBinding;
        }

        public void DisplayAllPatients(PatientDAO patientDAO)
        {
            patientBinding.DataSource = patientDAO.getAllPatients();
            dataGridView1.DataSource = patientBinding; 
        }



        private void patient_button_Click(object sender, EventArgs e)
        {
            if (sender != exit_patient_button)
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("You have selected a cell. Please select a row (patient).");
                    return;
                }
            }

            if (sender == add_new_patient)
            {
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
