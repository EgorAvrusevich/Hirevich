﻿using JA.Classes;
using JA.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JA.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User? user;
            using (var db = new AplicationContext()) {
                user = db.Users.FirstOrDefault( u => u.login == login_box.Text);
                if (user != null)
                {
                    if (user.password != password_box.Password)
                    {
                        warning.Visibility = Visibility.Visible;
                        return;
                    }
                } else { 
                    warning.Visibility = Visibility.Visible;
                    return; 
                }
            }

            MainWindow MainWindow = new MainWindow(user);
            MainWindow.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegisterWindow window = new RegisterWindow();
            window.Show();
            Close();
        }
    }
}
