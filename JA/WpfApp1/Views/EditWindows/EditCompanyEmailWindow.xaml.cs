using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace JA.Views.EditWindows
{
    /// <summary>
    /// Логика взаимодействия для EditCompanyEmailWindow.xaml
    /// </summary>
    public partial class EditCompanyEmailWindow : Window
    {
        public string Email { get; set; }
        public EditCompanyEmailWindow(string currentEmail)
        {
            InitializeComponent();
            DataContext = this;
            Email = currentEmail;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_Email.Text))
            {
                MessageBox.Show("Почта компании не может быть пустая",
                               "Ошибка",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
