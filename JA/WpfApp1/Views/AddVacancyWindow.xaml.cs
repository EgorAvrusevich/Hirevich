using JA.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Application = JA.Classes.Application;

namespace JA.Views
{
    public partial class AddVacancyWindow : Window, INotifyPropertyChanged
    {
        public Application NewVacancy { get; } = new Application();

        public Dictionary<string, string> Countries { get; } = new()
        {
            {"australia", "Австралия"},
            {"belarus", "Беларусь"},
            {"brazil", "Бразилия"},
            {"canada", "Канада"},
            {"china", "Кита"},
            {"france", "Франция"},
            {"germany", "Германия"},
            {"japan", "Япония"},
            {"russia", "Россия"},
            {"UK", "Великобритания"},
            {"ukraine", "Украина"},
            {"usa", "США"},
            {"others", "Другая"},

        };

        public List<string> ExperienceLevels { get; } = new()
        {
            "Без опыта",
            "1-3 года",
            "3-6 лет",
            "Более 6 лет"
        };

        public bool IsFormValid => !string.IsNullOrWhiteSpace(NewVacancy.Vacation_Name) &&
                                 !string.IsNullOrWhiteSpace(NewVacancy.Country) &&
                                 !string.IsNullOrWhiteSpace(NewVacancy.Experience);

        public AddVacancyWindow(int companyId)
        {
            InitializeComponent();

            using (var db = new AplicationContext())
            {
                var company = db.Companys_data.AsNoTracking().FirstOrDefault(c => c.Id == companyId);

                if (company != null)
                {
                    NewVacancy.Id_Company = companyId;
                    NewVacancy.Company_name = company.Name;
                }
            }

            DataContext = this;
            Loaded += (s, e) => VacationNameBox.Focus();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFormValid)
            {
                MessageBox.Show("Заполните все обязательные поля", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Дополнительная проверка числовых полей
            if (WageBox.Text != "" && !int.TryParse(WageBox.Text, out _))
            {
                MessageBox.Show("Укажите корректную зарплату", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}