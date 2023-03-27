using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
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
    /// Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
            ListClients.ItemsSource = RealtorEntities.GetContext().Clients.ToList();
        }

        private void editclient_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new ClientsAddEditPage((Client)ListClients.SelectedItem));
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var personForRemoving = ListClients.SelectedItems.Cast<Client>().ToList();
            var resMessage = MessageBox.Show("Удалить запись?", "Подтверждение",
             MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resMessage == MessageBoxResult.Yes)
            {
                try
                {
                    RealtorEntities.GetContext().Clients.RemoveRange(personForRemoving);
                    RealtorEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    ListClients.ItemsSource = RealtorEntities.GetContext().Clients.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Данный клиент арендует помещение", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.ClientsAddEditPage(null));
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CmbFiltrSort.Text == "По фамилии")
                ListClients.ItemsSource = RealtorEntities.GetContext().Clients.Where(x => x.SurName.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По имени")
                ListClients.ItemsSource = RealtorEntities.GetContext().Clients.Where(x => x.FirstName.ToString().ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По отчеству")
                ListClients.ItemsSource = RealtorEntities.GetContext().Clients.Where(x => x.Patron.ToString().ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По номеру телефона")
                ListClients.ItemsSource = RealtorEntities.GetContext().Clients.Where(x => x.PhoneNumber.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По паспорту")
                ListClients.ItemsSource = RealtorEntities.GetContext().Clients.Where(x => x.Passport.ToString().ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }

        private void CmbFiltrSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (RbDown.IsChecked == true)
            {
                if (CmbFiltrSort.Text == "По фамилии")
                    ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderByDescending(x => x.SurName).ToList();
                if (CmbFiltrSort.Text == "По имени")
                    ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderByDescending(x => x.FirstName).ToList();
                if (CmbFiltrSort.Text == "По отчеству")
                    ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderByDescending(x => x.Patron).ToList();
                if (CmbFiltrSort.Text == "По номеру телефона")
                    ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderByDescending(x => x.PhoneNumber).ToList();
                if (CmbFiltrSort.Text == "По паспорту")
                    ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderByDescending(x => x.Passport).ToList();
            }
            if (RbUp.IsChecked == true)
            {
                if (CmbFiltrSort.Text == "По фамилии")
                    ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderBy(x => x.SurName).ToList();
                if (CmbFiltrSort.Text == "По имени")
                    ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderBy(x => x.FirstName).ToList();
                if (CmbFiltrSort.Text == "По отчеству")
                    ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderBy(x => x.Patron).ToList();
                if (CmbFiltrSort.Text == "По номеру телефона")
                    ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderBy(x => x.PhoneNumber).ToList();
                if (CmbFiltrSort.Text == "По паспорту")
                    ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderBy(x => x.Passport).ToList();
            }
            }

        private void RbUp_Checked(object sender, RoutedEventArgs e)
        {
            if (CmbFiltrSort.Text == "По фамилии")
                ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderBy(x => x.SurName).ToList();
            if (CmbFiltrSort.Text == "По имени")
                ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderBy(x => x.FirstName).ToList();
            if (CmbFiltrSort.Text == "По отчеству")
                ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderBy(x => x.Patron).ToList();
            if (CmbFiltrSort.Text == "По номеру телефона")
                ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderBy(x => x.PhoneNumber).ToList();
            if (CmbFiltrSort.Text == "По паспорту")
                ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderBy(x => x.Passport).ToList();
        }

        private void RbDown_Checked(object sender, RoutedEventArgs e)
        {
            if (CmbFiltrSort.Text == "По фамилии")
                ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderByDescending(x => x.SurName).ToList();
            if (CmbFiltrSort.Text == "По имени")
                ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderByDescending(x => x.FirstName).ToList();
            if (CmbFiltrSort.Text == "По отчеству")
                ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderByDescending(x => x.Patron).ToList();
            if (CmbFiltrSort.Text == "По номеру телефона")
                ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderByDescending(x => x.PhoneNumber).ToList();
            if (CmbFiltrSort.Text == "По паспорту")
                ListClients.ItemsSource = RealtorEntities.GetContext().Clients.OrderByDescending(x => x.Passport).ToList();
        }
    }
}
