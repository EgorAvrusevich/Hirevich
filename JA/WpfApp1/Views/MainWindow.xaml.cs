using JA.Classes;
using JA.ViewModels;
using JA.Views.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace JA.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User _currentUser;
        readonly PersonalData? _personalData;
        

        public MainWindow(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            using (var db = new AplicationContext())
            {
                _personalData = db.Users_data.FirstOrDefault(u => u.Id == _currentUser.id);
            }
            this.DataContext = _personalData;
            if(_currentUser.isSercher == 0) CVs_page.Visibility = Visibility.Visible;
            MainPanel.Content = new ApplicationsPage();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            Close();
        }

        private void LoggedPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPanel.Content = new CabinetPage(_currentUser);
        }

        private void Vacaitions_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPanel.Content = new ApplicationsPage();
        }

        private void CVs_page_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPanel.Content = new CVsPage();
        }
    }
}
