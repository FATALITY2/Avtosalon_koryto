using AutocentreKorytoBusinessLogics.BindingModels;
using AutocentreKorytoBusinessLogics.BusinessLogics;
using AutocentreKorytoBusinessLogics.ViewModels;
using System;
using System.Windows.Forms;
using Unity;
using Microsoft.EntityFrameworkCore;

namespace AutocentreKorytoView
{
    public partial class FormBindingCosts : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly CostLogic logicC;
        private readonly CarLogic logicF;
        private int Id { get; set; }
        public decimal Sum { get; set; }

        CarViewModel carView;
        CostViewModel costView;

        public FormBindingCosts(CostLogic logicC, CarLogic logicF)
        {
            InitializeComponent();
            this.logicC = logicC;
            this.logicF = logicF;
        }

        private void FormCost_Load(object sender, EventArgs e)
        {
            try
            {
                var listCosts = logicC.Read(null);
                foreach (var c in listCosts)
                {
                    comboBoxCost.DisplayMember = "PurchaseName";
                    comboBoxCost.ValueMember = "Id";
                    comboBoxCost.DataSource = listCosts;
                    comboBoxCost.SelectedItem = null;
                }

                var listCars = logicF.Read(null);
                foreach (var f in listCars)
                {
                    comboBoxCar.DisplayMember = "CarName";
                    comboBoxCar.ValueMember = "Id";
                    comboBoxCar.DataSource = listCars;
                    comboBoxCar.SelectedItem = null;
                }
                labelCostSum.Text = $"{Sum}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxCost.SelectedValue == null)
            {
                MessageBox.Show("Выберите затрату", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxCar.SelectedValue == null)
            {
                MessageBox.Show("Выберите машину", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxAdditionalCost.Text))
            {
                MessageBox.Show("Заполните дополнительные затраты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt32(textBoxAdditionalCost.Text) < 0)
            {
                MessageBox.Show("Введите неотрицательную сумму дополнительных затрат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Id = Convert.ToInt32(comboBoxCost.SelectedValue);

                costView = logicC.Read(new CostBindingModel { Id = Id })?[0];

                logicC.CreateOrUpdate(new CostBindingModel
                {
                    Id = costView.Id,
                    PurchaseName = costView.PurchaseName,
                    Count = costView.Count,
                    Price = Sum + Convert.ToDecimal(textBoxAdditionalCost.Text)
                });

                Id = Convert.ToInt32(comboBoxCar.SelectedValue);

                carView = logicF.Read(new CarBindingModel { Id = Id })?[0];

                logicF.UpdateCar(new CarBindingModel
                {
                    Id = carView.Id,
                    UserId = carView.UserId,
                    CostsId = costView.Id,
                    CarName = carView.CarName,
                    Material = carView.Material,
                    CarPrice = carView.CarPrice,
                    DateOfCreation = carView.DateOfCreation
                });

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}