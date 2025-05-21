using System;
using JA.Classes;
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
using System.Globalization;
using JA.Views.EditWindows;
using System.ComponentModel;

namespace JA.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Cabinet.xaml
    /// </summary>
    public partial class CabinetPage : Page
    {
        private PersonalData? _personalData;
        public PersonalData? PersonalData
        {
            get => _personalData;
            set
            {
                _personalData = value;
                OnPropertyChanged(nameof(PersonalData));
            }
        }
        
        public CabinetPage(User currentUser)
        {
            InitializeComponent();
            using (var db = new AplicationContext())
            {
                _personalData = db.Users_data.FirstOrDefault(u => u.Id == currentUser.id);
            }
            DataContext = this;
        }


        public class CountryToFlagConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null) return null;

                string country = value.ToString();
                return $"/Images/flags/{country}_flag.png";
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        private void EditInfo_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new EditInfoWindow(
                _personalData.Photo,
                _personalData.FirstName,
                _personalData.LastName,
                _personalData.Age,
                _personalData.Country);

            if (editWindow.ShowDialog() == true)
            {
                using (var db = new AplicationContext())
                {
                    var personalData = db.Users_data.Find(_personalData.Id);
                    personalData.FirstName = editWindow.FirstName;
                    personalData.LastName = editWindow.LastName;
                    personalData.Age = editWindow.Age;

                    if (editWindow.Photo != null && !editWindow.Photo.SequenceEqual(_personalData.Photo ?? Array.Empty<byte>()))
                    {
                        personalData.Photo = editWindow.Photo;
                    }

                    db.SaveChanges();
                    PersonalData.NotifyDataUpdated();
                    // Обновляем локальные данные
                    _personalData.FirstName = editWindow.FirstName;
                    _personalData.LastName = editWindow.LastName;
                    _personalData.Age = editWindow.Age;
                    _personalData.Photo = editWindow.Photo;

                    // Уведомляем об изменениях
                    OnPropertyChanged(nameof(_personalData));
                }
            }
        }

        private void EditEducation_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new EditEducationWindow(PersonalData.Education ?? "");
            if (editWindow.ShowDialog() == true)
            {
                using (var db = new AplicationContext())
                {
                    var userData = db.Users_data.Find(PersonalData.Id);
                    if (userData != null)
                    {
                        userData.Education = editWindow.EducationText;
                        db.SaveChanges();
                        PersonalData.NotifyDataUpdated();
                        PersonalData.Education = editWindow.EducationText;
                        OnPropertyChanged(nameof(PersonalData));
                    }
                }
            }
        }

        private void EditSpeciality_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new EditSpecialityWindow(PersonalData.Speciality ?? "");
            if (editWindow.ShowDialog() == true)
            {
                using (var db = new AplicationContext())
                {
                    var userData = db.Users_data.Find(PersonalData.Id);
                    if (userData != null)
                    {
                        userData.Speciality = editWindow.SpecialityText;
                        db.SaveChanges();
                        PersonalData.NotifyDataUpdated();
                        PersonalData.Speciality = editWindow.SpecialityText;
                        OnPropertyChanged(nameof(PersonalData));
                    }
                }
            }
        }

        private void EditAbout_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new EditAboutWindow(PersonalData.About ?? "");
            if (editWindow.ShowDialog() == true)
            {
                using (var db = new AplicationContext())
                {
                    var userData = db.Users_data.Find(PersonalData.Id);
                    if (userData != null)
                    {
                        userData.About = editWindow.AboutText;
                        db.SaveChanges();
                        PersonalData.NotifyDataUpdated();
                        PersonalData.About = editWindow.AboutText;
                        OnPropertyChanged(nameof(PersonalData));
                    }
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
