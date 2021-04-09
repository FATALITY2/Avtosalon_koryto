using AutocentreKorytoClientBusinessLogics.BindingModels;
using AutocentreKorytoClientBusinessLogics.BusinessLogics;
using AutocentreKorytoClientBusinessLogics.ViewModels;
using System;
using System.Windows.Forms;
using Unity;
using Microsoft.EntityFrameworkCore;

namespace AutocentreKorytoClientView
{
    public partial class FormCar : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly CarLogic logic;
        private int? id;

        public FormCar(CarLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        CarViewModel view;

        private void FormCar_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    view = logic.Read(new CarBindingModel { Id = id })?[0];

                    if (view != null)
                    {
                        textBoxName.Text = view.CarName;
                        textBoxEquipment.Text = view.Equipment;
                        textBoxPrice.Text = view.CarPrice.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxEquipment.Text))
            {
                MessageBox.Show("Заполните материал", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (view != null)
                {
                    logic.UpdateCar(new CarBindingModel
                    {
                        Id = id,
                        UserId = view.UserId,
                        CarName = textBoxName.Text,
                        Equipment = textBoxEquipment.Text,
                        CarPrice = Convert.ToDecimal(textBoxPrice.Text),
                        DateOfCreation = view.DateOfCreation
                    });
                }
                else
                {
                    logic.CreateCar(new CarBindingModel
                    {
                        Id = id,
                        UserId = Program.User.Id,
                        CarName = textBoxName.Text,
                        Equipment = textBoxEquipment.Text,
                        CarPrice = Convert.ToDecimal(textBoxPrice.Text),
                        DateOfCreation = DateTime.Now,
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

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
