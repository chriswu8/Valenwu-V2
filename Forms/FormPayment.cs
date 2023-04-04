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

namespace Valenwu
{
    /// <summary>
    /// The FormPayment class contains methods for handling all payments for an invoice and a patient. It includes functions for taking and updating a payment.
    /// </summary>
    public partial class FormPayment : Form
    {
        // Declare / instantiate required objects
        private FormPatient formPatient;
        private FormInvoice formInvoice;
        private JObject currentInvoice;
        private InvoiceDAO invoiceDAO;

        private double hst = 0.05;
        private double pst = 0.07;

        private double totalPayment;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="fp"></param>
        public FormPayment(FormPatient fp)
        {
            InitializeComponent();
            formPatient = fp;
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="formInvoice"></param>
        /// <param name="currentInvoice"></param>
        public FormPayment(FormInvoice formInvoice, JObject currentInvoice)
        {
           
            InitializeComponent();
            invoiceDAO = new InvoiceDAO();
            this.formInvoice = formInvoice;
            this.currentInvoice = currentInvoice;
            updatePaymentSummary();
        }

        /// <summary>
        /// This method takes all paid invoices and calculates payment information from it. Taxes and fees and added to the total due.
        /// </summary>
        public void updatePaymentSummary()
        {
            totalPayment = Int32.Parse(currentInvoice["FEE"].ToString()) + (Int32.Parse(currentInvoice["FEE"].ToString()) * hst) + (Int32.Parse(currentInvoice["FEE"].ToString()) * pst);

            items_services_label.Text = currentInvoice["FEE"].ToString();
            
            hst_gst_label.Text = Math.Round(Int32.Parse(currentInvoice["FEE"].ToString()) * hst, 2).ToString();
            pst_label.Text = Math.Round(Int32.Parse(currentInvoice["FEE"].ToString()) * pst, 2).ToString();

            total_payment.Text = totalPayment.ToString();

            primary_payment_type.Text = totalPayment.ToString();
        }

        /// <summary>
        /// This method updates the payment details of an invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formPayment_save_Click(object sender, EventArgs e)
        {
            int paymentSuccess = invoiceDAO.updateInvoice(currentInvoice, totalPayment);

            if (paymentSuccess >= 1)
            {
                MessageBox.Show("Thank your for your payment!");
            }

            formInvoice.displayAllInvoicesFromPatientOnLoad();
            this.Close();
        }
    }
}
