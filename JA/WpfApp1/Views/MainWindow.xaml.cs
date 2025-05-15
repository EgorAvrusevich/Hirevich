using JA.Classes;
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
        ApplicationsPage? appPage;
        CabinetPage? cabPage;
        CabinetCompanyPage? cabCompPage;
        CVsPage? cvsPage;
        MyVacationsPage? myVacationsPage;
        MyResponsesPage? myResponsesPage;
        

        public MainWindow(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            appPage = new ApplicationsPage(_currentUser);

            if (_currentUser.isSercher == 1)
            {
                using (var db = new AplicationContext())
                {
                    _personalData = db.Users_data.FirstOrDefault(u => u.Id == _currentUser.id);
                }
                DataContext = _personalData;
                cabPage = new CabinetPage(_currentUser);
                myResponsesPage = new MyResponsesPage(_currentUser);
            }
            else
            {
                Vacaitions_label.Content = "Мои вакансии";
                CVs_page.Visibility = Visibility.Visible;
                MyResponses_page.Visibility = Visibility.Collapsed;
                using (var db = new AplicationContext())
                {
                    _companyData = db.Companys_data.FirstOrDefault(u => u.Id == _currentUser.id);
                }
                DataContext = _companyData;
                cabCompPage = new CabinetCompanyPage(_currentUser);
                cvsPage = new CVsPage();
                myVacationsPage = new MyVacationsPage(_currentUser);
            }
            MainPanel.Content = appPage;
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
                MainPanel.Content = cabPage;
            else 
                MainPanel.Content = cabCompPage;
        }

        private void Vacaitions_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_currentUser.isSercher == 1)
                MainPanel.Content = appPage;
            else
                MainPanel.Content = myVacationsPage;

        }

        private void CVs_page_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPanel.Content = cvsPage;
        }
        private void MyResponses_page_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPanel.Content = myResponsesPage;
        }
    }
}
