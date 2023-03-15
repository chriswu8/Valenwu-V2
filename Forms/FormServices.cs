using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Valenwu
{
    public partial class FormServices : Form
    {
        public FormServices()
        {
            InitializeComponent();
        }

        private void addService_Click(object sender, EventArgs e)
        {
            // Prompt the user to enter service details
            string code = Microsoft.VisualBasic.Interaction.InputBox("Enter service code:", "Add new service", "");
            string fee = Microsoft.VisualBasic.Interaction.InputBox("Enter service fee:", "Add new service", "");
            string description = Microsoft.VisualBasic.Interaction.InputBox("Enter service description:", "Add new service", "");

            // Create a label with the service details
            Label serviceLabel = new Label();
            serviceLabel.AutoSize = true;
            serviceLabel.Text = code + "    " + fee + "    " + description;

            // Set the position of the label
            if (panel1.Controls.Count > 0)
            {
                Label lastLabel = (Label)panel1.Controls[panel1.Controls.Count - 1];
                serviceLabel.Top = lastLabel.Bottom + 10;
            }
            else
            {
                serviceLabel.Top = 10;
            }
            serviceLabel.Left = 10;

            // Add the label to the panel
            panel1.Controls.Add(serviceLabel);
        }
    }
}
