using JA.Classes;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JA.Views
{
    public partial class RegisterWindow : Window
    {
        private bool isSercher = true;

        public RegisterWindow()
        {
            InitializeComponent();
            button_sercher.Style = (Style)FindResource("ActiveToggleButton");
            button_company.Style = (Style)FindResource("InactiveToggleButton");
        }

        private void ToggleUserType(bool isSearcherSelected)
        {
            isSercher = isSearcherSelected;
            button_sercher.Style = isSearcherSelected ?
                (Style)FindResource("ActiveToggleButton") :
                (Style)FindResource("InactiveToggleButton");
            button_company.Style = !isSearcherSelected ?
                (Style)FindResource("ActiveToggleButton") :
                (Style)FindResource("InactiveToggleButton");
        }

        private void button_company_Click(object sender, RoutedEventArgs e)
        {
            ToggleUserType(false);
        }

        private void button_sercher_Click(object sender, RoutedEventArgs e)
        {
            ToggleUserType(true);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void ShowInputError(Border inputBorder, Label inputLabel, string message)
        {
            inputBorder.Tag = "Error";
            inputBorder.BorderBrush = (SolidColorBrush)FindResource("ErrorBrush");
            
            inputLabel.Visibility = Visibility.Visible;
            inputLabel.Content = message;
            inputLabel.Foreground = (SolidColorBrush)FindResource("ErrorBrush");
        }

        private void ClearInputError(Border inputBorder, Label inputLabel)
        {
            inputBorder.Tag = null;
            inputBorder.BorderBrush = Brushes.Transparent;

            inputLabel.Visibility = Visibility.Hidden;
            inputLabel.Content = null;
            inputLabel.Foreground = Brushes.Transparent;
        }

        private bool ValidateInputs()
        {
            bool isValid = true;
            string login = loginTextBox.Text.Trim();
            string password = passwordTextBox.Password.Trim();

            // Валидация логина
            if (login.Length < 5)
            {
                ShowInputError(border_login, LoginError, "Логин должен содержать не менее 5 символов");
                isValid = false;
            }
            else
            {
                ClearInputError(border_login, LoginError);
            }

            // Валидация пароля
            if (password.Length < 8)
            {
                ShowInputError(border_password, PasswordError, "Пароль должен содержать не менее 8 символов");
                isValid = false;
            }
            else
            {
                ClearInputError(border_password, PasswordError);
            }

            return isValid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInputs())
                return;

            string login = loginTextBox.Text.Trim();
            string password = passwordTextBox.Password.Trim();

            try
            {
                User newuser;
                using (var db = new AplicationContext())
                {

                    if (db.Users.Any(u => u.login == login))
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует",
                                      "Ошибка регистрации",
                                      MessageBoxButton.OK,
                                      MessageBoxImage.Warning);
                        return;
                    }

                    newuser = new User(login, password, isSercher);
                    db.Users.Add(newuser);
                    db.SaveChanges();

                    db.Entry(newuser).Reload();
                }
                    Window newWindow = isSercher ?
                        new MoreInfoWindowUser(newuser) :
                        new MoreInfoWindowCompany(newuser);
                    newWindow.Show();
                    Close();
            }
            catch (DbUpdateException dbEx)
            {
                MessageBox.Show($"Ошибка сохранения данных: {dbEx.InnerException?.Message ?? dbEx.Message}",
                              "Ошибка базы данных",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}",
                              "Ошибка",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
            }
        }
    }
}