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
using Newtonsoft.Json.Linq;

namespace Valenwu
{
    public partial class FormConfirmAppointment : Form
    {
        // Declare / initializes required business and query-related objects
        Patient patient;
        ServiceDAO serviceDAO = new ServiceDAO();
        AppointmentDAO appointmentDAO = new AppointmentDAO();
        InvoiceDAO invoiceDAO = new InvoiceDAO();
        List<Service> services;
        int rowID;
        Boolean flag = false;

        /// <summary>
        /// This constructor initializes the FormConfirmAppointment with a Patient object, sets up the format and show-up-down properties of a DateTimePicker, and populates a dropdown menu with service codes obtained from a database query.
        /// </summary>
        /// <param name="p"></param>
        public FormConfirmAppointment(Patient p)
        {
            InitializeComponent();
            formConfirmAppt_time.Format = DateTimePickerFormat.Time;
            formConfirmAppt_time.ShowUpDown = true;
            patient = p;

            services = serviceDAO.getAllServices();

            // Populates services from the service table to the Exam dropdown
            foreach (Service service in services)
            {
                // Adding each service code to Exam dropdown
                formConfirmAppointment_exam_drop_down.Items.Add(service.Code);
            }
        }

        /// <summary>
        /// This constructor initializes the FormConfirmAppointment form for changing an existing appointment by setting the flag to true, setting the time picker format and populating the Exam dropdown with the available services.
        /// </summary>
        /// <param name="obj"></param>
        public FormConfirmAppointment(JObject obj)
        {
            InitializeComponent();

            // True means change appt
            flag = true;

            // Sets the format of the formConfirmAppt_time control to display ONLY the time (hours and minutes), and not the date
            formConfirmAppt_time.Format = DateTimePickerFormat.Time;

            // Allows the user to select the time using up and down arrows
            formConfirmAppt_time.ShowUpDown = true;

            // Retrieves a list of ALL available services from the database using the ServiceDAO object's getAllServices method and stores it in the services variable
            services = serviceDAO.getAllServices();

            rowID = Int32.Parse(obj["ID"].ToString());

            // Populates services from the service table to the Exam dropdown
            foreach (Service service in services)
            {
                // Adding each service code to Exam dropdown
                formConfirmAppointment_exam_drop_down.Items.Add(service.Code);
            }
        }

        /// <summary>
        /// Saves the appointment details to the database and generates an invoice. If the flag is true, it updates the existing appointment details in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formConfirmAppt_save_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                if (sender == formConfirmAppt_save)
                {
                    //  checks whether no exam code or service type is selected in the drop-down list
                    if (formConfirmAppointment_exam_drop_down.SelectedItem == null)
                    {
                        // displays a message box prompting the user to select pre-defined service type
                        MessageBox.Show("Please select an exam code / service type.");
                        return;
                    }

                    // Get service id from the corresponding exam
                    Service individualService = serviceDAO.getOneService(formConfirmAppointment_exam_drop_down.SelectedItem.ToString());

                    // Generate invoice based on acquired service
                    Invoice invoice = new Invoice
                    {
                        patientID = patient.ID,
                        serviceID = individualService.Id,
                        fee = individualService.Fee,
                        totalPaid = 0
                    };

                    // Write to invoice table
                    var invoiceID = invoiceDAO.addOneInvoice(invoice);


                    // Generating appointment
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

                    // Confirmation message for when an appointment is successfully generated
                    MessageBox.Show(result + " new appointment added!");
                }
            }
            else
            {
                Appointment appointment = new Appointment
                {
                    ID = rowID,
                    Month = formConfirmAppt_date.Value.Month.ToString(),
                    Day = formConfirmAppt_date.Value.Day.ToString(),
                    Year = formConfirmAppt_date.Value.Year.ToString(),
                    Time = formConfirmAppt_time.Value.TimeOfDay.ToString(),
                    Exam = formConfirmAppointment_exam_drop_down.SelectedItem.ToString(),
                    Fee = FeeTextbox.Text
                };

                // call the appt dao updae meth

                // dispalay msg box that apt was updated

                var changeSuccess = appointmentDAO.updateOneAppointment(appointment);

                if (changeSuccess == 1)
                {
                    MessageBox.Show("Appointment rescheduled");
                }

                flag = false;
            }
            this.Close();
        }

        /// <summary>
        /// Listens for the Exam dropdown selection to be changed, then it looks up the selected service's fee and populates the fee textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formConfirmAppointment_exam_drop_down_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item from the exam dropdown
            Object selectedItem = formConfirmAppointment_exam_drop_down.SelectedItem;

            // Loop through all the services
            foreach (Service service in services)
            {
                // If the exam / service code matches the selected item...
                if (service.Code.Equals(selectedItem.ToString()))
                {
                    // Display the service fee in the FeeTextbox
                    FeeTextbox.Text = service.Fee.ToString();
                }
            }

        }
    }
}

