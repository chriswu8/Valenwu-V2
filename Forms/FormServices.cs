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
    public partial class FormServices : Form
    {
        BindingSource serviceBinding = new BindingSource();
        ServiceDAO serviceDAO = new ServiceDAO();

        public FormServices()
        {
            InitializeComponent();
            DisplayAllServicesOnLoad();
        }
        public void DisplayAllServicesOnLoad()
        {
            serviceBinding.DataSource = serviceDAO.getAllServices();
            dataGridViewServices.DataSource = serviceBinding;
        }

        public void DisplayAllServices(ServiceDAO serviceDAO)
        {
            serviceBinding.DataSource = serviceDAO.getAllServices();
            dataGridViewServices.DataSource = serviceBinding;
        }


        private void addService_Click(object sender, EventArgs e)
        {
            FormPatientInfo fp = new FormPatientInfo(this);
            fp.MdiParent = this.MdiParent;
            fp.Show();
            DisplayAllServicesOnLoad();
        }
    }
}
