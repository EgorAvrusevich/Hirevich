using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JA.Classes;
using JA.Views.EditWindows;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Application = JA.Classes.Application;
using RelayCommand = JA.Classes.RelayCommand;

namespace JA.Views
{
    public partial class AdminWindow : Window
    {
        public User _currentUser;
        public AdminWindow(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            DataContext = new AdminPanelViewModel(_currentUser);
        }
    }

    public class AdminPanelViewModel : ViewModelBase
    {
        private ObservableCollection<User> _users;
        private ObservableCollection<Application> _vacancies;
        private ObservableCollection<ResponsedAppForList> _responses;

        public ObservableCollection<User> Users
        {
            get => _users;
            set => Set(ref _users, value);
        }

        public ObservableCollection<Application> Vacancies
        {
            get => _vacancies;
            set => Set(ref _vacancies, value);
        }

        public ObservableCollection<ResponsedAppForList> Responses
        {
            get => _responses;
            set => Set(ref _responses, value);
        }

        public ICommand RefreshUsersCommand => new RelayCommand(LoadUsers);
        public ICommand RefreshVacanciesCommand => new RelayCommand(LoadVacancies);
        public ICommand RefreshResponsesCommand => new RelayCommand(LoadResponses);

        public ICommand AddUserCommand => new RelayCommand(AddUser);
        public ICommand EditUserCommand => new RelayCommand<User>(EditUser);
        public ICommand DeleteUserCommand => new RelayCommand<User>(DeleteUser);

        public ICommand AddVacancyCommand => new RelayCommand(AddVacancy);
        public ICommand EditVacancyCommand => new RelayCommand<Application>(EditVacancy);
        public ICommand DeleteVacancyCommand => new RelayCommand<Application>(DeleteVacancy);

        public ICommand DeleteResponseCommand => new RelayCommand<ResponsedAppForList>(DeleteResponse);

        public User _currentUser;
        public AdminPanelViewModel(User currentUser)
        {
            using (var db = new AplicationContext())
            {
                _currentUser = db.Users.FirstOrDefault(u => u.login == currentUser.login);
            }
            LoadUsers();
            LoadVacancies();
            LoadResponses();
        }

        private void LoadUsers()
        {
            using (var db = new AplicationContext())
            {
                Users = new ObservableCollection<User>(db.Users.ToList());
            }
        }

        private void LoadVacancies()
        {
            using (var db = new AplicationContext())
            {
                Vacancies = new ObservableCollection<Application>(
                    db.Applications
                        .Include(a => a.Companys_data) // Подгружаем связанные данные компании
                        .ToList());
            }
        }

        private void LoadResponses()
        {
            try
            {
                using (var db = new AplicationContext())
                {
                    Responses = new ObservableCollection<ResponsedAppForList>(db.Responses
                    .AsNoTracking()
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
                            db.Users_data.FirstOrDefault(u => u.Id == joined.response.ApplicantId),
                            joined.response
                        ))
                    .ToList());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки откликов: {ex.Message}");
            }
        }

        private void AddUser()
        {
            // Реализация добавления пользователя
            var editWindow = new EditUserWindow();
            if (editWindow.ShowDialog() == true)
            {
                LoadUsers();
            }
        }

        private void EditUser(User user)
        {
            if (user == null) return;

            var editWindow = new EditUserWindow(user);
            if (editWindow.ShowDialog() == true)
            {
                LoadUsers();
            }
        }

        private void DeleteUser(User user)
        {
            if (user == null) return;

            // Сравниваем по ID, а не по ссылке на объект
            if (user.id == _currentUser.id)
            {
                MessageBox.Show("Вы не можете удалить текущего пользователя.", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show($"Удалить пользователя {user.login} и всё что с ним связано?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    using (var db = new AplicationContext())
                    {
                        // Получаем пользователя из базы данных
                        var userToDelete = db.Users
                            .Include(u => u.Users_data)
                            .Include(u => u.Companys_data)
                            .FirstOrDefault(u => u.id == user.id);

                        if (userToDelete == null)
                        {
                            MessageBox.Show("Пользователь уже был удален");
                            LoadUsers();
                            return;
                        }

                        // Дополнительная проверка на случай, если что-то изменилось
                        if (userToDelete.id == _currentUser.id)
                        {
                            MessageBox.Show("Вы не можете удалить текущего пользователя.");
                            return;
                        }

                        // Удаление связанных данных
                        if (userToDelete.isSercher == 0) // Для работодателей
                        {
                            var vacancies = db.Applications
                                .Where(a => a.Id_Company == userToDelete.id)
                                .ToList();

                            db.Applications.RemoveRange(vacancies);
                        }

                        db.Users.Remove(userToDelete);
                        int affected = db.SaveChanges();

                        if (affected > 0)
                        {
                            MessageBox.Show("Пользователь и все связанные данные успешно удалены");
                            LoadUsers();
                            LoadVacancies();
                            LoadResponses();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}\n\nПодробности: {ex.InnerException?.Message}",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DeleteVacancyWithResponses(Application vacancy)
        {
            using(var db = new AplicationContext())
            {
                var responses = db.Responses.Where(r => r.VacancyId == vacancy.Id).ToList();
                db.Responses.RemoveRange(responses);
                db.SaveChanges();
            }
        }

        private void AddVacancy()
        {
            var editWindow = new EditVacancyWindow();
            if (editWindow.ShowDialog() == true)
            {
                LoadVacancies();
            }
        }

        private void EditVacancy(Application vacancy)
        {
            if (vacancy == null) return;

            var editWindow = new EditVacancyWindow(vacancy);
            if (editWindow.ShowDialog() == true)
            {
                LoadVacancies();
            }
        }

        private void DeleteVacancy(Application vacancy)
        {
            if (vacancy == null) return;

            if (MessageBox.Show($"Удалить вакансию {vacancy.Vacation_Name}?", "Подтверждение",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DeleteVacancyWithResponses(vacancy);
                LoadVacancies();
            }
        }

        private void DeleteResponse(ResponsedAppForList response)
        {
            if (response == null) return;

            if (MessageBox.Show("Удалить этот отклик?", "Подтверждение",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (var db = new AplicationContext())
                {
                    db.Responses.Remove(response.Response);
                    db.SaveChanges();
                    LoadResponses();
                }
            }
        }
    }
}