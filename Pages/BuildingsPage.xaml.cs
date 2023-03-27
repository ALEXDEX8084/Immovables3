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
    /// Interaction logic for BuildingsPage.xaml
    /// </summary>
    public partial class BuildingsPage : Page
    {
        public BuildingsPage()
        {
            InitializeComponent();
            ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.ToList();
        }
        private void editclient_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new BuildingsAddEditPage((Building)ListBuildings.SelectedItem));
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var personForRemoving = ListBuildings.SelectedItems.Cast<Building>().ToList();
            var resMessage = MessageBox.Show("Удалить запись?", "Подтверждение",
             MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resMessage == MessageBoxResult.Yes)
            {
                try
                {
                    RealtorEntities.GetContext().Buildings.RemoveRange(personForRemoving);
                    RealtorEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Данное помещение нельзя удалить! Перед удалением помещения удалите арендатора и собственника помещения!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.BuildingsAddEditPage(null));
        }

        private void CmbFiltrSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RbDown.IsChecked == true)
            {
                if (CmbFiltrSort.Text == "По адресу")
                    ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderByDescending(x => x.Adress).ToList();
                if (CmbFiltrSort.Text == "По цене аренды(руб.)")
                    ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderByDescending(x => x.RentPrice).ToList();
                if (CmbFiltrSort.Text == "По площади(м3)")
                    ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderByDescending(x => x.ApartmentArea).ToList();
                if (CmbFiltrSort.Text == "По собственнику")
                    ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderByDescending(x => x.Owner.SurName).ToList();
                if (CmbFiltrSort.Text == "По цене")
                    ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderByDescending(x => x.Price).ToList();
            }
            if (RbUp.IsChecked == true)
            {
                if (CmbFiltrSort.Text == "По адресу")
                    ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderBy(x => x.Adress).ToList();
                if (CmbFiltrSort.Text == "По цене аренды(руб.)")
                    ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderBy(x => x.RentPrice).ToList();
                if (CmbFiltrSort.Text == "По площади(м3)")
                    ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderBy(x => x.ApartmentArea).ToList();
                if (CmbFiltrSort.Text == "По собственнику")
                    ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderBy(x => x.Owner.SurName).ToList();
                if (CmbFiltrSort.Text == "По цене")
                    ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderBy(x => x.Price).ToList();
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CmbFiltrSort.Text == "По адресу")
                ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.Where(x => x.Adress.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По цене аренды(руб.)")
                ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.Where(x => x.RentPrice.ToString().ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По площади(м3)")
                ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.Where(x => x.ApartmentArea.ToString().ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По собственнику")
                ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.Where(x => x.Owner.SurName.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По цене")
                ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.Where(x => x.Price.ToString().ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }

        private void RbUp_Checked(object sender, RoutedEventArgs e)
        {
            if (CmbFiltrSort.Text == "По адресу")
                ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderBy(x => x.Adress).ToList();
            if (CmbFiltrSort.Text == "По цене аренды(руб.)")
                ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderBy(x => x.RentPrice).ToList();
            if (CmbFiltrSort.Text == "По площади(м3)")
                ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderBy(x => x.ApartmentArea).ToList();
            if (CmbFiltrSort.Text == "По собственнику")
                ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderBy(x => x.Owner.SurName).ToList();
            if (CmbFiltrSort.Text == "По цене")
                ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderBy(x => x.Price).ToList();
        }

        private void RbDown_Checked(object sender, RoutedEventArgs e)
        {
            if (CmbFiltrSort.Text == "По адресу")
                ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderByDescending(x => x.Adress).ToList();
            if (CmbFiltrSort.Text == "По цене аренды(руб.)")
                ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderByDescending(x => x.RentPrice).ToList();
            if (CmbFiltrSort.Text == "По площади(м3)")
                ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderByDescending(x => x.ApartmentArea).ToList();
            if (CmbFiltrSort.Text == "По собственнику")
                ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderByDescending(x => x.Owner.SurName).ToList();
            if (CmbFiltrSort.Text == "По цене")
                ListBuildings.ItemsSource = RealtorEntities.GetContext().Buildings.OrderByDescending(x => x.Price).ToList();
        }

        private void BuildingDetails_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new BuildingDetailsPage((Building)ListBuildings.SelectedItem));
        }
    }
}
