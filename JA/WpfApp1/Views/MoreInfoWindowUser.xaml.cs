using JA.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace JA.Views
{
    /// <summary>
    /// Логика взаимодействия для MoreInfoWindow.xaml
    /// </summary>
    public partial class MoreInfoWindowUser : Window
    {
        private User _currentUser { get; set; }
        private PersonalData PersonalData { get; set; }
        public MoreInfoWindowUser(User newuser)
        {
            InitializeComponent();
            _currentUser = newuser;
            PersonalData = new PersonalData(App.Database.Users.FirstOrDefault(u => u.login == newuser.login).id);
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

                    // Можно сохранить путь к файлу или сами байты изображения
                    // byte[] imageBytes = File.ReadAllBytes(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}",
                                  "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PersonalData.FirstName = FirstNameBox.Text;
                PersonalData.Email = EmailBox.Text;
                PersonalData.LastName = LastNameBox.Text;
                PersonalData.Education = EducationBox.Text;
                PersonalData.About = AboutBox.Text;
                PersonalData.Age = AgeBox.Text;
                PersonalData.Speciality = SpeccialityBox.Text;
                switch (CountryBox.SelectedItem)
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

                using (App.Database)
                {
                    App.Database.Users_data.Add(PersonalData);
                    App.Database.SaveChanges();
                }

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

    }
}
