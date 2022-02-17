using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class frmCreditCardMSForm : Form
    {
        public frmCreditCardMSForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmCreditCardSearchForm objSearch = new frmCreditCardSearchForm();

            this.Hide();

            objSearch.ShowDialog();

            this.Show();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            frmCreditCardRegistrationForm objRegistration = new frmCreditCardRegistrationForm();

            this.Hide();

            objRegistration.ShowDialog();

            this.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmCreditCardUpdateForm objUpdate = new frmCreditCardUpdateForm();

            this.Hide();

            objUpdate.ShowDialog();

            this.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmCreditCardDeleteForm objDelete = new frmCreditCardDeleteForm();

            this.Hide();

            objDelete.ShowDialog();

            this.Show();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            frmCreditCardListForm objList = new frmCreditCardListForm();

            this.Hide();

            objList.ShowDialog();

            this.Show();
        }
    }
}
