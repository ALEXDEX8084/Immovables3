using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    /// Interaction logic for ContractsPage.xaml
    /// </summary>
    public partial class ContractsPage : Page
    {
        public ContractsPage()
        {
            InitializeComponent();
            ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.ToList();
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var personForRemoving = ListContracts.SelectedItems.Cast<Contract>().ToList();
            var resMessage = MessageBox.Show("Удалить запись?", "Подтверждение",
             MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resMessage == MessageBoxResult.Yes)
            {
                try
                {
                    RealtorEntities.GetContext().Contracts.RemoveRange(personForRemoving);
                    RealtorEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Данное помещение нельзя удалить! Перед удалением помещения удалите арендатора и собственника помещения!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.ContractsAddEditPage(null));
        }

        private void editclient_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new ContractsAddEditPage((Contract)ListContracts.SelectedItem));
        }

        private void RbUp_Checked(object sender, RoutedEventArgs e)
        {
            if(CmbFiltrSort.Text == "По адресу")
            ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderBy(x => x.Building.Adress).ToList();
            if (CmbFiltrSort.Text == "По цене аренды(руб.)")
            ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderBy(x => x.Building.RentPrice).ToList();
            if (CmbFiltrSort.Text == "По площади(м3)")
            ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderBy(x => x.Building.ApartmentArea).ToList();
            if (CmbFiltrSort.Text == "По сотруднику")
            ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderBy(x => x.Employee.SurName).ToList();
            if (CmbFiltrSort.Text == "По собственнику")
            ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderBy(x => x.Building.Owner.SurName).ToList();
            if (CmbFiltrSort.Text == "По арендатору")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderBy(x => x.Client.SurName).ToList();
            if (CmbFiltrSort.Text == "По дате начала аренды")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderBy(x => x.BeginDate).ToList();
            if (CmbFiltrSort.Text == "По дате окончания аренды")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderBy(x => x.EndDate).ToList();
        }

        private void RbDown_Checked(object sender, RoutedEventArgs e)
        {
            if (CmbFiltrSort.Text == "По адресу")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderByDescending(x => x.Building.Adress).ToList();
            if (CmbFiltrSort.Text == "По цене аренды(руб.)")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderByDescending(x => x.Building.RentPrice).ToList();
            if (CmbFiltrSort.Text == "По площади(м3)")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderByDescending(x => x.Building.ApartmentArea).ToList();
            if (CmbFiltrSort.Text == "По сотруднику")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderByDescending(x => x.Employee.SurName).ToList();
            if (CmbFiltrSort.Text == "По собственнику")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderByDescending(x => x.Building.Owner.SurName).ToList();
            if (CmbFiltrSort.Text == "По арендатору")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderByDescending(x => x.Client.SurName).ToList();
            if (CmbFiltrSort.Text == "По дате начала аренды")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderByDescending(x => x.BeginDate).ToList();
            if (CmbFiltrSort.Text == "По дате окончания аренды")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderByDescending(x => x.EndDate).ToList();
        }

        private void printTarifs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CmbFiltrSort.Text == "По адресу")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.Where(x => x.Building.Adress.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По цене аренды(руб.)")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.Where(x => x.Building.RentPrice.ToString().ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По площади(м3)")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.Where(x => x.Building.ApartmentArea.ToString().ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По сотруднику")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.Where(x => x.Employee.SurName.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По собственнику")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.Where(x => x.Building.Owner.SurName.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По арендатору")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.Where(x => x.Client.SurName.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По дате начала аренды")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.Where(x => x.BeginDate.ToString().ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По дате окончания аренды")
                ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.Where(x => x.EndDate.ToString().ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }
        private void CmbFiltrSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          if(RbDown.IsChecked == true) 
            {
                if (CmbFiltrSort.Text == "По адресу")
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderByDescending(x => x.Building.Adress).ToList();
                if (CmbFiltrSort.Text == "По цене аренды(руб.)")
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderByDescending(x => x.Building.RentPrice).ToList();
                if (CmbFiltrSort.Text == "По площади(м3)")
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderByDescending(x => x.Building.ApartmentArea).ToList();
                if (CmbFiltrSort.Text == "По сотруднику")
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderByDescending(x => x.Employee.SurName).ToList();
                if (CmbFiltrSort.Text == "По собственнику")
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderByDescending(x => x.Building.Owner.SurName).ToList();
                if (CmbFiltrSort.Text == "По арендатору")
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderByDescending(x => x.Client.SurName).ToList();
                if (CmbFiltrSort.Text == "По дате начала аренды")
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderByDescending(x => x.BeginDate).ToList();
                if (CmbFiltrSort.Text == "По дате окончания аренды")
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderByDescending(x => x.EndDate).ToList();
            }
            if (RbUp.IsChecked == true)
            {
                if (CmbFiltrSort.Text == "По адресу")
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderBy(x => x.Building.Adress).ToList();
                if (CmbFiltrSort.Text == "По цене аренды(руб.)")
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderBy(x => x.Building.RentPrice).ToList();
                if (CmbFiltrSort.Text == "По площади(м3)")
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderBy(x => x.Building.ApartmentArea).ToList();
                if (CmbFiltrSort.Text == "По сотруднику")
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderBy(x => x.Employee.SurName).ToList();
                if (CmbFiltrSort.Text == "По собственнику")
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderBy(x => x.Building.Owner.SurName).ToList();
                if (CmbFiltrSort.Text == "По арендатору")
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderBy(x => x.Client.SurName).ToList();
                if (CmbFiltrSort.Text == "По дате начала аренды")
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderBy(x => x.BeginDate).ToList();
                if (CmbFiltrSort.Text == "По дате окончания аренды")
                    ListContracts.ItemsSource = RealtorEntities.GetContext().Contracts.OrderBy(x => x.EndDate).ToList();
            }
        }
    }
}