// CompanyResponsesPage.xaml.cs
using GalaSoft.MvvmLight.CommandWpf;
using JA.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Application = JA.Classes.Application;

namespace JA.Views.Pages
{
    public partial class CompanyResponsesPage : Page
    {
        private readonly User _currentCompany;
        private ObservableCollection<ResponsedAppForList> _responses = new ObservableCollection<ResponsedAppForList>();

        public CompanyResponsesPage(User companyUser)
        {
            InitializeComponent();
            _currentCompany = companyUser;
            LoadResponses();
            ResponsesListView.ItemsSource = _responses;
            FilterComboBox.Text = "Все статусы";
        }

        private void LoadResponses()
        {
            try
            {
                using (var db = new AplicationContext())
                {
                    _responses.Clear();

                    var responses = db.Responses
                    .AsNoTracking()
                    .Where(r => db.Applications.Any(v => v.Id == r.VacancyId && v.Id_Company == _currentCompany.id))
                    .Join(db.Applications,
                        response => response.VacancyId,
                        vacancy => vacancy.Id,
                        (response, vacancy) => new { response, vacancy })
                    .Join(db.Companys_data,
                        joined => joined.vacancy.Id_Company,
                        company => company.Id,
                        (joined, company) => new ResponsedAppForList(
                            new AppForList(
                                new Application
                                {
                                    Id = joined.vacancy.Id,
                                    Company_name = company.Name,
                                    Vacation_Name = joined.vacancy.Vacation_Name,
                                    Wage = joined.vacancy.Wage,
                                    Experience = joined.vacancy.Experience,
                                    Country = joined.vacancy.Country,
                                    Description = joined.vacancy.Description,
                                    Id_Company = joined.vacancy.Id_Company
                                }),
                            joined.response.Status,
                            db.Users_data.FirstOrDefault(u => u.Id == joined.response.ApplicantId)
                        ))
                    .ToList();
                    foreach (var response in responses)
                    {
                        _responses.Add(response);
                    }
                    ApplyFilters();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки откликов: {ex.Message}");
            }
        }

        private void CVsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ResponsesListView.SelectedItem is ResponsedAppForList selectedApp)
            {
                // Создаем и показываем окно с деталями
                var detailWindow = new CVWindow(selectedApp.PersonalData);
                detailWindow.ShowDialog();

                // Сбрасываем выбор (опционально)
                ResponsesListView.SelectedItem = null;
            }
        }

        public ICommand ChangeStatusCommand => new RelayCommand<ResponsedAppForList>(async item =>
        {
            var statusDialog = new ChangeStatusDialog(item.Status);
            if (statusDialog.ShowDialog() == true)
            {
                using (var db = new AplicationContext())
                {
                    var response = await db.Responses
                        .FirstOrDefaultAsync(r => r.VacancyId == item.AppForList.application.Id &&
                                               r.ApplicantId == item.PersonalData.Id);

                    if (response != null)
                    {
                        response.Status = statusDialog.SelectedStatus;
                        await db.SaveChangesAsync();
                        LoadResponses();
                    }
                }
            }
        });

        private void ApplyFilters()
        {
            var searchText = SearchTextBox.Text.ToLower();
            var selectedStatus = (FilterComboBox.SelectedItem as ComboBoxItem)?.Tag.ToString();

            var filtered = _responses.Where(r =>
            {
                // Условие поиска
                bool searchCondition = string.IsNullOrEmpty(searchText) ||
                                     r.AppForList.application.Vacation_Name.ToLower().Contains(searchText) ||
                                     r.AppForList.application.Company_name.ToLower().Contains(searchText);

                // Условие фильтра по статусу
                bool statusCondition = selectedStatus == "Все" ||
                                     r.StatusText == selectedStatus;

                return searchCondition && statusCondition;
            }).ToList();

            ResponsesListView.ItemsSource = filtered;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }
    }
}