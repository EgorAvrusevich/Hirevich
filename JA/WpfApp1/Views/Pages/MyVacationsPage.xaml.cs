using GalaSoft.MvvmLight.CommandWpf;
using JA.Classes;
using Microsoft.EntityFrameworkCore;
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
using Application = JA.Classes.Application;

namespace JA.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyVacationsPage.xaml
    /// </summary>
    public partial class MyVacationsPage : Page
    {
        User? _currentUser;
        public MyVacationsPage(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            LoadDataFromDataBase();
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
                        .Where(u => u.Application.Id_Company == _currentUser.id)
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
                        }));
                    }
                }

                // Обновляем привязку данных (если используется в WPF)
                ApplicationsList.ItemsSource = applications;
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        public ICommand DeleteVacancyCommand => new RelayCommand<AppForList>(async item =>
        {
            if (MessageBox.Show("Вы действительно хотите удалить эту вакансию?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    using (var db = new AplicationContext())
                    {
                        var response = await db.Applications
                            .FirstOrDefaultAsync(r => r.Id == item.application.Id);

                        if (response != null)
                        {
                            db.Applications.Remove(response);
                            await db.SaveChangesAsync();
                            LoadDataFromDataBase(); // Обновляем список
                            MessageBox.Show("Вакансия успешно удалена");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении вакансии: {ex.Message}");
                }
            }
        });

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

        private void AddVacancy_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddVacancyWindow(_currentUser.id);
            if (addWindow.ShowDialog() == true)
            {
                using (var db = new AplicationContext())
                {
                    db.Applications.Add(addWindow.NewVacancy);
                    db.SaveChanges();

                    LoadDataFromDataBase();
                }
            }
        }
    }
}
