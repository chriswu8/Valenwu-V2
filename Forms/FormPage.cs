using Newtonsoft.Json.Linq;
using Valenwu.DAO;

namespace Valenwu
{
    public partial class FormPage : Form
    {
        private BindingSource appointmentBinding = new BindingSource();
        private AppointmentDAO appointmentDAO = new AppointmentDAO();
        private InvoiceDAO invoiceDAO = new InvoiceDAO();
        public int formDay;
        public int formMonth;
        public int formYear;
        public DateTime dateTitle;

        public FormPage()
        {
            InitializeComponent();
            formDay = 0;
            formMonth = 0;
            formYear = 0;
        }

        private void updateDateTitle(int year, int month, int day)
        {
            this.dateTitle = new DateTime(formYear, formMonth, formDay);
            if (formYear != 0)
            {
                this.DateTitle.Text = dateTitle.ToString("MMMM dd, yyyy");
            };
        }

        public FormPage(int day, int month, int year)
        {
            InitializeComponent();
            formDay = day;
            formMonth = month;
            formYear = year;

            this.updateDateTitle(year, month, day);
        }

        public void displayAppointments(int month, int day, int year)
        {
            appointmentBinding.DataSource = appointmentDAO.getAppointmentsForPatientInnerJoin(month, day, year);
            dataGridView1.DataSource = appointmentBinding;
            if (this.dataGridView1.Columns["ID"] != null)
            {
                this.dataGridView1.Columns["ID"].Visible = false;
            }

            this.updateDateTitle(formYear, formMonth, formDay);
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
                JObject appointment = (JObject)dataGridView1.SelectedRows[0].DataBoundItem;

                var deleteSuccessful = appointmentDAO.deleteOneAppointment(Int32.Parse(appointment["ID"].ToString()));
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
                // TODO
            }
            else if (sender == exit_page_button)
            {
                this.Close();
            }
        }
    }
}