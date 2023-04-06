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

namespace Valenwu
{
    // FormBook represents a virtual book for appointment scheduling
    public partial class FormBook : Form
    {
        public event EventHandler TodayButtonClicked;
        DateTime today;

        // The FormBook constructor
        public FormBook()
        {
            InitializeComponent();
            today = DateTime.Today;
        }

        /// <summary>
        /// todayButton_Click is the event handler for the "Today" button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void todayButton_Click(object sender, EventArgs e)
        {
            // Getting today's date components (variables should be renamed)
            var tmrMonth = today.Month;
            var tmrDay = today.Day;
            var tmrYear = today.Year;

            // Creating a new form page, fp, and setting the date components to today's date
            FormPage fp = new FormPage(tmrDay, tmrMonth, tmrYear);
            fp.MdiParent = this.MdiParent;
            fp.displayAppointments(tmrMonth, tmrDay, tmrYear);

            // Displays the fp form page 
            fp.Show();

            // Closes this FormBook window
            this.Close();
            
        }

        /// <summary>
        /// formBook_tomorrow_Click is the event handler for the "Tomorrow" button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formBook_tomorrow_Click(object sender, EventArgs e)
        {
            // Getting tomorrow's date components
            var tmrMonth = today.Month;
            var tmrDay = today.Day + 1;
            var tmrYear = today.Year;

            // Adjust the date when required (still need to handle edge cases)
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

            // Creates a new FormPage and setting the date components to tomorrow's date
            FormPage fp = new FormPage(tmrDay, tmrMonth, tmrYear);

            // Sets fp FormPage's parent form to be this FormBook instance 
            fp.MdiParent = this.MdiParent;

            // Displays appointments for the specified date in the form; tomorrow's appointments in this case
            fp.displayAppointments(tmrMonth, tmrDay, tmrYear);

            // Displays the fp FormPage
            fp.Show();

            // Closes the FormBook
            this.Close();

        }
    }

}
