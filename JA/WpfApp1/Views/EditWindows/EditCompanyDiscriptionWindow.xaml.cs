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
    /// Логика взаимодействия для EditCompanyDiscriptionWindow.xaml
    /// </summary>
    public partial class EditCompanyDiscriptionWindow : Window
    {
        public string Discription { get; set; }
        public EditCompanyDiscriptionWindow(string _currentDiscription)
        {
            InitializeComponent();
            DataContext = this;
            Discription = _currentDiscription;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_Discription.Text))
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
