using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JA.Classes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Application = JA.Classes.Application;
using RelayCommand = JA.Classes.RelayCommand;

namespace JA.Views.EditWindows
{
    public partial class EditVacancyWindow : Window
    {
        public EditVacancyWindow(Application vacancy = null)
        {
            InitializeComponent();
            DataContext = new EditVacancyViewModel(vacancy ?? new Application(), this);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }

    public class EditVacancyViewModel : ViewModelBase
    {
        private readonly EditVacancyWindow _window;

        public Application Vacancy { get; set; }
        public List<Companys_data> Companies { get; set; }
        public string WindowTitle => Vacancy.Id == 0 ? "Добавление вакансии" : "Редактирование вакансии";

        public ICommand SaveCommand => new RelayCommand(SaveVacancy, CanSaveVacancy);

        public EditVacancyViewModel(Application vacancy, EditVacancyWindow window)
        {
            Vacancy = vacancy;
            _window = window;

            using (var db = new AplicationContext())
            {
                Companies = db.Companys_data.ToList();
            }
        }

        private bool CanSaveVacancy()
        {
            return !string.IsNullOrWhiteSpace(Vacancy.Vacation_Name) &&
                   Vacancy.Id_Company > 0 &&
                   Vacancy.Wage >= 0;
        }

        private void SaveVacancy()
        {
            using (var db = new AplicationContext())
            {
                if (Vacancy.Id == 0)
                {
                    db.Applications.Add(Vacancy);
                }
                else
                {
                    db.Applications.Update(Vacancy);
                }
                db.SaveChanges();
            }

            _window.DialogResult = true;
            _window.Close();
        }
    }
}