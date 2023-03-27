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

namespace Immovables.Pages
{
    /// <summary>
    /// Interaction logic for ClientsAddEditPage.xaml
    /// </summary>
    public partial class ClientsAddEditPage : Page
    {
        private Client _currentperson = new Client(); //экземпляр добавляемого пользователя
        public ClientsAddEditPage(Client selectedUser)
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
            if (string.IsNullOrWhiteSpace(_currentperson.Passport))
                error.AppendLine("Укажите Паспортные данные");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            if (_currentperson.IDClient == 0)
                RealtorEntities.GetContext().Clients.Add(_currentperson);//Добавить в контекст
            try
            {

                RealtorEntities.GetContext().SaveChanges();// Сохранить изменения
                MessageBox.Show("Данные сохраненны");
                this.NavigationService.Navigate(new ClientsPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnPrintPerson_Click(object sender, RoutedEventArgs e)
        {
            //PrintDialog printDialog = new PrintDialog();
            //if (printDialog.ShowDialog() == true)
            //{

            //    printDialog.PrintVisual(Gridedit, "");
            //    Gridedit.LayoutTransform = null;

            //}
            //else
            //{
            //    MessageBox.Show("Пользователь прервал печать", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            //    return;
            //}
        }
    }
}
