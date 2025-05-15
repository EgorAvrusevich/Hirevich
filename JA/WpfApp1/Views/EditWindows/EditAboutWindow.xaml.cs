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
    /// Логика взаимодействия для EditAboutWindow.xaml
    /// </summary>
 
        public partial class EditAboutWindow : Window, INotifyPropertyChanged
        {
            private string _aboutText;
            public string AboutText
            {
                get => _aboutText;
                set
                {
                    _aboutText = value;
                    OnPropertyChanged(nameof(AboutText));
                }
            }

            public EditAboutWindow(string currentAbout)
            {
                InitializeComponent();
                AboutText = currentAbout;
                DataContext = this;
                Loaded += (s, e) => AboutTextBox.Focus();
            }

            private void SaveButton_Click(object sender, RoutedEventArgs e)
            {
                if (string.IsNullOrWhiteSpace(AboutText))
                {
                    MessageBox.Show("Поле образования не может быть пустым",
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
            protected void OnPropertyChanged(string propertyName) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
