using JA.Classes;
using JA.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JA.Views
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private bool isSercher = true;
        AplicationContext db;

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void button_company_Click(object sender, RoutedEventArgs e)
        {
            isSercher = false;
            button_sercher.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFFFF");
            button_sercher.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#C2CDCE");
            button_company.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#F8F8F8");
            button_company.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#849A9C");
        }

        private void button_sercher_Click(object sender, RoutedEventArgs e)
        {
            isSercher = true;
            button_company.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFFFF");
            button_company.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#C2CDCE");
            button_sercher.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#F8F8F8");
            button_sercher.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#849A9C");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window LoginWindow = new LoginWindow();
            LoginWindow.Show();
            Close();
        }

        private static readonly object _dbLock = new object();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool pass = true;
            string login = loginTextBox.Text.Trim();
            string password = passwordTextBox.Password.Trim();
            if (login.Length < 5)
            {
                border_login.BorderBrush = (SolidColorBrush)Brushes.OrangeRed;
                loginTextBox.ToolTip = "Логин содержит менее 5 символов";
                pass = false;
            } else
            {
                border_login.BorderBrush = null;
                loginTextBox.ToolTip = null;
            } 

            if (password.Length < 8)
            {
                border_password.BorderBrush = (SolidColorBrush)Brushes.OrangeRed;
                passwordTextBox.ToolTip = "Пароль содержит менее 8 символов";
                pass = false;
            } else
            {
                border_password.BorderBrush = null;
                border_password.ToolTip = null;
            }

            if (pass)
            {
                try
                {
                    using (db = new AplicationContext())
                    {
                        db.Database.SetCommandTimeout(30);
                        // Проверка на существующего пользователя
                        if (db.Users.Any(u => u.login == login))
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует");
                            return;
                        }

                        User newuser = new User(login, password, isSercher);
                        db.Users.Add(newuser);
                        db.SaveChanges();

                        Window newWindow = isSercher ? new MoreInfoWindowUser(newuser) 
                                                     : new MoreInfoWindowCompany(newuser);
                        newWindow.Show();
                        Close();
                    }
                }
                catch (DbUpdateException dbEx)
                {
                    MessageBox.Show($"Ошибка сохранения данных: {dbEx.InnerException?.Message ?? dbEx.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при регистрации: {ex.Message}");
                }
            }
        }
    }
}
