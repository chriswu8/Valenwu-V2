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

        private void add_new_patient_Click(object sender, EventArgs e)
        {
            FormPatientInfo fp = new FormPatientInfo(this);
            fp.MdiParent = this.MdiParent;
            fp.Show();
            DisplayAllPatientsOnLoad();
        }

        private void take_payment_Click(object sender, EventArgs e)
        {
            Patient selectedPatient = (Patient)dataGridView1.SelectedRows[0].DataBoundItem;
            FormInvoice fp = new FormInvoice(this, selectedPatient);
            fp.MdiParent = this.MdiParent;
            fp.Show();
        }

        private void schedule_patient_Click(object sender, EventArgs e)
        {
            /*FormConfirmAppointment fp = new FormConfirmAppointment();
            fp.MdiParent = this.MdiParent;
            fp.Show();*/

            // select patient from data grid view
            // pass to cofirm appt form
            // 

            Patient selectedPatient = (Patient)dataGridView1.SelectedRows[0].DataBoundItem;

            FormConfirmAppointment fp = new FormConfirmAppointment(selectedPatient);
            fp.MdiParent = this.MdiParent;
            fp.Show();

        }
    }
}
