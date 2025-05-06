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

        public Application? application { get; set; }
        public byte[]? flag_image { get; set; }
        public byte[]? Company_Logo { get; set; }
        public AppForList() { }

        public AppForList(Application application)
        {
            this.application = application;


            using (AplicationContext db = new AplicationContext())
            {
                LoadFlagImage(db);
                LoadCompanyLogo(db);
            }
        }

        private void LoadFlagImage(AplicationContext db)
        {
            try
            {
                string? Country = db.Applications
                    .AsNoTracking()
                    .Where(a => a.Id == application.Id)
                    .Select(a => a.Country)
                    .FirstOrDefault();

                    string flagPath = $"C:\\Users\\User\\Desktop\\JA1\\Hirevich\\JA\\WpfApp1\\Images\\flags\\{Country}_flag.png";
                    if (File.Exists(flagPath))
                    {
                        flag_image = Load_Functions.ConvertImageToBytes(Load_Functions.LoadImageFromFile(flagPath));
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки флага: {ex.Message}");
            }
        }

        private void LoadCompanyLogo(AplicationContext db)
        {
            try
            {
                var company = db.Companys_data
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Id == application.Id_Company);

                if (company != null)
                {
                    // Безопасная проверка на null и пустой массив
                    Company_Logo = company.Logo?.Length > 0 ? company.Logo : null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки логотипа: {ex.Message}");
            }
        }
    }

}
