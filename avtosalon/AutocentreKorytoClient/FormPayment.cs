using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutocentreKorytoClient
{
    public partial class FormPayment : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly PurchaseLogic _logicPurchase;

        private readonly PaymentLogic _logicPayment;

        private decimal DifferenceOfNumbers { get; set; }

        private int Id { get; set; }

        private Dictionary<int, (string, int, decimal)> purchaseCar;

        List<PurchaseViewModel> listPurchase;

        PurchaseViewModel viewPurchase;

        PaymentViewModel viewPayment;

        public FormPayment(PurchaseLogic logicPurchase, PaymentLogic logicPayment)
        {
            InitializeComponent();
            _logicPurchase = logicPurchase;
            _logicPayment = logicPayment;
        }

        private void FormPayment_Load(object sender, EventArgs e)
        {
            try
            {
                listPurchase = _logicPurchase.Read(null);

                foreach (var item in listPurchase)
                {
                    comboBoxPurchase.DisplayMember = "PurchaseName";
                    comboBoxPurchase.ValueMember = "Id";
                    comboBoxPurchase.DataSource = listPurchase.Where(x => x.UserId == Program.User.Id).ToList();
                    comboBoxPurchase.SelectedItem = null;
                }
                textBoxTotalSum.Text = null;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ComboBoxPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(comboBoxPurchase.SelectedValue);
            if (comboBoxPurchase.SelectedValue != null && Id != 0)
            {
                viewPurchase = _logicPurchase.Read(new PurchaseBindingModel { Id = Id })?[0];
                var sumPurchase = listPurchase.FirstOrDefault(x => x.Id == Id).PurchaseSumToPayment;
                if (sumPurchase == null)
                {
                    textBoxTotalSum.Text = listPurchase.FirstOrDefault(x => x.Id == Id).PurchaseSum.ToString();
                }
                else
                {
                    textBoxTotalSum.Text = sumPurchase.ToString();
                }
                viewPayment = _logicPayment.Read(new PaymentBindingModel { PurchaseId = Id })?[0];
                if (viewPurchase != null)
                {
                    purchaseCar = viewPurchase.PurchaseCar;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSum.Text))
            {
                MessageBox.Show("Заполните поле Внесённая сумма", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxTotalSum.Text))
            {
                MessageBox.Show("Заполните поле Сумма к оплате", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxPurchase.SelectedValue == null)
            {
                MessageBox.Show("Выберите покупку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (Convert.ToDecimal(textBoxTotalSum.Text) >= Convert.ToDecimal(textBoxSum.Text))
                {
                    DifferenceOfNumbers = Convert.ToDecimal(textBoxTotalSum.Text) - Convert.ToDecimal(textBoxSum.Text);
                    if (listPurchase != null)
                    {
                        _logicPurchase.UpdatePurchase(new PurchaseBindingModel
                        {
                            Id = viewPurchase.Id,
                            UserId = Program.User.Id,
                            PurchaseName = viewPurchase.PurchaseName,
                            PurchaseSum = viewPurchase.PurchaseSum,
                            DateOfCreation = viewPurchase.DateOfCreation,
                            PurchaseCars = viewPurchase.PurchaseCar
                        });

                        if (viewPayment != null)
                        {
                            _logicPayment.CreateOrUpdate(new PaymentBindingModel
                            {
                                Id = viewPayment.Id,
                                PurchaseId = viewPurchase.Id,
                                PaymentSum = DifferenceOfNumbers,
                                DateOfPayment = DateTime.Now
                            });
                        }
                        else
                        {
                            _logicPayment.CreateOrUpdate(new PaymentBindingModel
                            {
                                PurchaseId = viewPurchase.Id,
                                PaymentSum = DifferenceOfNumbers,
                                DateOfPayment = DateTime.Now
                            });
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Внесённая сумма больше необходимой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
