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
    public partial class frmCreditCardSearchForm : Form
    {
        public frmCreditCardSearchForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CreditCard c = new CreditCard();

            if (c.Load(inputCardNum.Text))
            {
                outputCardNum.Text = c.CreditCardNumber;
                outputCardName.Text = c.CreditCardOwnerName;
                outputCardCompany.Text = c.MerchantName;
                outputCardExpDate.Text = c.ExpDate.ToString();
                outputAddress1.Text = c.AddressLine1;
                outputAddress2.Text = c.AddressLine2;
                outputCity.Text = c.City;
                outputState.Text = c.StateCode;
                outputZip.Text = c.ZipCode;
                outputCountry.Text = c.Country;
                outputLimit.Text = c.CreditCardLimit.ToString();
                outputBalance.Text = c.CreditCardBalance.ToString();
                
                if (c.ActivationStatus)
                {
                    outputStatus.Text = "Activated";
                }
                else
                {
                    outputStatus.Text = "Deactivated";
                }
            }
            else
            {
                outputCardNum.Text = "Card Number not found";
                outputCardName.Text = "";
                outputCardCompany.Text = "";
                outputCardExpDate.Text = "";
                outputAddress1.Text = "";
                outputAddress2.Text = "";
                outputCity.Text = "";
                outputState.Text = "";
                outputZip.Text = "";
                outputCountry.Text = "";
                outputLimit.Text = "";
                outputBalance.Text = "";
                outputStatus.Text = "";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CreditCard c = new CreditCard();
            c.Load(inputCardNum.Text);
            c.Print();
        }
    }
}
