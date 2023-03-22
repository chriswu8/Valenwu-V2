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
    public partial class FormInvoice : Form
    {
        FormPatient formPatient;
        Patient parentPatient;
        BindingSource invoiceBinding = new BindingSource();
        InvoiceDAO invoiceDAO = new InvoiceDAO();
        public FormInvoice()
        {
            InitializeComponent();
        }

        public FormInvoice(FormPatient fp, Patient patient)
        {
            InitializeComponent();
            parentPatient = patient;
            formPatient = fp;
            displayAllInvoicesFromPatient(patient.ID);
            calculateTotalAmountDue(patient.ID);
        }

        private void calculateTotalAmountDue(int patientID)
        {
            List<JObject> totalInvoices = invoiceDAO.getAllInvoicesFromPatient(patientID);
            int totalAmount = 0;

            for (int i = 0; i < totalInvoices.Count(); i++)
            {
                totalAmount += Int32.Parse(totalInvoices[i]["FEE"].ToString());
            }

            formInvoice_richTextBox1.Text = totalAmount.ToString();
        }

        private void displayAllInvoicesFromPatient(int patientID)
        {
            invoiceBinding.DataSource = invoiceDAO.getAllInvoicesFromPatient(patientID);
            formInvoice_dataGridView.DataSource = invoiceBinding;
        }

        private void formInvoice_takePayment_Click(object sender, EventArgs e)
        {

        }
    }
}
