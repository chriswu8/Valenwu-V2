namespace Valenwu
{
    public partial class Valenwu : Form
    {
        public Valenwu()
        {
            InitializeComponent();

        }


        //private void OpenFormButton_Click(object sender, EventArgs e)
        //{
        //    if (sender == PatientsButton)
        //    {
        //        FormPatient patientsForm = new FormPatient();

        //        // Set the StartPosition of the form to the center of the screen
        //        patientsForm.StartPosition = FormStartPosition.CenterScreen;

        //        patientsForm.Show();

        //    }
        //    else if (sender == BookButton)
        //    {
        //        FormBook bookForm = new FormBook();

        //        // Set the StartPosition of the form to the center of the screen
        //        bookForm.StartPosition = FormStartPosition.CenterScreen;

        //        bookForm.Show();
        //    }
        //    else if (sender == ServicesButton)
        //    {
        //        FormServices servicesForm = new FormServices();

        //        // Set the StartPosition of the form to the center of the screen
        //        servicesForm.StartPosition = FormStartPosition.CenterScreen;

        //        servicesForm.Show();
        //    } 
        //}

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
                FormEOD endOfDayForm = new FormEOD();
                endOfDayForm.StartPosition = FormStartPosition.CenterScreen;
                endOfDayForm.Show();
            }
        }
    }
}