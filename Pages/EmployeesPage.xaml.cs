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
    /// Interaction logic for EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public EmployeesPage()
        {
            InitializeComponent();
            ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.EmployeeAddEditPage(null));
        }

        private void editEmployee_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new EmployeeAddEditPage((Employee)ListEmployees.SelectedItem));
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            var personForRemoving = ListEmployees.SelectedItems.Cast<Employee>().ToList();
            var resMessage = MessageBox.Show("Удалить запись?", "Подтверждение",
             MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resMessage == MessageBoxResult.Yes)
            {
                try
                {
                    RealtorEntities.GetContext().Employees.RemoveRange(personForRemoving);
                    RealtorEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Данный клиент арендует помещение", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CmbFiltrSort.Text == "По фамилии")
                ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.Where(x => x.SurName.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По имени")
                ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.Where(x => x.FirstName.ToString().ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По отчеству")
                ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.Where(x => x.Patron.ToString().ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
            if (CmbFiltrSort.Text == "По номеру телефона")
                ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.Where(x => x.PhoneNumber.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }

        private void CmbFiltrSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RbDown.IsChecked == true)
            {
                if (CmbFiltrSort.Text == "По фамилии")
                    ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.OrderByDescending(x => x.SurName).ToList();
                if (CmbFiltrSort.Text == "По имени")
                    ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.OrderByDescending(x => x.FirstName).ToList();
                if (CmbFiltrSort.Text == "По отчеству")
                    ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.OrderByDescending(x => x.Patron).ToList();
                if (CmbFiltrSort.Text == "По номеру телефона")
                    ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.OrderByDescending(x => x.PhoneNumber).ToList();
            }
            if (RbUp.IsChecked == true)
            {
                if (CmbFiltrSort.Text == "По фамилии")
                    ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.OrderBy(x => x.SurName).ToList();
                if (CmbFiltrSort.Text == "По имени")
                    ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.OrderBy(x => x.FirstName).ToList();
                if (CmbFiltrSort.Text == "По отчеству")
                    ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.OrderBy(x => x.Patron).ToList();
                if (CmbFiltrSort.Text == "По номеру телефона")
                    ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.OrderBy(x => x.PhoneNumber).ToList();
            }
        }

        private void RbUp_Checked(object sender, RoutedEventArgs e)
        {
            if (CmbFiltrSort.Text == "По фамилии")
                ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.OrderBy(x => x.SurName).ToList();
            if (CmbFiltrSort.Text == "По имени")
                ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.OrderBy(x => x.FirstName).ToList();
            if (CmbFiltrSort.Text == "По отчеству")
                ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.OrderBy(x => x.Patron).ToList();
            if (CmbFiltrSort.Text == "По номеру телефона")
                ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.OrderBy(x => x.PhoneNumber).ToList();
        }

        private void RbDown_Checked(object sender, RoutedEventArgs e)
        {
            if (CmbFiltrSort.Text == "По фамилии")
                ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.OrderByDescending(x => x.SurName).ToList();
            if (CmbFiltrSort.Text == "По имени")
                ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.OrderByDescending(x => x.FirstName).ToList();
            if (CmbFiltrSort.Text == "По отчеству")
                ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.OrderByDescending(x => x.Patron).ToList();
            if (CmbFiltrSort.Text == "По номеру телефона")
                ListEmployees.ItemsSource = RealtorEntities.GetContext().Employees.OrderByDescending(x => x.PhoneNumber).ToList();
        }
    }
}
