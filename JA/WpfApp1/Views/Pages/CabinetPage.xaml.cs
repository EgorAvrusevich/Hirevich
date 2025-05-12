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

namespace JA.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Cabinet.xaml
    /// </summary>
    public partial class CabinetPage : Page
    {
        PersonalData? _personalData;
        public CabinetPage(User currentUser)
        {
            InitializeComponent();
            using (var db = new AplicationContext())
            {
                _personalData = db.Users_data.FirstOrDefault(u => u.Id == currentUser.id);
            }
            DataContext = _personalData;
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
    }
}
