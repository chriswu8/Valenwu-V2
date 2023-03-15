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
            FormPayment fp = new FormPayment(this);
        }
    }
}
