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
    /// Логика взаимодействия для EditSpecialityWindow.xaml
    /// </summary>
    public partial class EditSpecialityWindow : Window, INotifyPropertyChanged
    {
        private string _specialityText;
        public string SpecialityText
        {
            get => _specialityText;
            set
            {
                _specialityText = value;
                OnPropertyChanged(nameof(SpecialityText));
            }
        }
        public EditSpecialityWindow(string currentSpeciality)
        {
            InitializeComponent();
            SpecialityText = currentSpeciality;
            DataContext = this;
            Loaded += (s, e) => SpecialityTextBox.Focus();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SpecialityText))
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
