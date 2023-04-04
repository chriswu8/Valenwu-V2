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