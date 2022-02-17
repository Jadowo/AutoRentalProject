using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class frmCreditCardDeleteForm : Form
    {
        public frmCreditCardDeleteForm()
        {
            InitializeComponent();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void inputCardNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            CreditCard c = new CreditCard();
            c.Load(inputCardNum.Text);
            if (c.Delete(inputCardNum.Text))
            {
                inputCardNum.Text = "Deleted";
            }
            else
            {
                inputCardNum.Text = "Number does not exist";
            }
        }
    }
}
