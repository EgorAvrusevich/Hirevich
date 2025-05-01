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
    public partial class MoreInfoWindow : Window
    {
        private User _currentUser { get; set; }
        private PersonalData PersonalData { get; set; }
        public MoreInfoWindow(User newuser)
        {
            InitializeComponent();
            _currentUser = newuser;
            PersonalData = new PersonalData(App.Database.Users.FirstOrDefault(u => u.login == newuser.login).id);
        }
        public MoreInfoWindow()
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
                    LoadImageFromFile(imagePath);

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

        private void LoadImageFromFile(string filePath)
        {
            // Создание BitmapImage
            var bitmap = new BitmapImage();

            // Инициализация с настройками для оптимальной загрузки
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(filePath);
            bitmap.CacheOption = BitmapCacheOption.OnLoad; // Загрузка сразу в память
            bitmap.EndInit();
            bitmap.Freeze(); // Для безопасного использования в других потоках

            // Установка изображения в Image контрол
            Photo.ImageSource = bitmap;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PersonalData.FirstName = FirstNameBox.Text;
                PersonalData.email = EmailBox.Text;
                PersonalData.LastName = LastNameBox.Text;
                PersonalData.Education = EducationBox.Text;
                PersonalData.About = AboutBox.Text;
                if (Photo.ImageSource is BitmapImage image) {
                    PersonalData.Photo = ConvertImageToBytes(image);
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

        private byte[]? ConvertImageToBytes(BitmapImage image)
        {
            if (image.UriSource != null && image.UriSource.IsFile)
            {
                return File.ReadAllBytes(image.UriSource.LocalPath);
            }
            else if (image.StreamSource != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(image));
                    encoder.Save(memoryStream);
                    return memoryStream.ToArray();
                }
            }
            return null;
        }
    }
}
