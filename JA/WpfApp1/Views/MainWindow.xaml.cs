using JA.Classes;
using JA.ViewModels;
using JA.Views.Pages;
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
        
        private readonly MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainWindowViewModel(new AuthService(new AplicationContext()));
            DataContext = viewModel;

            viewModel.PropertyChanged += (s, e) => UpdateUI();
            MainPanel.Navigate(new ApplicationsPage());
        }

        private void UpdateUI()
        {
            //Loged_name.Visibility = viewModel.IsLoggedIn ? Visibility.Visible : Visibility.Collapsed;
            //Loged_photo.Visibility = viewModel.IsLoggedIn ? Visibility.Visible: Visibility.Collapsed;
        }
    }
}
