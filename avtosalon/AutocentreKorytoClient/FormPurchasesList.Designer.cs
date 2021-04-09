
namespace AutocentreKorytoView
{
    partial class FormPurchasesList
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnPurchaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonToExcel = new System.Windows.Forms.Button();
            this.buttonToWord = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPurchaseName,
            this.ColumnCarName,
            this.ColumnCount});
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(639, 333);
            this.dataGridView.TabIndex = 14;
            // 
            // ColumnPurchaseName
            // 
            this.ColumnPurchaseName.HeaderText = "Покупка";
            this.ColumnPurchaseName.Name = "ColumnPurchaseName";
            this.ColumnPurchaseName.Width = 250;
            // 
            // ColumnCarName
            // 
            this.ColumnCarName.HeaderText = "Машина";
            this.ColumnCarName.Name = "ColumnCarName";
            this.ColumnCarName.Width = 206;
            // 
            // ColumnCount
            // 
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.Width = 140;
            // 
            // buttonToExcel
            // 
            this.buttonToExcel.Location = new System.Drawing.Point(131, 351);
            this.buttonToExcel.Name = "buttonToExcel";
            this.buttonToExcel.Size = new System.Drawing.Size(102, 35);
            this.buttonToExcel.TabIndex = 13;
            this.buttonToExcel.Text = "Excel";
            this.buttonToExcel.UseVisualStyleBackColor = true;
            this.buttonToExcel.Click += new System.EventHandler(this.buttonToExcel_Click);
            // 
            // buttonToWord
            // 
            this.buttonToWord.Location = new System.Drawing.Point(23, 351);
            this.buttonToWord.Name = "buttonToWord";
            this.buttonToWord.Size = new System.Drawing.Size(102, 35);
            this.buttonToWord.TabIndex = 12;
            this.buttonToWord.Text = "Word";
            this.buttonToWord.UseVisualStyleBackColor = true;
            this.buttonToWord.Click += new System.EventHandler(this.buttonToWord_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(536, 351);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(102, 35);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormPurchasesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 397);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonToExcel);
            this.Controls.Add(this.buttonToWord);
            this.Controls.Add(this.buttonCancel);
            this.Name = "FormPurchasesList";
            this.Text = "FormPurchasesList";
            this.Load += new System.EventHandler(this.FormPurchasesList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPurchaseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
        private System.Windows.Forms.Button buttonToExcel;
        private System.Windows.Forms.Button buttonToWord;
        private System.Windows.Forms.Button buttonCancel;
    }
}