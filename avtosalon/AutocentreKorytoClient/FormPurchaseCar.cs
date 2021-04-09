using AutocentreKorytoClientBusinessLogics.BusinessLogics;
using AutocentreKorytoClientBusinessLogics.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using System.Linq;

namespace AutocentreKorytoClientView
{
    public partial class FormPurchaseCar : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        List<CarViewModel> list;

        public int Id
        {
            get { return Convert.ToInt32(comboBoxCar.SelectedValue); }
            set { comboBoxCar.SelectedValue = value; }
        }

        public string CarName { get { return comboBoxCar.Text; } }

        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }

        public decimal Price
        {
            get { return Convert.ToDecimal(textBoxPrice.Text); }

            set { textBoxPrice.Text = value.ToString(); }
        }

        public FormPurchaseCar(CarLogic logic)
        {
            InitializeComponent();

            list = logic.Read(null);

            if (list != null)
            {
                comboBoxCar.DisplayMember = "CarName";
                comboBoxCar.ValueMember = "Id";
                comboBoxCar.DataSource = list;
                comboBoxCar.SelectedItem = null;

                textBoxPrice.Text = null;
            }
        }

        private void ComboBoxCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCar.SelectedValue != null)
            {
                textBoxPrice.Text = list.FirstOrDefault(x => x.Id == Id).CarPrice.ToString();
            }
            Id = Convert.ToInt32(comboBoxCar.SelectedValue);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxCar.SelectedValue == null)
            {
                MessageBox.Show("Выберите машину", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
