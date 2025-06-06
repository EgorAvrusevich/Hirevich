﻿using JA.Classes;
using JA.Views.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static System.Net.Mime.MediaTypeNames;

namespace JA.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для CVsPage.xaml
    /// </summary>
    public partial class CVsPage : Page
    {
        public CVsPage()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += OnLoaded;
            LoadDataFromDataBase();


            var filtersControl = (FiltersPopupCVsControl)FiltersPopupCVs.Child;
            filtersControl.ViewModel.FiltersApplied += ApplyFilters;
        }
        private FiltersViewModel _currentFilters;

        private ObservableCollection<PersonalData> CVs = new ObservableCollection<PersonalData>();

        private void LoadDataFromDataBase()
        {
            try
            {
                using (var db = new AplicationContext())
                {
                    CVs.Clear();

                    var CVsFromDb = db.Users_data.Where(u => db.Users.FirstOrDefault(r => r.id == u.Id).admin == 0).ToList();

                    foreach (var CV in CVsFromDb)
                    {
                        CVs.Add(CV);
                    }
                }

                ApplyAllFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void CVsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CVsList.SelectedItem is PersonalData selectedApp)
            {
                // Создаем и показываем окно с деталями
                var detailWindow = new CVWindow(selectedApp);
                detailWindow.ShowDialog();

                // Сбрасываем выбор (опционально)
                CVsList.SelectedItem = null;
            }
        }

        private void ApplyAllFilters()
        {
            var searchText = SearchTextBox.Text.ToLower();

            var filteredData = CVs.Where(item =>
            {
                // Условие поиска
                if (!string.IsNullOrEmpty(searchText) &&
                    !item.Speciality.ToLower().Contains(searchText))
                {
                    return false;
                }

                // Условия фильтрации
                if (_currentFilters != null)
                {
                    if (_currentFilters.SelectedCountry != default &&
                        item.Country != _currentFilters.SelectedCountry)
                    {
                        return false;
                    }

                    // Добавьте другие условия фильтрации по необходимости
                }

                return true;
            });

            CVsList.ItemsSource = new ObservableCollection<PersonalData>(filteredData.ToList());
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (FiltersPopupCVs.Child is FiltersPopupCVsControl control)
            {
                control.ViewModel.FiltersApplied += ApplyFilters;
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            FiltersPopupCVs.IsOpen = !FiltersPopupCVs.IsOpen;
        }

        private void ApplyFilters(FiltersViewModel filters)
        {
            FiltersPopupCVs.IsOpen = false;
            _currentFilters = filters;
            ApplyAllFilters();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyAllFilters();
        }
    }
}
