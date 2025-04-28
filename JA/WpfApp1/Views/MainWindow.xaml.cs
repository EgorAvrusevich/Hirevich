using JA.Classes;
using JA.ViewModels;
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

namespace JA.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private readonly MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel(new AuthService(new AplicationContext()));
            DataContext = viewModel;

            viewModel.PropertyChanged += (s, e) => UpdateUI();
        }

        private void UpdateUI()
        {
            Guest.Visibility = viewModel.IsLoggedIn ? Visibility.Collapsed : Visibility.Visible;
            //Loged_name.Visibility = viewModel.IsLoggedIn ? Visibility.Visible : Visibility.Collapsed;
            //Loged_photo.Visibility = viewModel.IsLoggedIn ? Visibility.Visible: Visibility.Collapsed;
        }

        private void Login_Click(object sender, MouseButtonEventArgs e)
        {
            LoginWindow LoginWindow = new LoginWindow();
            LoginWindow.Show();
            Close();
        }
    }
}
