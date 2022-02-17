
namespace PresentationLayer
{
    partial class frmCreditCardDeleteForm
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
            this.label14 = new System.Windows.Forms.Label();
            this.inputCardNum = new System.Windows.Forms.TextBox();
            this.lblInputCardNum = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(24, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(294, 13);
            this.label14.TabIndex = 72;
            this.label14.Text = "Enter Credit Card Number you want to Delete and click Apply";
            // 
            // inputCardNum
            // 
            this.inputCardNum.Location = new System.Drawing.Point(110, 75);
            this.inputCardNum.Name = "inputCardNum";
            this.inputCardNum.Size = new System.Drawing.Size(154, 20);
            this.inputCardNum.TabIndex = 71;
            this.inputCardNum.TextChanged += new System.EventHandler(this.inputCardNum_TextChanged);
            // 
            // lblInputCardNum
            // 
            this.lblInputCardNum.AutoSize = true;
            this.lblInputCardNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputCardNum.Location = new System.Drawing.Point(24, 78);
            this.lblInputCardNum.Name = "lblInputCardNum";
            this.lblInputCardNum.Size = new System.Drawing.Size(69, 13);
            this.lblInputCardNum.TabIndex = 70;
            this.lblInputCardNum.Text = "Card Number";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(270, 73);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(65, 23);
            this.btnApply.TabIndex = 69;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(24, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(111, 13);
            this.lblTitle.TabIndex = 68;
            this.lblTitle.Text = "Credit Card Delete";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(282, 120);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(53, 23);
            this.btnExit.TabIndex = 74;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmCreditCardDeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 163);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.inputCardNum);
            this.Controls.Add(this.lblInputCardNum);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmCreditCardDeleteForm";
            this.Text = "Credit Card Delete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox inputCardNum;
        private System.Windows.Forms.Label lblInputCardNum;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnExit;
    }
}