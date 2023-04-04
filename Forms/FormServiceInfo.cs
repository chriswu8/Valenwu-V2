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
    /// <summary>
    /// The FormServiceInfo class contains methods for adding a Service.
    /// </summary>
    public partial class FormServiceInfo : Form
    {
        // Declare / instantiate required objects
        BindingSource serviceBinding = new BindingSource();
        FormServices formService;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="service"></param>
        public FormServiceInfo(FormServices f, Service service = null)
        {
            InitializeComponent();
            formService = f;

            if (service != null)
            {
                CodeTextBox.Text = service.Code;
                FeeTextBox.Text = service.Fee.ToString();
                DescriptionTextBox.Text = service.Description;
            }
        }

        /// <summary>
        /// This method saves a Service to the service database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_service_info_save_Click(object sender, EventArgs e)
        {
            // Instantiate the Service DAO to handle database additions.
            ServiceDAO serviceDAO = new ServiceDAO();

            // Construct a Service object.
            Service service = new Service
            {
                Code = CodeTextBox.Text,
                Fee = int.Parse(FeeTextBox.Text),
                Description = DescriptionTextBox.Text
            };

            // Add it to the database.
            int result = serviceDAO.addOneService(service);
            MessageBox.Show(result + " new service added!");

            serviceBinding.DataSource = serviceDAO.addOneService(service);

            // pass the data from the serviceDAO into the constructor
            formService.DisplayAllServices(serviceDAO);

            this.Close();

        }
    }
}
