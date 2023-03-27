﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Immovables.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAddEditPage.xaml
    /// </summary>
    public partial class EmployeeAddEditPage : Page
    {
        private Employee _currentperson = new Employee(); //экземпляр добавляемого пользователя
        public EmployeeAddEditPage(Employee selectedUser)
        {
            InitializeComponent();
            if (selectedUser != null)
                _currentperson = selectedUser;
            DataContext = _currentperson;
        }



        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();// Объект для сообщение об ошибке
            //проверка полей объекта
            if (string.IsNullOrWhiteSpace(_currentperson.SurName))
                error.AppendLine("Укажите Фамилию");
            if (string.IsNullOrWhiteSpace(_currentperson.FirstName))
                error.AppendLine("Укажите Имя");
            if (string.IsNullOrWhiteSpace(_currentperson.PhoneNumber))
                error.AppendLine("Укажите Номер телефона формата +7(999)999-99-99");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            if (_currentperson.IdEmployee == 0)
                RealtorEntities.GetContext().Employees.Add(_currentperson);//Добавить в контекст
            try
            {

                RealtorEntities.GetContext().SaveChanges();// Сохранить изменения
                MessageBox.Show("Данные сохраненны");
                this.NavigationService.Navigate(new EmployeesPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
    }

