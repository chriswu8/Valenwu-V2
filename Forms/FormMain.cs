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

namespace Valenwu
{
    /// <summary>
    /// The FormMain class contains methods to open all the forms for this project. 
    /// This class acts as the starting point of our project and is the main parent for the rest of the forms.
    /// </summary>
    public partial class Valenwu : Form
    {
        // Declare and instantiate required attributes for the FormMain
        private double totalRevenue = 0;
        FormEOD endOfDayForm;

        /// <summary>
        /// Constructor
        /// </summary>
        public Valenwu()
        {
            InitializeComponent();
            endOfDayForm = new FormEOD(0);
        }

        /// <summary>
        /// This method handles all the FormMain button events and opens their respective forms upon a button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFormButton_Click(object sender, EventArgs e)
        {
            if (sender == PatientsButton)
            {
                FormPatient patientsForm = new FormPatient();
                patientsForm.StartPosition = FormStartPosition.CenterScreen;
                patientsForm.Show();
            }
            else if (sender == BookButton)
            {
                FormBook bookForm = new FormBook();
                bookForm.StartPosition = FormStartPosition.CenterScreen;
                bookForm.Show();

                // Subscribe to the TodayButtonClicked event of FormBook
                bookForm.TodayButtonClicked += (s, e) =>
                {
                    // Create and show an instance of FormPage
                    FormPage pageForm = new FormPage();
                    pageForm.StartPosition = FormStartPosition.CenterScreen;
                    pageForm.Show();
                };
            }
            else if (sender == ServicesButton)
            {
                FormServices servicesForm = new FormServices();
                servicesForm.StartPosition = FormStartPosition.CenterScreen;
                servicesForm.Show();
            }
            else if (sender == DaysActivityButton)
            {
                FormEOD endOfDayForm = new FormEOD(totalRevenue);
                endOfDayForm.StartPosition = FormStartPosition.CenterScreen;
                endOfDayForm.Show();
            }
            else if (sender == BalanceTheCashButton)
            {
                totalRevenue = endOfDayForm.updateTotalRevenue();
            }
        }
    }
}