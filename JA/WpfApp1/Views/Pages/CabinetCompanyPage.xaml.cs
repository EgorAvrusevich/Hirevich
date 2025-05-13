using JA.Classes;
using JA.Views.EditWindows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;

namespace JA.Views.Pages
{
    public partial class CabinetCompanyPage : Page, INotifyPropertyChanged
    {
        private Companys_data _data;
        public Companys_data Data
        {
            get => _data;
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        internal CabinetCompanyPage(User currentUser)
        {
            InitializeComponent();
            LoadCompanyData(currentUser.id);
        }

        private void LoadCompanyData(int companyId)
        {
            using (var db = new AplicationContext())
            {
                Data = db.Companys_data.FirstOrDefault(u => u.Id == companyId);
            }
        }

        private void EditCompanyInfo_Click(object sender, RoutedEventArgs e)
        {
            if (Data == null) return;

            var editWindow = new EditCompanyInfoWindow(Data.Logo, Data.Name);
            if (editWindow.ShowDialog() == true)
            {
                using (var db = new AplicationContext())
                {
                    var company = db.Companys_data.Find(Data.Id);
                    if (company == null) return;

                    company.Name = editWindow.CompanyName;

                    if (editWindow.NewLogo != null && !editWindow.NewLogo.SequenceEqual(Data.Logo ?? Array.Empty<byte>()))
                    {
                        company.Logo = editWindow.NewLogo;
                    }

                    db.SaveChanges();
                    Data = company; // Обновляем всю сущность
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}