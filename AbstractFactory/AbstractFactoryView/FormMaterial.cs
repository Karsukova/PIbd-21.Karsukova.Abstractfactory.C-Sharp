using AbstractFactoryServiceDAL.BindingModel;
using AbstractFactoryServiceDAL.ViewModel;
using AbstractFactoryServiceDAL.Interfaces;
using AbstractFactoryModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace AbstractFactoryView
{
    public partial class FormMaterial : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        public FormMaterial()
        {
            InitializeComponent();
        }


        private void FormMaterial_Load(object sender, EventArgs e)
        {

            if (id.HasValue)
            {
                try
                {
                    MaterialViewModel view = APICustomer.GetRequest<MaterialViewModel>("api/Material/Get/" + id.Value);
                    if (view != null)
                    {
                        textBoxMaterial.Text = view.MaterialName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMaterial.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APICustomer.PostRequest<MaterialBindingModel,
                   bool>("api/Material/UpdElement", new MaterialBindingModel
                   {
                        Id = id.Value,
                        MaterialName = textBoxMaterial.Text
                    });
                }
                else
                {
                    APICustomer.PostRequest<MaterialBindingModel,
                     bool>("api/Material/AddElement", new MaterialBindingModel
                     {
                        MaterialName = textBoxMaterial.Text
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}