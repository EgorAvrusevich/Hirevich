using JA.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace JA.Views
{
    /// <summary>
    /// Логика взаимодействия для MoreInfoWindow.xaml
    /// </summary>
    public partial class MoreInfoWindowUser : Window
    {
        private User _currentUser { get; set; }
        private PersonalData PersonalData { get; set; }
        private bool isComplete = false;

        private readonly Regex _emailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);
        public MoreInfoWindowUser(User newuser)
        {
            try
            {
                InitializeComponent();
                using (var db = new AplicationContext()) {
                    _currentUser = db.Users.FirstOrDefault(u => u.login == newuser.login);
                }
                PersonalData = new PersonalData(_currentUser.id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации: {ex.Message}");
                Close();
            }
        }
        public MoreInfoWindowUser()
        {
            InitializeComponent();
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
                    // Загрузка изображения
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

        private bool ValidateFields()
        {
            bool isValid = true;
            if (!ValidateEmail(EmailBox.Text))
            {
                SetErrorStyle(EmailBox);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(FirstNameBox.Text))
            {
                SetErrorStyle(FirstNameBox);
                isValid = false;
            }

            if (!int.TryParse(AgeBox.Text, out int age) || age < 18 || age > 100)
            {
                SetErrorStyle(AgeBox);
                isValid = false;
            }

            if (string.IsNullOrEmpty(LastNameBox.Text)) 
            { 
                SetErrorStyle(LastNameBox);
                isValid = false;
            }

            if (string.IsNullOrEmpty(CountryBox.Text))
            {
                SetErrorStyle(CountryBox);
                isValid = false;
            }

            if (string.IsNullOrEmpty(EducationBox.Text))
            {
                SetErrorStyle(EducationBox);
                isValid = false;
            }

            return isValid;
        }

        private void SetErrorStyle(Control control)
        {
            control.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#e74c3c");
            control.BorderThickness = new Thickness(2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidateFields())
                {
                    return;
                }
                PersonalData.FirstName = FirstNameBox.Text;
                PersonalData.Email = EmailBox.Text;
                PersonalData.LastName = LastNameBox.Text;
                PersonalData.Education = EducationBox.Text;
                PersonalData.About = AboutBox.Text;
                PersonalData.Age = AgeBox.Text;
                PersonalData.Speciality = SpeccialityBox.Text;
                switch (CountryBox.Text)
                {
                    case "Беларусь":
                        PersonalData.Country = "belarus";
                        break;
                    case "Россия":
                        PersonalData.Country = "russia";
                        break;
                    case "Украина":
                        PersonalData.Country = "ukraine";
                        break;
                    case "Канада":
                        PersonalData.Country = "canada";
                        break;
                    case "Бразилия":
                        PersonalData.Country = "brazil";
                        break;
                    case "США":
                        PersonalData.Country = "usa";
                        break;
                    case "Австралия":
                        PersonalData.Country = "australia";
                        break;
                    case "Великобритания":
                        PersonalData.Country = "UK";
                        break;
                    case "Китай":
                        PersonalData.Country = "china";
                        break;
                    case "Япония":
                        PersonalData.Country = "japan";
                        break;
                    case "Германия":
                        PersonalData.Country = "germany";
                        break;
                    case "Франция":
                        PersonalData.Country = "france";
                        break;
                    case "Другая":
                        PersonalData.Country = "others";
                        break;
                    default:
                        throw new Exception();
                        
                }
                if (Photo.ImageSource is BitmapImage image) {
                    PersonalData.Photo = Load_Functions.ConvertImageToBytes(image);
                }

                using (var db = new AplicationContext())
                {
                    db.Users_data.Add(PersonalData);
                    db.SaveChanges();
                }
                isComplete = true;
                MainWindow window = new MainWindow(_currentUser);
                window.Show();
                Close();
            }
            catch(Exception ex)
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
                    }
                else e.Cancel = true;
            }
        }
    }
}
