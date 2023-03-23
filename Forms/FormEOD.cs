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
    public partial class FormEOD : Form
    {
        BindingSource eodBinding = new BindingSource();
        AppointmentDAO appointmentDAO = new AppointmentDAO();
        DateTime today = DateTime.Today;
        public FormEOD(int totRevenue)
        {
            InitializeComponent();
            eodBinding.DataSource = appointmentDAO.getAppointmentsForEOD(today.Month, today.Day, today.Year);
            formEOD_datagridview.DataSource = eodBinding;

            formEOD_total_revenue.Text = "$ " + totRevenue.ToString();
        }

        public int updateTotalRevenue()
        {
            List<JObject> allAppointments = appointmentDAO.getAppointmentsForEOD(today.Month, today.Day, today.Year);
            int totalAmount = 0;

            for (int i = 0; i < allAppointments.Count(); i++)
            {
                totalAmount += Int32.Parse(allAppointments[i]["FEE"].ToString());
            }

            return totalAmount;
        }
    }
}
