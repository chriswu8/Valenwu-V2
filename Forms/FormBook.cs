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
    
    public partial class FormBook : Form
    {
        public event EventHandler TodayButtonClicked;
        DateTime today;

        public FormBook()
        {
            InitializeComponent();
            today = DateTime.Today;
        }

        private void todayButton_Click(object sender, EventArgs e)
        {
            var tmrMonth = today.Month;
            var tmrDay = today.Day;
            var tmrYear = today.Year;


            FormPage fp = new FormPage(tmrDay, tmrMonth, tmrYear);
            fp.MdiParent = this.MdiParent;
            fp.displayAppointments(tmrMonth, tmrDay, tmrYear);

            fp.Show();
            this.Close();
            
        }

        private void formBook_tomorrow_Click(object sender, EventArgs e)
        {
            var tmrMonth = today.Month;
            var tmrDay = today.Day + 1;
            var tmrYear = today.Year;

            if (tmrDay > 31 && tmrMonth == 12)
            {
                tmrYear += 1;
                tmrDay = 1;
                tmrMonth = 1;
            }
            else if (tmrDay > 31 && tmrMonth < 12)
            {
                tmrMonth += 1;
                tmrDay = 1;
            }

            FormPage fp = new FormPage(tmrDay, tmrMonth, tmrYear);
            fp.MdiParent = this.MdiParent;

            fp.displayAppointments(tmrMonth, tmrDay, tmrYear);

            fp.Show();
            this.Close();

        }
    }

}
