/// Authors: Edmond Chen, Chris Wu
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
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Valenwu.DAO;
using Valenwu.Entities;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Valenwu
{
    /// <summary>
    /// The FormPage represents a "page" in the FormBook. This class contains methods for displaying appointments at a future date relative to the current date. This class also contains methods perform CRUD operations on appointments.
    /// </summary>
    public partial class FormPage : Form
    {
        // Instantiate required attributes to communicate with the database and the FormPage state
        BindingSource appointmentBinding = new BindingSource();
        AppointmentDAO appointmentDAO = new AppointmentDAO();
        InvoiceDAO invoiceDAO = new InvoiceDAO();
        public int formDay;
        public int formMonth;
        public int formYear;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FormPage()
        {
            InitializeComponent();
            formDay= 0; 
            formMonth= 0;
            formYear= 0;
        }

        /// <summary>
        /// Overloaded constructor.
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        public FormPage(int day, int month, int year)
        {
            InitializeComponent();
            formDay = day;
            formMonth = month;
            formYear = year;
        }

        /// <summary>
        /// Display all appointments for a given month, day and year.
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="year"></param>
        public void displayAppointments(int month, int day, int year)
        {
            appointmentBinding.DataSource = appointmentDAO.getAppointmentsForPatientInnerJoin(month, day, year);
            dataGridView1.DataSource = appointmentBinding;
            if (this.dataGridView1.Columns["ID"] != null)
            {
                this.dataGridView1.Columns["ID"].Visible = false;
            }
        }

        /// <summary>
        /// This method handles all button events in FormPage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageButton_Click(object sender, EventArgs e)
        {
            if (sender == squeeze_in_button)
            {
                FormPatient patientsForm = new FormPatient();
                patientsForm.StartPosition = FormStartPosition.CenterScreen;
                patientsForm.Show();
            }
            else if (sender == change_appointment_button)
            {
                // Retrieve the selected Appointment object from the DataGridView control
                JObject appointment = (JObject)dataGridView1.SelectedRows[0].DataBoundItem;

                // Create a new instance of the FormPatientInfo form with the FormPage object as its parameter
                FormConfirmAppointment fca = new FormConfirmAppointment(appointment);

                // Set the MdiParent property of the new form and display it
                fca.MdiParent = this.MdiParent;

                // Set the Patient property of the new form with the selected Patient object
                // todo

                fca.Show();


                //appointmentDAO.updateOneAppointment(Int32.Parse(appointment["ID"].ToString()));

            }
            else if (sender == delete_appointment_button)
            {
                JObject appointment = (JObject)dataGridView1.SelectedRows[0].DataBoundItem;

                // returns number of rows that were deleted
                var deleteSuccessful = appointmentDAO.deleteOneAppointment(Int32.Parse(appointment["ID"].ToString()));

                // returns number of rows that were deleted
                var invoiceDelete = invoiceDAO.deleteInvoiceFromAppointment(Int32.Parse(appointment["invoice_ID"].ToString()));

                if (deleteSuccessful >= 1 && invoiceDelete >= 1)
                {
                    MessageBox.Show("Appointment deleted successfully.");
                    displayAppointments(formMonth, formDay, formYear);
                }
            }
            else if (sender == patient_button)
            {
                // TODO
            }
            else if (sender == diary_button)
            {
                // Retrieve the selected Appointment object from the DataGridView control
                JObject appointment = (JObject)dataGridView1.SelectedRows[0].DataBoundItem;
                
                FormPatientInfo fpi = new FormPatientInfo(appointment);

                // Set the MdiParent property of the new form and display it
                fpi.MdiParent = this.MdiParent;

                fpi.Show();

            }
            else if (sender == exit_page_button)
            {
                this.Close();
            }
        }


    }
}
