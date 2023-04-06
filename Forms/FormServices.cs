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
using Valenwu.DAO;
using Valenwu.Entities;
using Valenwu.Forms;

namespace Valenwu
{
    /// <summary>
    /// The FormServices class contains methods for displaying and interacting with Services. It includes functions for handling all CRUD operations for a Service.
    /// </summary>
    public partial class FormServices : Form
    {
        // Declare / instantiate required objects to communicate with the database.
        BindingSource serviceBinding = new BindingSource();
        ServiceDAO serviceDAO = new ServiceDAO();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FormServices()
        {
            InitializeComponent();
            DisplayAllServicesOnLoad();
        }

        /// <summary>
        /// This method displays all services on form load.
        /// </summary>
        public void DisplayAllServicesOnLoad()
        {
            // Retrieve data and bind to data grid view
            serviceBinding.DataSource = serviceDAO.getAllServices();
            dataGridViewServices.DataSource = serviceBinding;
        }

        /// <summary>
        /// This method displays all services only when it's called.
        /// </summary>
        /// <param name="serviceDAO"></param>
        public void DisplayAllServices(ServiceDAO serviceDAO)
        {
            serviceBinding.DataSource = serviceDAO.getAllServices();
            dataGridViewServices.DataSource = serviceBinding;
        }

        /// <summary>
        /// This method handles all button events in FormServices.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void service_button_Click(object sender, EventArgs e)
        {
            if (sender != ExitServiceButton)
            {
                // Error handling
                if (dataGridViewServices.SelectedRows.Count == 0)
                {
                    MessageBox.Show("You have selected a cell. Please select a row (service).");
                    return;
                }
            }
            if (sender == addNewServiceButton)
            {
                // Display FormServiceInfo upon this event being triggered.
                FormServiceInfo fp = new FormServiceInfo(this);
                fp.MdiParent = this.MdiParent;
                fp.Show();
                DisplayAllServicesOnLoad();
            }
            else if (sender == DeleteServiceButton)
            {
                if (dataGridViewServices.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this service?", "Confirmation", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Delete a specific service
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
            else if (sender == EditServiceButton)
            {
                if (dataGridViewServices.SelectedRows.Count > 0)
                {
                    // Edit a specific service.
                    Service service = (Service)dataGridViewServices.SelectedRows[0].DataBoundItem;
                    FormServiceInfo formServiceInfo = new FormServiceInfo(this, service);
                    formServiceInfo.ShowDialog();
                }
            }
            else if (sender == ExitServiceButton)
            {
                this.Close();
            }

        }


        private void dataGridViewServices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewServices.SelectedRows.Count > 0)
            {
                // Show the FormServiceInfo upon selecting a specific service.
                Service service = (Service)dataGridViewServices.SelectedRows[0].DataBoundItem;
                FormServiceInfo formServiceInfo = new FormServiceInfo(this, service);
                formServiceInfo.ShowDialog();
            }
        }
    }
}
