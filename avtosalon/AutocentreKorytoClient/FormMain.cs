using AutocentreKorytoClientBusinessLogics.BindingModels;
using AutocentreKorytoClientBusinessLogics.BusinessLogics;
using System;
using AutocentreKorytoClientBusinessLogics.ViewModels;
using AutocentreKorytoClientBusinessLogics.Enums;
using System.Windows.Forms;
using Unity;
using System.Collections.Generic;

namespace AutocentreKorytoClientView
{
    public partial class FormMain : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        private void покупкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User.Role == (UserRole)0)
            {
                var form = Container.Resolve<FormPurchases>();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Совершать покупки может только клиент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void машиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User.Role == (UserRole)1)
            {
                var form = Container.Resolve<FormCars>();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Работать с машинами может только сотрудник", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void оплатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User.Role == (UserRole)0)
            {
                var form = Container.Resolve<FormPayment>();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Совершать оплату может только клиент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void затратыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User.Role == (UserRole)1)
            {
                var form = Container.Resolve<FormCosts>();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Формировать затраты может только сотрудник", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void отчетПоПокупкамToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void отчетПоМашинамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User.Role == (UserRole)1)
            {
                var form = Container.Resolve<FormReportCars>();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Получать отчет по машинам может только сотрудник", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void отчетПоПокупкамЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User.Role == (UserRole)0)
            {
                var form = Container.Resolve<FormPurchasesList>();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Получать отчет по покупкам за период может только клиент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void отчетПоМашинамЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.User.Role == (UserRole)1)
            {
                var form = Container.Resolve<FormCarList>();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Получать отчет по машинам за период может только сотрудник", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
