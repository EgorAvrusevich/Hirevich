﻿using GalaSoft.MvvmLight.Command;
using JA.Classes;
using JA.Views.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
using Application = JA.Classes.Application;

namespace JA.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ApplicationsPage.xaml
    /// </summary>
    public partial class ApplicationsPage : Page
    {
        private User _сurrentUser { get; set; }
        public User CurrentUser
        {
            get => _сurrentUser;
            set
            {
                _сurrentUser = value;
                LoadDataFromDataBase();
            }
        }

        public ApplicationsPage(User user)
        {
            InitializeComponent();
            DataContext = this;
            Loaded += OnLoaded;
            CurrentUser = user;

            var filtersControl = (FiltersPopupControl)FiltersPopup.Child;
            filtersControl.ViewModel.FiltersApplied += ApplyFilters;
        }

        private ObservableCollection<AppForList> applications = new ObservableCollection<AppForList>();

        private void LoadDataFromDataBase()
        {
            try
            {
                using (var db = new AplicationContext())
                {
                    // Очищаем текущую коллекцию перед загрузкой новых данных
                    applications.Clear();

                    // Загружаем данные из базы
                    var appsFromDb = db.Applications
                        .Join(db.Companys_data,
                        app => app.Id_Company,
                        comp => comp.Id,
                        (app, comp) => new
                        {
                            Application = app,
                            CompanyName = comp.Name
                        })
                        .ToList();

                    // Добавляем загруженные данные в коллекцию
                    foreach (var app in appsFromDb)
                    {
                        applications.Add(new AppForList(new Application
                        {
                            Id = app.Application.Id,
                            Company_name = app.CompanyName,
                            Vacation_Name = app.Application.Vacation_Name,
                            Wage = app.Application.Wage,
                            Experience = app.Application.Experience,
                            Country = app.Application.Country,
                            Description = app.Application.Description,
                            Id_Company = app.Application.Id_Company
                        }, _сurrentUser.id));
                    }
                }

                // Обновляем привязку данных (если используется в WPF)
                UpdateFilteredList();
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void ApplicationsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ApplicationsList.SelectedItem is AppForList selectedApp)
            {
                // Создаем и показываем окно с деталями
                var detailWindow = new AppWindow(selectedApp);
                detailWindow.ShowDialog();

                // Сбрасываем выбор (опционально)
                ApplicationsList.SelectedItem = null;
            }
        }

        public ICommand RespondCommand => new RelayCommand<Application>(vacancy =>
        {
            using(var db = new AplicationContext())
            {
                var response = new Response(
                    vacancy.Id,
                    _сurrentUser.id
                );

                db.Add(response);
                db.SaveChanges();

                MessageBox.Show("Отклик успешно отправлен!");

                RaiseResponseAdded();
            }
            LoadDataFromDataBase();
            MyResponsesPage.NotifyDataUpdated();
        });

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (FiltersPopup.Child is FiltersPopupControl control)
            {
                control.ViewModel.FiltersApplied += ApplyFilters;
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            FiltersPopup.IsOpen = !FiltersPopup.IsOpen;
        }

        private void ApplyFilters(FiltersViewModel filters)
        {
            // Закрываем popup после применения фильтров
            FiltersPopup.IsOpen = false;

            // Обновляем отображение с учетом всех фильтров и поиска
            UpdateFilteredList();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Обновляем отображение при изменении текста поиска
            UpdateFilteredList();
        }

        private void UpdateFilteredList()
        {
            // Получаем текущий текст поиска
            var searchText = SearchTextBox.Text.ToLower();

            // Получаем текущие фильтры (предполагаем, что они доступны через свойство)
            var filters = ((FiltersPopupControl)FiltersPopup.Child).ViewModel;

            // Применяем все фильтры и поиск
            var filteredData = applications.Where(item =>
            {
                // Условия фильтрации
                if (filters.SelectedCountry != default && item.application.Country != filters.SelectedCountry)
                    return false;

                if (!string.IsNullOrEmpty(filters.MinSalary) &&
                    int.TryParse(filters.MinSalary, out var minSalary) &&
                    item.application.Wage < minSalary)
                    return false;

                if (filters.SelectedExperience != default &&
                    item.application.Experience != filters.SelectedExperience)
                    return false;

                // Условие поиска
                if (!string.IsNullOrEmpty(searchText) &&
                    !item.application.Vacation_Name.ToLower().Contains(searchText) &&
                    !item.application.Company_name.ToLower().Contains(searchText))
                    return false;

                return true;
            });

            // Обновляем ItemsSource
            ApplicationsList.ItemsSource = filteredData.ToList();
        }

        public event EventHandler ResponseAdded;

        private void RaiseResponseAdded()
        {
            ResponseAdded?.Invoke(this, EventArgs.Empty);
        }

    }
}
