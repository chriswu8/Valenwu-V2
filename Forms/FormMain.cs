namespace Valenwu
{
    public partial class Valenwu : Form
    {
        public Valenwu()
        {
            InitializeComponent();

        }


        private void OpenFormButton_Click(object sender, EventArgs e)
        {
            if (sender == PatientsButton)
            {
                FormPatient patientsForm = new FormPatient();

                // Set the StartPosition of the form to the center of the screen
                patientsForm.StartPosition = FormStartPosition.CenterScreen;

                patientsForm.Show();
                
            }
            else if (sender == BookButton)
            {
                FormBook bookForm = new FormBook();

                // Set the StartPosition of the form to the center of the screen
                bookForm.StartPosition = FormStartPosition.CenterScreen;

                bookForm.Show();
            }
            else if (sender == ServicesButton)
            {
                FormServices servicesForm = new FormServices();

                // Set the StartPosition of the form to the center of the screen
                servicesForm.StartPosition = FormStartPosition.CenterScreen;

                servicesForm.Show();
            }
        }


    }
}