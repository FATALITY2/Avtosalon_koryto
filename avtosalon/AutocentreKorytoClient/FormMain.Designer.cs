
namespace AutocentreKorytoView
{
    partial class FormMain
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.покупкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.машиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оплатаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.затратыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.покупочныйОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.машинныйОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетПоПокупкамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетПоМашинамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AutocentreKorytoClient.Properties.Resources.корыто;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(723, 367);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.покупкиToolStripMenuItem,
            this.машиныToolStripMenuItem,
            this.оплатаToolStripMenuItem,
            this.затратыToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(772, 24);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip1";
            // 
            // покупкиToolStripMenuItem
            // 
            this.покупкиToolStripMenuItem.Name = "покупкиToolStripMenuItem";
            this.покупкиToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.покупкиToolStripMenuItem.Text = "Покупки";
            this.покупкиToolStripMenuItem.Click += new System.EventHandler(this.покупкиToolStripMenuItem_Click);
            // 
            // машиныToolStripMenuItem
            // 
            this.машиныToolStripMenuItem.Name = "машиныToolStripMenuItem";
            this.машиныToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.машиныToolStripMenuItem.Text = "Автомобили";
            this.машиныToolStripMenuItem.Click += new System.EventHandler(this.машиныToolStripMenuItem_Click);
            // 
            // оплатаToolStripMenuItem
            // 
            this.оплатаToolStripMenuItem.Name = "оплатаToolStripMenuItem";
            this.оплатаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.оплатаToolStripMenuItem.Text = "Оплата";
            this.оплатаToolStripMenuItem.Click += new System.EventHandler(this.оплатаToolStripMenuItem_Click);
            // 
            // затратыToolStripMenuItem
            // 
            this.затратыToolStripMenuItem.Name = "затратыToolStripMenuItem";
            this.затратыToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.затратыToolStripMenuItem.Text = "Затраты";
            this.затратыToolStripMenuItem.Click += new System.EventHandler(this.затратыToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.покупочныйОтчетToolStripMenuItem,
            this.машинныйОтчетToolStripMenuItem,
            this.отчетПоПокупкамToolStripMenuItem,
            this.отчетПоМашинамToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // покупочныйОтчетToolStripMenuItem
            // 
            this.покупочныйОтчетToolStripMenuItem.Name = "покупочныйОтчетToolStripMenuItem";
            this.покупочныйОтчетToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.покупочныйОтчетToolStripMenuItem.Text = "Отчет по покупкам за период";
            this.покупочныйОтчетToolStripMenuItem.Click += new System.EventHandler(this.отчетПоПокупкамToolStripMenuItem_Click_1);
            // 
            // машинныйОтчетToolStripMenuItem
            // 
            this.машинныйОтчетToolStripMenuItem.Name = "машинныйОтчетToolStripMenuItem";
            this.машинныйОтчетToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.машинныйОтчетToolStripMenuItem.Text = "Отчет по машинам за период";
            this.машинныйОтчетToolStripMenuItem.Click += new System.EventHandler(this.отчетПоМашинамToolStripMenuItem_Click);
            // 
            // отчетПоПокупкамToolStripMenuItem
            // 
            this.отчетПоПокупкамToolStripMenuItem.Name = "отчетПоПокупкамToolStripMenuItem";
            this.отчетПоПокупкамToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.отчетПоПокупкамToolStripMenuItem.Text = "Отчет по покупкам";
            this.отчетПоПокупкамToolStripMenuItem.Click += new System.EventHandler(this.отчетПоПокупкамЗаПериодToolStripMenuItem_Click);
            // 
            // отчетПоМашинамToolStripMenuItem
            // 
            this.отчетПоМашинамToolStripMenuItem.Name = "отчетПоМашинамToolStripMenuItem";
            this.отчетПоМашинамToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.отчетПоМашинамToolStripMenuItem.Text = "Отчет по машинам";
            this.отчетПоМашинамToolStripMenuItem.Click += new System.EventHandler(this.отчетПоМашинамЗаПериодToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 417);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormMain";
            this.Text = "Главная";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem покупкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem машиныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оплатаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem затратыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem покупочныйОтчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem машинныйОтчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетПоПокупкамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетПоМашинамToolStripMenuItem;
    }
}