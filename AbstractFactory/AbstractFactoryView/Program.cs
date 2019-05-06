using AbstractFactoryServiceDAL.Interfaces;
using AbstractFactoryModel;
using AbstractFactoryServiceImplementDataBase;
using AbstractFactoryServiceImplementDataBase.Implementations;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Windows.Forms;
using AbstractFactoryView;

namespace AbstractFactoryView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            APICustomer.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
        
    }
}