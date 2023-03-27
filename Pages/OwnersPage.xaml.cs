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
    /// Interaction logic for OwnersPage.xaml
    /// </summary>
    public partial class OwnersPage : Page
    {
        public OwnersPage()
        {
            InitializeComponent();
            ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.OwnersAddEditPage(null));
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var personForRemoving = ListOwner.SelectedItems.Cast<Owner>().ToList();
            var resMessage = MessageBox.Show("Удалить запись?", "Подтверждение",
             MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resMessage == MessageBoxResult.Yes)
            {
                try
                {
                    RealtorEntities.GetContext().Owners.RemoveRange(personForRemoving);
                    RealtorEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Данный клиент арендует помещение", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void editOwner_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new OwnersAddEditPage((Owner)ListOwner.SelectedItem));
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CmbFiltrSort.Text == "По фамилии")
                ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.Where(x => x.SurName.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По имени")
                ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.Where(x => x.FirstName.ToString().ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По отчеству")
                ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.Where(x => x.Patron.ToString().ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По номеру телефона")
                ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.Where(x => x.PhoneNumber.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По паспорту")
                ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.Where(x => x.Passport.ToString().ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }

        private void CmbFiltrSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RbDown.IsChecked == true)
            {
                if (CmbFiltrSort.Text == "По фамилии")
                    ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderByDescending(x => x.SurName).ToList();
                if (CmbFiltrSort.Text == "По имени")
                    ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderByDescending(x => x.FirstName).ToList();
                if (CmbFiltrSort.Text == "По отчеству")
                    ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderByDescending(x => x.Patron).ToList();
                if (CmbFiltrSort.Text == "По номеру телефона")
                    ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderByDescending(x => x.PhoneNumber).ToList();
                if (CmbFiltrSort.Text == "По паспорту")
                    ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderByDescending(x => x.Passport).ToList();
            }
            if (RbUp.IsChecked == true)
            {
                if (CmbFiltrSort.Text == "По фамилии")
                    ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderBy(x => x.SurName).ToList();
                if (CmbFiltrSort.Text == "По имени")
                    ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderBy(x => x.FirstName).ToList();
                if (CmbFiltrSort.Text == "По отчеству")
                    ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderBy(x => x.Patron).ToList();
                if (CmbFiltrSort.Text == "По номеру телефона")
                    ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderBy(x => x.PhoneNumber).ToList();
                if (CmbFiltrSort.Text == "По паспорту")
                    ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderBy(x => x.Passport).ToList();
            }
        }

        private void RbDown_Checked(object sender, RoutedEventArgs e)
        {
            if (CmbFiltrSort.Text == "По фамилии")
                ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderByDescending(x => x.SurName).ToList();
            if (CmbFiltrSort.Text == "По имени")
                ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderByDescending(x => x.FirstName).ToList();
            if (CmbFiltrSort.Text == "По отчеству")
                ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderByDescending(x => x.Patron).ToList();
            if (CmbFiltrSort.Text == "По номеру телефона")
                ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderByDescending(x => x.PhoneNumber).ToList();
            if (CmbFiltrSort.Text == "По паспорту")
                ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderByDescending(x => x.Passport).ToList();
        }

        private void RbUp_Checked(object sender, RoutedEventArgs e)
        {
            if (CmbFiltrSort.Text == "По фамилии")
                ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderBy(x => x.SurName).ToList();
            if (CmbFiltrSort.Text == "По имени")
                ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderBy(x => x.FirstName).ToList();
            if (CmbFiltrSort.Text == "По отчеству")
                ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderBy(x => x.Patron).ToList();
            if (CmbFiltrSort.Text == "По номеру телефона")
                ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderBy(x => x.PhoneNumber).ToList();
            if (CmbFiltrSort.Text == "По паспорту")
                ListOwner.ItemsSource = RealtorEntities.GetContext().Owners.OrderBy(x => x.Passport).ToList();
        }
    }
}
