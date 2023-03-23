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
    public partial class FormPage : Form
    {
        BindingSource appointmentBinding = new BindingSource();
        AppointmentDAO appointmentDAO = new AppointmentDAO();
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
                // TODO
            }
            else if (sender == delete_appointment_button)
            {
                // TODO
                JObject test = (JObject)dataGridView1.SelectedRows[0].DataBoundItem;

                var deleteSuccessful = appointmentDAO.deleteOneAppointment(Int32.Parse(test["ID"].ToString()));

                if (deleteSuccessful >= 1)
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
                // TODO
            }
            else if (sender == exit_page_button)
            {
                this.Close();
            }
        }


    }
}
