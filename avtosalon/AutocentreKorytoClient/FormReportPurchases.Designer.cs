
namespace AutocentreKorytoClientView
{
    partial class FormReportPurchases
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
            this.labelTo = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.buttonToEmail = new System.Windows.Forms.Button();
            this.buttonMake = new System.Windows.Forms.Button();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(162, 9);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(21, 13);
            this.labelTo.TabIndex = 11;
            this.labelTo.Text = "По";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(12, 9);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(14, 13);
            this.labelFrom.TabIndex = 10;
            this.labelFrom.Text = "С";
            // 
            // buttonToEmail
            // 
            this.buttonToEmail.Location = new System.Drawing.Point(630, 2);
            this.buttonToEmail.Name = "buttonToEmail";
            this.buttonToEmail.Size = new System.Drawing.Size(96, 20);
            this.buttonToEmail.TabIndex = 9;
            this.buttonToEmail.Text = "На почту";
            this.buttonToEmail.UseVisualStyleBackColor = true;
            this.buttonToEmail.Click += new System.EventHandler(this.buttonToEmail_Click);
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(523, 2);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(96, 20);
            this.buttonMake.TabIndex = 8;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(189, 5);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(111, 20);
            this.dateTimePickerTo.TabIndex = 7;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(32, 5);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(111, 20);
            this.dateTimePickerFrom.TabIndex = 6;
            // 
            // FormReportPurchases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.buttonToEmail);
            this.Controls.Add(this.buttonMake);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Name = "FormReportPurchases";
            this.Text = "FormReportPurchases";
            this.Load += new System.EventHandler(this.FormReportPurchases_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Button buttonToEmail;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
    }
}