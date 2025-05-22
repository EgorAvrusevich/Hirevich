using JA.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для MoreInfoWindowCompany.xaml
    /// </summary>
    public partial class EditMoreInfoWindowCompany : Window
    {
        private User _currentUser { get; set; }
        private Companys_data Companys_data { get; set; }
        private bool isComplete = false;

        private readonly Regex _emailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);
        public EditMoreInfoWindowCompany()
        {
            InitializeComponent();
        }
        public EditMoreInfoWindowCompany(User newcompany)
        {
            try
            {
                InitializeComponent();
                using (var db = new AplicationContext())
                {
                    _currentUser = db.Users.FirstOrDefault(u => u.login == newcompany.login);
                }
                Companys_data = new Companys_data(_currentUser.id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации: {ex.Message}");
                isComplete = true;
                Close();
            }
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Настройка диалога выбора файла
            var openFileDialog = new OpenFileDialog
            {
                Title = "Выберите изображение",
                Filter = "Изображения (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|Все файлы (*.*)|*.*",
                Multiselect = false
            };

            // Открытие диалога
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var imagePath = openFileDialog.FileName;
                    Photo.ImageSource = Load_Functions.LoadImageFromFile(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}",
                                  "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Поле email не может быть пустым", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!_emailRegex.IsMatch(email))
            {
                MessageBox.Show("Введите корректный email адрес", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidateEmail(EmailBox.Text))
                {
                    return;
                }
                Companys_data.Name = CompanyName.Text;
                Companys_data.Email = EmailBox.Text;
                Companys_data.Discription = AboutBox.Text;
                if (Photo.ImageSource is BitmapImage image)
                {
                    Companys_data.Logo = Load_Functions.ConvertImageToBytes(image);
                }

                using (var db = new AplicationContext())
                {
                    db.Companys_data.Add(Companys_data);
                    db.SaveChanges();
                }
                isComplete = true;
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}",
                       "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isComplete)
            {
                if (MessageBox.Show("Вы действительно хотите остановить регистрацию?", "Предупреждение",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    using (var db = new AplicationContext())
                    {
                        db.Users.Remove(_currentUser);
                        db.SaveChanges();
                        DialogResult = false;
                    }
                else e.Cancel = true;
            }
        }
    }
}
