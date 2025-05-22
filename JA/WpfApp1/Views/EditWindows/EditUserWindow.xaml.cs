using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using JA.Classes;
using System.Windows;
using System.Windows.Input;
using RelayCommand = JA.Classes.RelayCommand;

namespace JA.Views.EditWindows
{
    public partial class EditUserWindow : Window
    {
        public EditUserWindow(User user = null)
        {
            InitializeComponent();
            DataContext = new EditUserViewModel(user ?? new User(), this);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }

    public class EditUserViewModel : ViewModelBase
    {
        private readonly EditUserWindow _window;

        public User User { get; set; }
        public string WindowTitle => User.id == 0 ? "Добавление пользователя" : "Редактирование пользователя";

        public ICommand SaveCommand => new RelayCommand(SaveUser, CanSaveUser);

        public EditUserViewModel(User user, EditUserWindow window)
        {
            User = user;
            _window = window;
        }

        private bool CanSaveUser()
        {
            return !string.IsNullOrWhiteSpace(User.login) &&
                   !string.IsNullOrWhiteSpace(User.password);
        }

        private void SaveUser()
        {
            using (var db = new AplicationContext())
            {
                if (User.id == 0)
                {
                    if (db.Users.FirstOrDefault(u => u.login == User.login) == null)
                    { 
                        db.Users.Add(User);
                        db.SaveChanges();
                        if(User.isSercher == 0)
                        {
                            var window = new EditMoreInfoWindowCompany(User);
                            if(window.ShowDialog() == true)
                            {
                                _window.DialogResult = true;
                            }
                            else _window.DialogResult = false;
                            _window.Close();
                        }
                        else
                        {
                            var window = new EditMoreInfoWindowUser(User);
                            if (window.ShowDialog() == true)
                            {
                                _window.DialogResult = true;
                            }
                            else _window.DialogResult = false;
                            _window.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует",
                                          "Ошибка регистрации",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Warning);
                    }
                }
                else
                {
                    db.Users.Update(User);
                    db.SaveChanges();

                    _window.DialogResult = true;
                    _window.Close();
                }
            }
        }
    }
}