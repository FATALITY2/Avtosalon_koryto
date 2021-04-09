using AutocentreKorytoBusinessLogics.BindingModels;
using AutocentreKorytoBusinessLogics.BusinessLogics;
using AutocentreKorytoBusinessLogics.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using Microsoft.EntityFrameworkCore;

namespace AutocentreKorytoView
{
    public partial class FormPurchase : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly PurchaseLogic logicPurchase;

        private readonly PaymentLogic logicPayment;

        private int? id;

        private decimal Price { get; set; }

        private Dictionary<int, (string, int, decimal)> purchaseCar;

        public FormPurchase(PurchaseLogic logicPurchase, PaymentLogic logicPayment)
        {
            InitializeComponent();
            this.logicPurchase = logicPurchase;
            this.logicPayment = logicPayment;
        }

        PurchaseViewModel viewPurchase;

        PaymentViewModel viewPayment;

        private void FormPurchase_Load(object sender, EventArgs e)
        {

        }



        private void LoadData()
        {
            try
            {
                if (purchaseCar != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in purchaseCar)
                    {
                        Price += pc.Value.Item3 * pc.Value.Item2;
                        textBoxPrice.Text = Price.ToString();
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2, pc.Value.Item3 });
                    }
                    Price = 0;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPurchaseCar>();

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (purchaseCar.ContainsKey(form.Id))
                {
                    purchaseCar[form.Id] = (form.CarName, form.Count, form.Price);
                }

                else
                {
                    purchaseCar.Add(form.Id, (form.CareName, form.Count, form.Price));
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormPurchaseCar>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = purchaseCar[id].Item2;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    purchaseCar[form.Id] = (form.CarName, form.Count, form.Price);
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        purchaseCar.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (purchaseCar == null || purchaseCar.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (viewPurchase != null)
                {
                    logicPurchase.UpdatePurchase(new PurchaseBindingModel
                    {
                        Id = viewPurchase.Id,
                        UserId = Program.User.Id,
                        PurchaseName = textBoxName.Text,
                        PurchaseSum = Convert.ToDecimal(textBoxPrice.Text),
                        DateOfCreation = viewPurchase.DateOfCreation,
                        PurchaseCars = purchaseCar,
                    });
                }
                else
                {
                    logicPurchase.CreatePurchase(new PurchaseBindingModel
                    {
                        Id = id,
                        UserId = Program.User.Id,
                        PurchaseName = textBoxName.Text,
                        PurchaseSum = Convert.ToDecimal(textBoxPrice.Text),
                        DateOfCreation = DateTime.Now,
                        PurchaseCars = purchaseCar,
                    });
                }

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }

            catch (DbUpdateException exe)
            {
                MessageBox.Show(exe?.InnerException?.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
