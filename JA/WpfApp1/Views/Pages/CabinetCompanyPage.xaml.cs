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
            DataContext = this;
        }

        private void LoadCompanyData(int companyId)
        {
            using (var db = new AplicationContext())
            {
                Data = db.Companys_data.FirstOrDefault(u => u.Id == companyId);
            }
        }

        private void EditCompanyEmail_Click(object sender, RoutedEventArgs e)
        {
            if (Data == null) return;

            var editWindow = new EditCompanyEmailWindow(Data.Email);
            if (editWindow.ShowDialog() == true)
            {
                using (var db = new AplicationContext())
                {
                    var company = db.Companys_data.Find(Data.Id);
                    if (company == null) return;

                    company.Email = editWindow.Email;

                    db.SaveChanges();
                    Companys_data.NotifyDataUpdated();
                    Data = company;
                }
            }
        }

        private void EditCompanyDiscription_Click(object sender, RoutedEventArgs e)
        {
            if (Data == null) return;

            var editWindow = new EditCompanyDiscriptionWindow(Data.Discription);
            if (editWindow.ShowDialog() == true)
            {
                using (var db = new AplicationContext())
                {
                    var company = db.Companys_data.Find(Data.Id);
                    if (company == null) return;

                    company.Discription = editWindow.Discription;

                    db.SaveChanges();
                    Companys_data.NotifyDataUpdated();
                    Data = company;
                }
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
                    Companys_data.NotifyDataUpdated();
                    Data = company;
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