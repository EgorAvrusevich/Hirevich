using JA.Classes;
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
            LoadDataFromDataBase();
        }

        private ObservableCollection<PersonalData> CVs = new ObservableCollection<PersonalData>();

        private void LoadDataFromDataBase()
        {
            try
            {
                using (var db = new AplicationContext())
                {
                    CVs.Clear();

                    var CVsFromDb = db.Users_data.ToList();

                    foreach (var CV in CVsFromDb)
                    {
                        CVs.Add(CV);
                    }
                }

                CVsList.ItemsSource = CVs;
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

            // Ваша логика фильтрации данных
            if (filters == null) return;


            //var filteredData = CVs.Where(item =>
            //{
            //    if (filters.SelectedCountry != default && item.CVs.Country != filters.SelectedCountry)
            //        return false;

            //    if (!string.IsNullOrEmpty(filters.MinSalary) &&
            //        int.TryParse(filters.MinSalary, out var minSalary) &&
            //        item.application.Wage < minSalary)
            //        return false;

            //    return true;
            //});

            //CVsList.ItemsSource = filteredData.ToList();

        }
    }
}
