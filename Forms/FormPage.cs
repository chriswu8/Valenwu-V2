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
    public partial class FormPage : Form
    {
        BindingSource appointmentBinding = new BindingSource();
        AppointmentDAO appointmentDAO = new AppointmentDAO();
        InvoiceDAO invoiceDAO = new InvoiceDAO();
        public int formDay;
        public int formMonth;
        public int formYear;

        public FormPage()
        {
            InitializeComponent();
            formDay= 0; 
            formMonth= 0;
            formYear= 0;
        }

        public FormPage(int day, int month, int year)
        {
            InitializeComponent();
            formDay = day;
            formMonth = month;
            formYear = year;
        }

        public void displayAppointments(int month, int day, int year)
        {
            appointmentBinding.DataSource = appointmentDAO.getAppointmentsForPatientInnerJoin(month, day, year);
            dataGridView1.DataSource = appointmentBinding;
            if (this.dataGridView1.Columns["ID"] != null)
            {
                this.dataGridView1.Columns["ID"].Visible = false;
            }
        }

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
