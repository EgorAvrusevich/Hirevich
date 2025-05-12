using JA.Classes;
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
    }
}
