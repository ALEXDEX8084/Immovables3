using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace Immovables.Pages
{
    /// <summary>
    /// Interaction logic for BuildingsAddEditPage.xaml
    /// </summary>
    public partial class BuildingsAddEditPage : Page
    {
        string imgLoc = "пусто";
        private Building _currentperson = new Building(); //экземпляр добавляемого пользователя
        public BuildingsAddEditPage(Building selectedUser)
        {
            InitializeComponent();
            if (selectedUser != null)
                _currentperson = selectedUser;
            DataContext = _currentperson;
            CmbFiltrOwner.ItemsSource = RealtorEntities.GetContext().Owners.ToList();
            CmbFiltrOwner.SelectedValuePath = "IDOwner";
            CmbFiltrOwner.DisplayMemberPath = "SurName";
        }
        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentperson.Adress)) error.AppendLine("Укажите Адрес");
            if (string.IsNullOrWhiteSpace(PriceTxt.Text)) error.AppendLine("Укажите Цену");
            if (string.IsNullOrWhiteSpace(Areatxt.Text)) error.AppendLine("Укажите Площадь(м3)");
            if (string.IsNullOrWhiteSpace(CmbFiltrOwner.Text)) error.AppendLine("Укажите Собственника");
            if (string.IsNullOrWhiteSpace(renttxt.Text)) error.AppendLine("Укажите Цену аренды");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            if (_currentperson.IDBuilding == 0)
            {
                RealtorEntities.GetContext().Buildings.Add(_currentperson);
                try
                {
                    RealtorEntities.GetContext().SaveChanges();// Сохранить изменения
                    MessageBox.Show("Данные сохраненны");
                    this.NavigationService.Navigate(new BuildingsPage());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                try
                {
                    if (imgLoc != null && imgLoc != "пусто")
                    {
                        byte[] img = null;
                        FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        img = br.ReadBytes((int)fs.Length);
                        _currentperson.Image = img;
                    }

                    if (imgLoc == "пусто") _currentperson.Image = null;

                    RealtorEntities.GetContext().SaveChanges();
                    Classes.ClassFrame.frmObj.Navigate(new BuildingsPage());
                    MessageBox.Show("Данные о помещении измененны");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }




        private void CmbFiltrOwner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LoadImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog
                {
                    Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*",
                    Title = "Выберите изображение помещения"
                };
                if (dlg.ShowDialog() == true)
                {
                    imgLoc = dlg.FileName.ToString();
                    imagebuilding.Source = new BitmapImage(new Uri(imgLoc));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearImage_Click(object sender, RoutedEventArgs e)
        {
            imagebuilding.Source = (ImageSource)imagebuilding.FindResource("House");
            imgLoc = "пусто";
        }
    }
}
