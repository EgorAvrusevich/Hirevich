using JA.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace JA.Views.EditWindows
{
    /// <summary>
    /// Логика взаимодействия для EditCompanyNameWindow.xaml
    /// </summary>
    public partial class EditCompanyInfoWindow : Window
    {
        public byte[] CurrentLogo { get; }
        public byte[] NewLogo { get; set; }
        public string CompanyName { get; set; }

        public EditCompanyInfoWindow(byte[] currentLogo, string currentName)
        {
            InitializeComponent();
            CurrentLogo = currentLogo;
            NewLogo = currentLogo;
            CompanyName = currentName;
            DataContext = this;
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg",
                Title = "Выберите логотип компании"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    NewLogo = File.ReadAllBytes(openFileDialog.FileName);
                    newlogo.Source = Load_Functions.ConvertBytesToImage(NewLogo);
                    OnPropertyChanged(nameof(NewLogo));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}",
                                  "Ошибка",
                                  MessageBoxButton.OK,
                                  MessageBoxImage.Error);
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_CompanyName.Text))
            {
                MessageBox.Show("Название компании не может быть пустым",
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
