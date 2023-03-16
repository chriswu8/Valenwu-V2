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

namespace Valenwu.Forms
{
    public partial class FormServiceInfo : Form
    {
        BindingSource serviceBinding = new BindingSource();
        FormServices formService;

        public FormServiceInfo(FormServices f)
        {
            InitializeComponent();
            formService = f;
        }

        private void form_service_info_save_Click(object sender, EventArgs e)
        {
            ServiceDAO serviceDAO = new ServiceDAO();


            Service service = new Service
            {
                Code = CodeTextBox.Text,
                Fee = int.Parse(FeeTextBox.Text),
                Description = DescriptionTextBox.Text
            };


            int result = serviceDAO.addOneService(service);
            MessageBox.Show(result + " new service added!");

            serviceBinding.DataSource = serviceDAO.addOneService(service);

            // pass the data from the serviceDAO into the constructor

            formService.DisplayAllServices(serviceDAO);

            this.Close();

        }
    }
}
