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
    //public partial class FormBook : Form
    //{
    //    public FormBook()
    //    {
    //        InitializeComponent();
    //    }


    //    private void todayButton_Click(object sender, EventArgs e)
    //    {
    //        FormPage pageForm = new FormPage();

    //        // Set the StartPosition of the form to the center of the screen
    //        pageForm.StartPosition = FormStartPosition.CenterScreen;

    //        pageForm.Show();
    //    }

    //}

    public partial class FormBook : Form
    {
        public event EventHandler TodayButtonClicked;

        public FormBook()
        {
            InitializeComponent();
        }

        private void todayButton_Click(object sender, EventArgs e)
        {
            // Raise the TodayButtonClicked event
            TodayButtonClicked?.Invoke(this, EventArgs.Empty);

            // Create and show an instance of FormPage
            FormPage pageForm = new FormPage();
            pageForm.StartPosition = FormStartPosition.CenterScreen;
            pageForm.Show();
        }
    }

}
