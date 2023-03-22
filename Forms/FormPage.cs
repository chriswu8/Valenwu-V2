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

        public FormPage()
        {
            InitializeComponent();
        }

        public void displayAppointments(int month, int day, int year)
        {
            appointmentBinding.DataSource = appointmentDAO.getAppointmentsForPatientInnerJoin(month, day, year);

            dataGridView1.DataSource = appointmentBinding;
        }
        
    }
}
