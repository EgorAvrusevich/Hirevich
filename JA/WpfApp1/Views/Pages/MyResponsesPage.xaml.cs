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
    /// Логика взаимодействия для MyResponsesPage.xaml
    /// </summary>
    public partial class MyResponsesPage : Page
    {
        User? _currentUser;
        public MyResponsesPage(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            LoadDataFromDataBase();
        }

        private ObservableCollection<ResponsedAppForList> applications = new ObservableCollection<ResponsedAppForList>();

        private void LoadDataFromDataBase()
        {
            try
            {
                using (var db = new AplicationContext())
                {
                    // Очищаем текущую коллекцию перед загрузкой новых данных
                    applications.Clear();

                    // Загружаем данные из базы
                    var respondedVacancies = db.Responses
                                            .Where(r => r.ApplicantId == _currentUser.id)
                                            .Join(db.Applications,
                                                response => response.VacancyId,
                                                vacancy => vacancy.Id,
                                                (response, vacancy) => new { vacancy, response })
                                            .Join(db.Companys_data,
                                                joined => joined.vacancy.Id_Company,
                                                company => company.Id,
                                                (joined, company) => new ResponsedAppForList(new AppForList(
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
                                                    }), joined.response.Status
                                                ))
                                            .ToList();

                    foreach (var vacancy in respondedVacancies)
                    {
                        applications.Add(vacancy);
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
            if (ApplicationsList.SelectedItem is ResponsedAppForList selectedApp)
            {
                // Создаем и показываем окно с деталями
                var detailWindow = new AppWindow(selectedApp.AppForList);
                detailWindow.ShowDialog();

                // Сбрасываем выбор (опционально)
                ApplicationsList.SelectedItem = null;
            }
        }

        public ICommand WithdrawCommand => new RelayCommand<AppForList>(async app =>
        {
            if (MessageBox.Show("Отозвать отклик?", "Подтверждение",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (var db = new AplicationContext())
                {
                    var response = await db.Responses
                        .FirstOrDefaultAsync(r => r.VacancyId == app.application.Id &&
                                                r.ApplicantId == _currentUser.id);

                    if (response != null)
                    {
                        response.Status = ResponseStatus.Withdrawn;
                        await db.SaveChangesAsync();
                        LoadDataFromDataBase(); // Обновляем список
                    }
                }
            }
        });

        public ICommand DeleteResponseCommand => new RelayCommand<ResponsedAppForList>(async item =>
        {
            if (MessageBox.Show("Вы действительно хотите удалить этот отклик?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    using (var db = new AplicationContext())
                    {
                        var response = await db.Responses
                            .FirstOrDefaultAsync(r => r.VacancyId == item.AppForList.application.Id &&
                                                   r.ApplicantId == _currentUser.id);

                        if (response != null)
                        {
                            db.Responses.Remove(response);
                            await db.SaveChangesAsync();
                            LoadDataFromDataBase(); // Обновляем список
                            MessageBox.Show("Отклик успешно удален");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении отклика: {ex.Message}");
                }
            }
        });
    }
}