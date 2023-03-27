using System;
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
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace Immovables.Pages
{
    /// <summary>
    /// Interaction logic for ContractsAddEditPage.xaml
    /// </summary>
    public partial class ContractsAddEditPage : Page
    {
        private Contract _currentperson = new Contract(); //экземпляр добавляемого пользователя
        public ContractsAddEditPage(Contract selectedUser)
        {
            InitializeComponent();
            if (selectedUser != null)
                _currentperson = selectedUser;
            DataContext = _currentperson;
            CmbFiltrAdress.ItemsSource = RealtorEntities.GetContext().Buildings.ToList();
            CmbFiltrAdress.SelectedValuePath = "IDBuilding";
            CmbFiltrAdress.DisplayMemberPath = "Adress";
            CmbFiltrEmployee.ItemsSource = RealtorEntities.GetContext().Employees.ToList();
            CmbFiltrEmployee.SelectedValuePath = "IdEmployee";
            CmbFiltrEmployee.DisplayMemberPath = "SurName";
            CmbFiltrClient.ItemsSource = RealtorEntities.GetContext().Clients.ToList();
            CmbFiltrClient.SelectedValuePath = "IDClient";
            CmbFiltrClient.DisplayMemberPath = "SurName";
            datePicker1.Text = DateTime.Now.Date.ToString();
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();// Объект для сообщение об ошибке
            //проверка полей объекта
            if (string.IsNullOrWhiteSpace(CmbFiltrEmployee.Text))
                error.AppendLine("Укажите сотрудника!");
            if (string.IsNullOrWhiteSpace(CmbFiltrClient.Text))
                error.AppendLine("Укажите клиента!");
            if (string.IsNullOrWhiteSpace(datePicker1.Text))
                error.AppendLine("Укажите дату начала аренды!");
            if (string.IsNullOrWhiteSpace(CmbFiltrAdress.Text))
                error.AppendLine("Укажите адрес!");
            if (string.IsNullOrWhiteSpace(datePicker2.Text))
                error.AppendLine("Укажите дату окончания аренды!");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            if (_currentperson.IDContract == 0)
                RealtorEntities.GetContext().Contracts.Add(_currentperson);//Добавить в контекст
            try
            {
                RealtorEntities.GetContext().SaveChanges();// Сохранить изменения
                MessageBox.Show("Данные сохраненны");
                this.NavigationService.Navigate(new ContractsPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void CmbFiltrAdress_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbFiltrEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbFiltrClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
