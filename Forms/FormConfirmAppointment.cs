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
        List<Service> services;
        public FormConfirmAppointment(Patient p)
        {
            InitializeComponent();
            formConfirmAppt_time.Format = DateTimePickerFormat.Time;
            formConfirmAppt_time.ShowUpDown = true;
            patient = p;

            services = serviceDAO.getAllServices();

            foreach (Service service in services)
            {
                formConfirmAppointment_exam_drop_down.Items.Add(service.Code);
            }
        }



        private void formConfirmAppt_save_Click(object sender, EventArgs e)
        {
            /*var a = formConfirmAppt_date.Value.Year.ToString();
            var b = formConfirmAppt_date.Value.Month.ToString();
            var c = formConfirmAppt_date.Value.Day.ToString();


            var d = formConfirmAppt_time.Text;*/

            AppointmentDAO appointmentDAO = new AppointmentDAO();

            Appointment appointment = new Appointment
            {
                Month = formConfirmAppt_date.Value.Month.ToString(),
                Day = formConfirmAppt_date.Value.Day.ToString(),
                Year = formConfirmAppt_date.Value.Year.ToString(),
                Time = formConfirmAppt_time.Value.TimeOfDay.ToString(),
                Exam = formConfirmAppointment_exam_drop_down.SelectedItem.ToString(),
                Fee = FeeTextbox.Text,
                PatientID = patient.ID
            };

            int result = appointmentDAO.addAppointmentByPatient(appointment);

            MessageBox.Show(result + " new appointment added!");

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

