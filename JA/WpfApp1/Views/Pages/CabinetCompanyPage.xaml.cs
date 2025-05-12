using JA.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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

namespace JA.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для CabinetCompanyPage.xaml
    /// </summary>
    public partial class CabinetCompanyPage : Page
    {
        Companys_data? data;
        public CabinetCompanyPage(User currentUser)
        {
            InitializeComponent();
            using (var db = new AplicationContext())
            {
                data = db.Companys_data.FirstOrDefault(u => u.Id == currentUser.id);
            }
            DataContext = data;
        }
    }
}
