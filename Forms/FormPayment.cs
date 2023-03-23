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
    public partial class FormPayment : Form
    {
        private FormPatient formPatient;
        private FormInvoice formInvoice;
        private JObject currentInvoice;
        private InvoiceDAO invoiceDAO;

        private double hst = 0.05;
        private double pst = 0.07;

        private double totalPayment;


        public FormPayment(FormPatient fp)
        {
            InitializeComponent();
            formPatient = fp;
        }

        public FormPayment(FormInvoice formInvoice, JObject currentInvoice)
        {
            // ID, FIRST_NAME, LAST_NAME, CODE, FEE

            InitializeComponent();
            invoiceDAO = new InvoiceDAO();
            this.formInvoice = formInvoice;
            this.currentInvoice = currentInvoice;
            updatePaymentSummary();
        }

        public void updatePaymentSummary()
        {
            totalPayment = Int32.Parse(currentInvoice["FEE"].ToString()) + (Int32.Parse(currentInvoice["FEE"].ToString()) * hst) + (Int32.Parse(currentInvoice["FEE"].ToString()) * pst);

            items_services_label.Text = currentInvoice["FEE"].ToString();
            
            hst_gst_label.Text = Math.Round(Int32.Parse(currentInvoice["FEE"].ToString()) * hst, 2).ToString();
            pst_label.Text = Math.Round(Int32.Parse(currentInvoice["FEE"].ToString()) * pst, 2).ToString();

            total_payment.Text = totalPayment.ToString();

            primary_payment_type.Text = totalPayment.ToString();
        }

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
