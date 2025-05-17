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
                    db.Users.Add(User);
                }
                else
                {
                    db.Users.Update(User);
                }
                db.SaveChanges();
            }

            _window.DialogResult = true;
            _window.Close();
        }
    }
}