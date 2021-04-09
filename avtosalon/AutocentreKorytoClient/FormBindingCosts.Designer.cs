
namespace AutocentreKorytoClientView
{
    partial class FormBindingCosts
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
            this.labelCostSum = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxAdditionalCost = new System.Windows.Forms.TextBox();
            this.labelAdditionalCost = new System.Windows.Forms.Label();
            this.labelCost = new System.Windows.Forms.Label();
            this.comboBoxCar = new System.Windows.Forms.ComboBox();
            this.comboBoxCost = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelCostSum
            // 
            this.labelCostSum.AutoSize = true;
            this.labelCostSum.Location = new System.Drawing.Point(165, 89);
            this.labelCostSum.Name = "labelCostSum";
            this.labelCostSum.Size = new System.Drawing.Size(0, 13);
            this.labelCostSum.TabIndex = 16;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(151, 158);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(60, 158);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // textBoxAdditionalCost
            // 
            this.textBoxAdditionalCost.Location = new System.Drawing.Point(163, 119);
            this.textBoxAdditionalCost.Name = "textBoxAdditionalCost";
            this.textBoxAdditionalCost.Size = new System.Drawing.Size(76, 20);
            this.textBoxAdditionalCost.TabIndex = 13;
            // 
            // labelAdditionalCost
            // 
            this.labelAdditionalCost.AutoSize = true;
            this.labelAdditionalCost.Location = new System.Drawing.Point(9, 122);
            this.labelAdditionalCost.Name = "labelAdditionalCost";
            this.labelAdditionalCost.Size = new System.Drawing.Size(143, 13);
            this.labelAdditionalCost.TabIndex = 12;
            this.labelAdditionalCost.Text = "Дополнительные затраты:";
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Location = new System.Drawing.Point(9, 89);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(146, 13);
            this.labelCost.TabIndex = 11;
            this.labelCost.Text = "Имеющаяся сумма затрат:";
            // 
            // comboBoxCar
            // 
            this.comboBoxCar.FormattingEnabled = true;
            this.comboBoxCar.Location = new System.Drawing.Point(12, 51);
            this.comboBoxCar.Name = "comboBoxCar";
            this.comboBoxCar.Size = new System.Drawing.Size(227, 21);
            this.comboBoxCar.TabIndex = 10;
            this.comboBoxCar.Text = "Выбранная машину";
            // 
            // comboBoxCost
            // 
            this.comboBoxCost.FormattingEnabled = true;
            this.comboBoxCost.Location = new System.Drawing.Point(12, 12);
            this.comboBoxCost.Name = "comboBoxCost";
            this.comboBoxCost.Size = new System.Drawing.Size(227, 21);
            this.comboBoxCost.TabIndex = 9;
            this.comboBoxCost.Text = "Выбранная статья затрат";
            // 
            // FormBindingCosts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 193);
            this.Controls.Add(this.labelCostSum);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxAdditionalCost);
            this.Controls.Add(this.labelAdditionalCost);
            this.Controls.Add(this.labelCost);
            this.Controls.Add(this.comboBoxCar);
            this.Controls.Add(this.comboBoxCost);
            this.Name = "FormBindingCosts";
            this.Text = "FormBindingCosts";
            this.Load += new System.EventHandler(this.FormCost_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCostSum;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxAdditionalCost;
        private System.Windows.Forms.Label labelAdditionalCost;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.ComboBox comboBoxCar;
        private System.Windows.Forms.ComboBox comboBoxCost;
    }
}