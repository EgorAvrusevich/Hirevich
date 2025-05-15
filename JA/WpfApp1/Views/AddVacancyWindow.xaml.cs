using JA.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using Application = JA.Classes.Application;

namespace JA.Views
{
    public partial class AddVacancyWindow : Window, INotifyPropertyChanged
    {
        public Application NewVacancy { get; set; } = new Application();

        // Список стран и уровней опыта
        public Dictionary<string, string> Countries { get; } = new Dictionary<string, string>
        {
            {"russia", "Россия"},
            {"usa", "США"},
            // Добавьте другие страны
        };

        public List<string> ExperienceLevels { get; } = new List<string>
        {
            "Без опыта",
            "1-3 года",
            "3-6 лет",
            "Более 6 лет"
        };

        // Флаг валидности формы
        public bool IsFormValid => !string.IsNullOrWhiteSpace(NewVacancy.Vacation_Name) &&
                                 !string.IsNullOrWhiteSpace(NewVacancy.Country) &&
                                 !string.IsNullOrWhiteSpace(NewVacancy.Experience);

        public int? CompanyId { get; }
        public string? CompanyName { get; }

        public AddVacancyWindow(int companyId)
        {
            InitializeComponent();
            CompanyId = companyId;
            using (var db = new AplicationContext())
            {
                CompanyName = db.Companys_data.FirstOrDefault(u => companyId == u.Id).Name;
            }
            NewVacancy.Id_Company = companyId;
            NewVacancy.Company_name = CompanyName;
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFormValid) return;

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}