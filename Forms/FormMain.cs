namespace Valenwu
{
    public partial class Valenwu : Form
    {
        
        private int totalRevenue = 0;
        FormEOD endOfDayForm;
        public Valenwu()
        {
            InitializeComponent();
            endOfDayForm = new FormEOD(0);
        }

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