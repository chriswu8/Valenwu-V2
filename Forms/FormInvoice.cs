﻿/// Authors: Edmond Chen, Chris Wu
/// 
/// Build a sql database app tutorial by Shad Sluiter: https://www.youtube.com/watch?v=9CM4NAH7gTg&list=PLhPyEFL5u-i3Tyw0GtekMrHCukldmtf7k&index=1
/// How to write a sql query by Shad Sluiter source: https://www.youtube.com/watch?v=9CM4NAH7gTg&list=PLhPyEFL5u-i3Tyw0GtekMrHCukldmtf7k&index=2
/// Create a Winforms database app tutorial by Shad Sluiter source: https://www.youtube.com/watch?v=9CM4NAH7gTg&list=PLhPyEFL5u-i3Tyw0GtekMrHCukldmtf7k&index=3
/// How to create a DAO for mySQL - Data Access Object by Shad Sluiter source: https://www.youtube.com/watch?v=9CM4NAH7gTg&list=PLhPyEFL5u-i3Tyw0GtekMrHCukldmtf7k&index=4
/// Search query on sql example by Shad Sluiter source: https://www.youtube.com/watch?v=9CM4NAH7gTg&list=PLhPyEFL5u-i3Tyw0GtekMrHCukldmtf7k&index=5
/// Add a picture to winforms app by Shad Sluiter source: https://www.youtube.com/watch?v=9CM4NAH7gTg&list=PLhPyEFL5u-i3Tyw0GtekMrHCukldmtf7k&index=6
/// SQL insert example by Shad Sluiter source: https://www.youtube.com/watch?v=9CM4NAH7gTg&list=PLhPyEFL5u-i3Tyw0GtekMrHCukldmtf7k&index=7
/// Add a foreign key with mySQL workbench by Shad Sluiter source: https://www.youtube.com/watch?v=9CM4NAH7gTg&list=PLhPyEFL5u-i3Tyw0GtekMrHCukldmtf7k&index=8
/// How to join sql tables by Shad Sluiter source: https://www.youtube.com/watch?v=9CM4NAH7gTg&list=PLhPyEFL5u-i3Tyw0GtekMrHCukldmtf7k&index=9
/// Write a SQL inner join statement by Shad Sluiter source: https://www.youtube.com/watch?v=9CM4NAH7gTg&list=PLhPyEFL5u-i3Tyw0GtekMrHCukldmtf7k&index=10
/// Design a sql database by Shad Sluiter source: https://www.youtube.com/watch?v=9CM4NAH7gTg&list=PLhPyEFL5u-i3Tyw0GtekMrHCukldmtf7k&index=11
/// SQL select with multiple tables by Shad Sluiter source: https://www.youtube.com/watch?v=9CM4NAH7gTg&list=PLhPyEFL5u-i3Tyw0GtekMrHCukldmtf7k&index=12
/// SQL delete example by Shad Sluiter source: https://www.youtube.com/watch?v=9CM4NAH7gTg&list=PLhPyEFL5u-i3Tyw0GtekMrHCukldmtf7k&index=13
/// SQL database design features by Shad Sluiter source: https://www.youtube.com/watch?v=9CM4NAH7gTg&list=PLhPyEFL5u-i3Tyw0GtekMrHCukldmtf7k&index=14

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
    /// The FormInvoice class contains methods for displaying and interacting with patient invoices. It includes functions for calculating and displaying the total amount due, displaying all invoices for a given patient, and handling user interactions with invoice-related buttons.
    /// </summary>
    public partial class FormInvoice : Form
    {

        // Declare / instantiate required objects
        FormPatient formPatient;
        Patient parentPatient;
        BindingSource invoiceBinding = new BindingSource();
        InvoiceDAO invoiceDAO = new InvoiceDAO();

        public FormInvoice()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fp"></param>
        /// <param name="patient"></param>
        public FormInvoice(FormPatient fp, Patient patient)
        {
            InitializeComponent();

            // Stores the passed patient as the parent patient
            parentPatient = patient;

            // Stores the passed formPatient as the formPatient
            formPatient = fp;

            // Display all invoices BELONGING TO THE GIVEN PATIENT
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

        /// <summary>
        /// Displays all invoices associated with the parent patient on form load
        /// </summary>
        public void displayAllInvoicesFromPatientOnLoad()
        {
            // Set the data source of the invoiceBinding object to all invoices associated with the parent patient
            invoiceBinding.DataSource = invoiceDAO.getAllInvoicesFromPatient(parentPatient.ID);

            // Set the data source of the formInvoice_dataGridView object to the invoiceBinding object
            formInvoice_dataGridView.DataSource = invoiceBinding;
        }

        /// <summary>
        /// Populates the invoice data grid view with all the invoices for a specific patient.
        /// </summary>
        /// <param name="patientID"></param>
        private void displayAllInvoicesFromPatient(int patientID)
        {
            // Get all invoices for the specified patient ID using the DAO
            invoiceBinding.DataSource = invoiceDAO.getAllInvoicesFromPatient(patientID);

            // Set the data source of the data grid view to the invoice binding
            formInvoice_dataGridView.DataSource = invoiceBinding;
        }

        /// <summary>
        /// This method handles all form actions relating to invoices.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoice_button_Click(object sender, EventArgs e)
        {
            // Ensures that the Exit button functions regardless of whether a row or cell is selected
            if (sender != ExitInvoiceButton)
            {
                // Checks whether a row is not selected (ie. a cell selected) in the DataGridView
                if (formInvoice_dataGridView.SelectedRows.Count == 0)
                {
                    // Prompts user to select a row instead
                    MessageBox.Show("You have selected a cell. Please select a row (invoice).");
                    return;
                }
            }

            if (sender == NewInvoiceButton)
            {
                // TODO
            }
            else if (sender == TakeAPaymentButton)
            {
                // Select the first row (invoice) from the data grid view 
                JObject selectedPatient = (JObject)formInvoice_dataGridView.SelectedRows[0].DataBoundItem;

                // Create a new FormPayment form for taking a payment
                FormPayment fp = new FormPayment(this, selectedPatient);

                // Set the parent form of fp to be the current FormInvoice form
                fp.MdiParent = this.MdiParent;

                // Display the fp FormPayment 
                fp.Show();

                // merge to main
                // merge
            }
            else if (sender == ClearInvoicesButton)
            {
                // TODO
            }
            else if (sender == ExitInvoiceButton)
            {
                this.Close();
            }
        }


    }
}
