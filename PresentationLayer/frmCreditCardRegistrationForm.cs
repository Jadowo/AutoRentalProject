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
    public partial class frmCreditCardRegistrationForm : Form
    {
        public frmCreditCardRegistrationForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            USState state = outputState.SelectedItem as USState;
            Country country = outputCountry.SelectedItem as Country;
            CreditCard c = new CreditCard();
            c.CreditCardNumber = outputCardNum.Text;
            c.CreditCardOwnerName = outputCardName.Text;
            c.MerchantName = outputCardCompany.Text;
            c.ExpDate = DateTime.Parse(outputCardExpDate.Text); 
            c.AddressLine1 = outputAddress1.Text;
            c.AddressLine2 = outputAddress2.Text;
            c.City = outputCity.Text;
            c.StateCode = state.StateCode;
            c.ZipCode = outputZip.Text;
            c.Country = country.CountryName;
            c.CreditCardLimit = Decimal.Parse(outputLimit.Text);
            c.CreditCardBalance = Decimal.Parse(outputBalance.Text);
            if (c.Insert())
            {
                lblcon.Text = "Inserted";
            }
            else
            {
                lblcon.Text = "Error";
            }
        }

        private void frmCreditCardRegistrationForm_Load(object sender, EventArgs e)
        {
            List<USState> alls = USState.GetAllUSStates();
            List<Country> allc = Country.GetAllCountrys();

            BindingSource bsState = new BindingSource();
            BindingSource bsCountry = new BindingSource();
            bsState.DataSource = alls;
            bsCountry.DataSource = allc;

            outputState.DataSource = bsState.DataSource;
            outputCountry.DataSource = bsCountry.DataSource;

            outputState.DisplayMember = "StateCode";
            outputState.ValueMember = "StateCode";
            outputCountry.DisplayMember = "CountryName";
            outputCountry.ValueMember = "CountryName";


        }
        

    }
}
