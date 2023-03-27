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
    /// Interaction logic for BuildingDetailsPage.xaml
    /// </summary>
    public partial class BuildingDetailsPage : Page
    {
        private Building _currentperson = new Building(); //экземпляр добавляемого пользователя
        public BuildingDetailsPage(Building selectedUser)
        {
            InitializeComponent();
            if (selectedUser != null)
                _currentperson = selectedUser;
            DataContext = _currentperson;
        }
    }
}