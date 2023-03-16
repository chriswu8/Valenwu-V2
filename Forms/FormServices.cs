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
using Valenwu.Forms;

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
            FormServiceInfo fp = new FormServiceInfo(this);
            fp.MdiParent = this.MdiParent;
            fp.Show();
            DisplayAllServicesOnLoad();
        }


        private void deleteService_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this service?", "Confirmation", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Service service = (Service)dataGridViewServices.SelectedRows[0].DataBoundItem;
                    int result = serviceDAO.deleteOneService(service);

                    if (result > 0)
                    {
                        MessageBox.Show("Service deleted successfully.");
                        DisplayAllServices(serviceDAO);
                    }
                    else
                    {
                        MessageBox.Show("Unable to delete service.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }


        private void dataGridViewServices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                Service service = (Service)dataGridViewServices.SelectedRows[0].DataBoundItem;
                FormServiceInfo formServiceInfo = new FormServiceInfo(this, service);
                formServiceInfo.ShowDialog();
            }
        }

        private void editService_Click(object sender, EventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                Service service = (Service)dataGridViewServices.SelectedRows[0].DataBoundItem;
                FormServiceInfo formServiceInfo = new FormServiceInfo(this, service);
                formServiceInfo.ShowDialog();
            }
        }

    }
}
