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
    public partial class FormPayment : Form
    {
        FormPatient formPatient;
        FormInvoice formInvoice;
        public FormPayment(FormPatient fp)
        {
            InitializeComponent();
            formPatient = fp;
        }

        public FormPayment(FormInvoice formInvoice)
        {
            this.formInvoice = formInvoice;
        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
