using System;
using JA.Classes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Microsoft.EntityFrameworkCore;

namespace JA.Classes
{
    class AppForList
    {

        public Application application { get; set; }
        public BitmapImage flag_image { get; set; }
        public BitmapImage? Company_Logo { get; set; }
        public AppForList() { }

        public AppForList(Application application)
        {
            this.application = application;


            using (AplicationContext db = new AplicationContext())
            {
                flag_image = Load_Functions.LoadImageFromFile("C:\\Users\\User\\Desktop\\JA1\\Hirevich\\JA\\WpfApp1\\Images\\flags\\" +
                                                             $"{db.Applications.FirstOrDefault(u => u.Id == application.Id).Country}_flag.png");
                var company = db.Companys_data
                          .AsNoTracking() // Для оптимизации
                          .FirstOrDefault(u => u.Id == application.Id_Company);

                if (company?.Logo != null && company.Logo.Length > 0)
                {
                    Company_Logo = Load_Functions.ConvertBytesToImage(company.Logo);
                }
                else Company_Logo = null;
            }
        }
    }
}
