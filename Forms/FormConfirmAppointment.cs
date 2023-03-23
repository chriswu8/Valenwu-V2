using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Valenwu.Entities;
using Valenwu.DAO;
using Org.BouncyCastle.Asn1.X509.Qualified;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Valenwu
{
    public partial class FormConfirmAppointment : Form
    {
        Patient patient;
        ServiceDAO serviceDAO = new ServiceDAO();
        AppointmentDAO appointmentDAO = new AppointmentDAO();
        InvoiceDAO invoiceDAO = new InvoiceDAO();
        List<Service> services;

        public FormConfirmAppointment(Patient p)
        {
            InitializeComponent();
            formConfirmAppt_time.Format = DateTimePickerFormat.Time;
            formConfirmAppt_time.ShowUpDown = true;
            patient = p;

            services = serviceDAO.getAllServices();

            // populates services from the service table to the Exam dropdown
            foreach (Service service in services)
            {
                // adding each service code to Exam dropdown
                formConfirmAppointment_exam_drop_down.Items.Add(service.Code);
            }
        }


        private void formConfirmAppt_save_Click(object sender, EventArgs e)
        {
            if (sender == formConfirmAppt_save)
            {
                if (formConfirmAppointment_exam_drop_down.SelectedItem == null)
                {
                    MessageBox.Show("Please select an exam code / service type.");
                    return;
                }

                // get service id from the corresponding exam
                Service individualService = serviceDAO.getOneService(formConfirmAppointment_exam_drop_down.SelectedItem.ToString());

                // Generate invoice based on acquired service
                Invoice invoice = new Invoice
                {
                    patientID = patient.ID,
                    serviceID = individualService.Id,
                    fee = individualService.Fee,
                    totalPaid = 0
                };

                // write to invoice table
                var invoiceID = invoiceDAO.addOneInvoice(invoice);


                // generating appointment
                Appointment appointment = new Appointment
                {
                    Month = formConfirmAppt_date.Value.Month.ToString(),
                    Day = formConfirmAppt_date.Value.Day.ToString(),
                    Year = formConfirmAppt_date.Value.Year.ToString(),
                    Time = formConfirmAppt_time.Value.TimeOfDay.ToString(),
                    Exam = formConfirmAppointment_exam_drop_down.SelectedItem.ToString(),
                    Fee = FeeTextbox.Text,
                    PatientID = patient.ID,
                    InvoiceID = invoiceID
                };


                // sql statement that inserts appointment into appointment table
                int result = appointmentDAO.addAppointmentByPatient(appointment);


                MessageBox.Show(result + " new appointment added!");
            }

            this.Close();
        }


        private void formConfirmAppointment_exam_drop_down_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Object selectedItem = formConfirmAppointment_exam_drop_down.SelectedItem;

            foreach (Service service in services)
            {
                if (service.Code.Equals(selectedItem.ToString()))
                {
                    FeeTextbox.Text = service.Fee.ToString();
                }
            }

        }
    }
}

