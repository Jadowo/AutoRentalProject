
namespace PresentationLayer
{
    partial class frmCreditCardListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.gridCreditCard = new System.Windows.Forms.DataGridView();
            this.cohCreditCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cohCreditCardOwnerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cohCreditCardBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cohExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cohAddressLine1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cohAddressLine2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cohCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cohState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cohZipCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cohCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cohCreditCardLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cohCreditCardBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cohActivationStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditCardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridCreditCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditCardBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(25, 73);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "List All Credit Cards";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(22, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "List Credit Cards";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(22, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(195, 13);
            this.label14.TabIndex = 63;
            this.label14.Text = "Click List All Button to list all credit cards";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1219, 415);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(147, 23);
            this.btnExit.TabIndex = 65;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gridCreditCard
            // 
            this.gridCreditCard.AllowUserToAddRows = false;
            this.gridCreditCard.AllowUserToDeleteRows = false;
            this.gridCreditCard.AllowUserToResizeColumns = false;
            this.gridCreditCard.AllowUserToResizeRows = false;
            this.gridCreditCard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCreditCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridCreditCard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cohCreditCardNumber,
            this.cohCreditCardOwnerName,
            this.cohCreditCardBank,
            this.cohExpirationDate,
            this.cohAddressLine1,
            this.cohAddressLine2,
            this.cohCity,
            this.cohState,
            this.cohZipCode,
            this.cohCountry,
            this.cohCreditCardLimit,
            this.cohCreditCardBalance,
            this.cohActivationStatus});
            this.gridCreditCard.EnableHeadersVisualStyles = false;
            this.gridCreditCard.Location = new System.Drawing.Point(25, 120);
            this.gridCreditCard.MultiSelect = false;
            this.gridCreditCard.Name = "gridCreditCard";
            this.gridCreditCard.ReadOnly = true;
            this.gridCreditCard.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridCreditCard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCreditCard.Size = new System.Drawing.Size(1341, 276);
            this.gridCreditCard.TabIndex = 66;
            this.gridCreditCard.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cohCreditCardNumber
            // 
            this.cohCreditCardNumber.DataPropertyName = "CreditCardNumber";
            this.cohCreditCardNumber.HeaderText = "Card Number";
            this.cohCreditCardNumber.Name = "cohCreditCardNumber";
            this.cohCreditCardNumber.ReadOnly = true;
            // 
            // cohCreditCardOwnerName
            // 
            this.cohCreditCardOwnerName.DataPropertyName = "CreditCardOwnerName";
            this.cohCreditCardOwnerName.HeaderText = "Owner Name";
            this.cohCreditCardOwnerName.Name = "cohCreditCardOwnerName";
            this.cohCreditCardOwnerName.ReadOnly = true;
            // 
            // cohCreditCardBank
            // 
            this.cohCreditCardBank.DataPropertyName = "MerchantName";
            this.cohCreditCardBank.HeaderText = "Card Company";
            this.cohCreditCardBank.Name = "cohCreditCardBank";
            this.cohCreditCardBank.ReadOnly = true;
            // 
            // cohExpirationDate
            // 
            this.cohExpirationDate.DataPropertyName = "ExpDate";
            this.cohExpirationDate.HeaderText = "Expiration Date";
            this.cohExpirationDate.Name = "cohExpirationDate";
            this.cohExpirationDate.ReadOnly = true;
            // 
            // cohAddressLine1
            // 
            this.cohAddressLine1.DataPropertyName = "AddressLine1";
            this.cohAddressLine1.HeaderText = "Address Line 1";
            this.cohAddressLine1.Name = "cohAddressLine1";
            this.cohAddressLine1.ReadOnly = true;
            // 
            // cohAddressLine2
            // 
            this.cohAddressLine2.DataPropertyName = "AddressLine2";
            this.cohAddressLine2.HeaderText = "Address Line 2";
            this.cohAddressLine2.Name = "cohAddressLine2";
            this.cohAddressLine2.ReadOnly = true;
            // 
            // cohCity
            // 
            this.cohCity.DataPropertyName = "City";
            this.cohCity.HeaderText = "City";
            this.cohCity.Name = "cohCity";
            this.cohCity.ReadOnly = true;
            // 
            // cohState
            // 
            this.cohState.DataPropertyName = "StateCode";
            this.cohState.HeaderText = "State";
            this.cohState.Name = "cohState";
            this.cohState.ReadOnly = true;
            // 
            // cohZipCode
            // 
            this.cohZipCode.DataPropertyName = "ZipCode";
            this.cohZipCode.HeaderText = "ZipCode";
            this.cohZipCode.Name = "cohZipCode";
            this.cohZipCode.ReadOnly = true;
            // 
            // cohCountry
            // 
            this.cohCountry.DataPropertyName = "Country";
            this.cohCountry.HeaderText = "Country";
            this.cohCountry.Name = "cohCountry";
            this.cohCountry.ReadOnly = true;
            // 
            // cohCreditCardLimit
            // 
            this.cohCreditCardLimit.DataPropertyName = "CreditCardLimit";
            this.cohCreditCardLimit.HeaderText = "Credit Limit";
            this.cohCreditCardLimit.Name = "cohCreditCardLimit";
            this.cohCreditCardLimit.ReadOnly = true;
            // 
            // cohCreditCardBalance
            // 
            this.cohCreditCardBalance.DataPropertyName = "CreditCardBalance";
            this.cohCreditCardBalance.HeaderText = "Credit Balance";
            this.cohCreditCardBalance.Name = "cohCreditCardBalance";
            this.cohCreditCardBalance.ReadOnly = true;
            // 
            // cohActivationStatus
            // 
            this.cohActivationStatus.DataPropertyName = "ActivationStatus";
            this.cohActivationStatus.HeaderText = "Activation Status";
            this.cohActivationStatus.Name = "cohActivationStatus";
            this.cohActivationStatus.ReadOnly = true;
            // 
            // creditCardBindingSource
            // 
            this.creditCardBindingSource.DataSource = typeof(BusinessLayer.CreditCard);
            // 
            // frmCreditCardListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 450);
            this.Controls.Add(this.gridCreditCard);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmCreditCardListForm";
            this.Text = "Credit Card List";
            ((System.ComponentModel.ISupportInitialize)(this.gridCreditCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditCardBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView gridCreditCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn cohCreditCardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn cohCreditCardOwnerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cohCreditCardBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn cohExpirationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cohAddressLine1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cohAddressLine2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cohCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn cohState;
        private System.Windows.Forms.DataGridViewTextBoxColumn cohZipCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cohCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn cohCreditCardLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn cohCreditCardBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn cohActivationStatus;
        private System.Windows.Forms.BindingSource creditCardBindingSource;
    }
}