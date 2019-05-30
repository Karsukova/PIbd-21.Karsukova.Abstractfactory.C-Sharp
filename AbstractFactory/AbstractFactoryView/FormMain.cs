﻿using System;
using System.Collections.Generic;
using AbstractFactoryServiceDAL.BindingModel;
using AbstractFactoryServiceDAL.ViewModel;
using AbstractFactoryServiceDAL.Interfaces;
using AbstractFactoryModel;
using System.Windows.Forms;
using Unity;

namespace AbstractFactoryView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public readonly IMainService service;
        public readonly IReptService Reptservice;
        public FormMain(IMainService service, IReptService Reptservice)
        {
            InitializeComponent();
            this.service = service;
            this.Reptservice = Reptservice;
        }
        private void LoadData()
        {

            try
            {
                List<OrderViewModel> list = service.GetList();
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
       
      
        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCustomers>();
            form.ShowDialog();
        }
        private void компонентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormMaterials>();
            form.ShowDialog();
        }
        private void изделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormZBIs>();
            form.ShowDialog();
        }
        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }
        private void складыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormStorages>();
            form.ShowDialog();
        }

        private void пополнитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPutOnStorage>();
            form.ShowDialog();
        }
        private void buttonTakeOrderInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    service.TakeOrderInWork(new OrderBindingModel { Id = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonOrderReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    service.FinishOrder(new OrderBindingModel { Id = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void buttonPayOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    service.PayOrder(new OrderBindingModel { Id = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void прайсИзделийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "doc|*.doc|docx|*.docx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Reptservice.SaveZBIPrice(new ReptBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void загруженностьСкладовToolStripMenuItem_Click(object sender, EventArgs
       e)
        {
            var form = Container.Resolve<FormStoragesLoad>();

            form.ShowDialog();
        }
        private void заказыКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCustomerOrders>();
            form.ShowDialog();
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }


    }
}
