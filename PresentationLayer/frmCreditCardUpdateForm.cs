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
    public partial class frmCreditCardUpdateForm : Form
    {
        CreditCard c;
        public frmCreditCardUpdateForm()
        {
            InitializeComponent();
        }

        private void lblEnterInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCreditCardUpdateForm_Load(object sender, EventArgs e)
        {

            outputState.DataSource = USState.GetAllUSStates();
            outputCountry.DataSource = Country.GetAllCountrys();

            outputState.DisplayMember = "StateCode";
            outputState.ValueMember = "StateCode";
            outputCountry.DisplayMember = "CountryName";
            outputCountry.ValueMember = "CountryName";

                        
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<USState> state =  USState.GetAllUSStates();
            List<Country> country = Country.GetAllCountrys();
            c = new CreditCard();
            if (c.Load(inputCardNum.Text)){
                
                outputCardNum.Text = c.CreditCardNumber;
                outputCardName.Text = c.CreditCardOwnerName;
                outputCardCompany.Text = c.MerchantName;
                outputCardExpDate.Value = c.ExpDate;
                outputAddress1.Text = c.AddressLine1;
                outputAddress2.Text = c.AddressLine2;
                outputCity.Text = c.City;
                foreach (USState s in state)
                {
                    if (s.StateCode == c.StateCode)
                    {

                        outputState.SelectedIndex = s.StateID - 1;
                        break;

                    }
                }
                outputZip.Text = c.ZipCode;
                foreach (Country cou in country)
                {
                    if (cou.CountryName == c.Country)
                    {
                        outputCountry.SelectedIndex = cou.CountryID-1;
                        break;
                    }
                }
                outputLimit.Text = c.CreditCardLimit.ToString();
                outputBalance.Text = c.CreditCardBalance.ToString();
                if (c.ActivationStatus == true)
                {
                    outputStatus.SelectedIndex = 0;
                }
                else
                {
                    outputStatus.SelectedIndex = 1;
                }
            }
            else
            {
                outputCardNum.Text = "Not Found";
                outputCardName.Text = "";
                outputCardCompany.Text = "";
                outputCardExpDate.Value = DateTime.Now;
                outputAddress1.Text = "";
                outputAddress2.Text = "";
                outputCity.Text = "";
                outputState.SelectedItem = "";
                outputZip.Text = "";
                outputCountry.SelectedItem = "";
                outputLimit.Text = "";
                outputBalance.Text = "0.00";
                outputStatus.Text = "0.00";
                outputStatus.SelectedIndex = 1;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            USState state = outputState.SelectedItem as USState;
            Country country = outputCountry.SelectedItem as Country;
            Console.WriteLine("State: " + state +
                "\nStateID: " + state.StateID +
                "\nStateCode: " + state.StateCode + 
                "\nStateName: " + state.StateName);
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
            c.Update();
            
        }
    }
}
