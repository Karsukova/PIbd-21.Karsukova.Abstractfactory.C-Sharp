using AbstractFactoryServiceDAL.BindingModel;
using AbstractFactoryServiceDAL.ViewModel;
using AbstractFactoryServiceDAL.Interfaces;
using AbstractFactoryModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AbstractFactoryView
{
    public partial class FormZBI : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private List<ZBIMaterialViewModel> zbiMaterials;
        public FormZBI()
        {
            InitializeComponent();
        }

        private void FormZBI_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ZBIViewModel view = APICustomer.GetRequest<ZBIViewModel>("api/Client/Get/" + id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.ZBIName;
                        textBoxPrice.Text = view.Price.ToString();
                        zbiMaterials = view.ZBIMaterials;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                zbiMaterials = new List<ZBIMaterialViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (zbiMaterials != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = zbiMaterials;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new FormZBIMaterialCount();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.ZBIId = id.Value;
                    }
                    zbiMaterials.Add(form.Model);
                }
                LoadData();
            }
        }
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = new FormZBIMaterialCount();
                form.Model =
               zbiMaterials[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    zbiMaterials[dataGridView.SelectedRows[0].Cells[0].RowIndex] =
                   form.Model;
                    LoadData();
                }
            }
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        zbiMaterials.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
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
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (zbiMaterials == null || zbiMaterials.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<ZBIMaterialBindingModel> zbiMaterialBM = new
               List<ZBIMaterialBindingModel>();
                for (int i = 0; i < zbiMaterials.Count; ++i)
                {
                    zbiMaterialBM.Add(new ZBIMaterialBindingModel
                    {
                        Id = zbiMaterials[i].Id,
                        ZBIId = zbiMaterials[i].ZBIId,
                        MaterialId = zbiMaterials[i].MaterialId,
                        Count = zbiMaterials[i].Count
                    });
                }
                if (id.HasValue)
                {
                    APICustomer.PostRequest<ZBIBindingModel,
                    bool>("api/ZBI/UpdElement", new ZBIBindingModel
                    {
                        Id = id.Value,
                        ZBIName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        ZBIMaterials = zbiMaterialBM
                    });
                }
                else
                {
                    APICustomer.PostRequest<ZBIBindingModel,
                      bool>("api/ZBI/AddElement", new ZBIBindingModel
                      {
                        ZBIName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        ZBIMaterials = zbiMaterialBM
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