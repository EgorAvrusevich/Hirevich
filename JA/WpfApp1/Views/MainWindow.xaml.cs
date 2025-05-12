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
        readonly Companys_data? _companyData;
        

        public MainWindow(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            if (_currentUser.isSercher == 1)
            {
                using (var db = new AplicationContext())
                {
                    _personalData = db.Users_data.FirstOrDefault(u => u.Id == _currentUser.id);
                }
                DataContext = _personalData;
            }
            else
            {
                Vacaitions_label.Content = "Мои вакансии";
                CVs_page.Visibility = Visibility.Visible;
                using (var db = new AplicationContext())
                {
                    _companyData = db.Companys_data.FirstOrDefault(u => u.Id == _currentUser.id);
                }
                DataContext = _companyData;
            }
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
            if (_currentUser.isSercher == 1)
                MainPanel.Content = new CabinetPage(_currentUser);
            else 
                MainPanel.Content = new CabinetCompanyPage(_currentUser);
        }

        private void Vacaitions_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_currentUser.isSercher == 1)
                MainPanel.Content = new ApplicationsPage();
            else
                MainPanel.Content = new MyVacationsPage(_currentUser);

        }

        private void CVs_page_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPanel.Content = new CVsPage();
        }
    }
}
