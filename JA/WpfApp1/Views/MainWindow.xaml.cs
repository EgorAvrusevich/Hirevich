﻿using JA.Classes;
using JA.Views.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace JA.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User _currentUser;
        private PersonalData? PersonalData;
        public PersonalData? _personalData
        {
            get => PersonalData;
            set
            {
                PersonalData = value;
                OnPropertyChanged();
            }
        }
        private Companys_data? CompanyData;
        public Companys_data? _companyData
        {
            get => CompanyData;
            set
            {
                CompanyData = value;
                OnPropertyChanged();
            }
        }
        ApplicationsPage? appPage;
        CabinetPage? cabPage;
        CabinetCompanyPage? cabCompPage;
        CVsPage? cvsPage;
        MyVacationsPage? myVacationsPage;
        MyResponsesPage? myResponsesPage;
        CompanyResponsesPage? companyResponsesPage;


        public MainWindow(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            PersonalData.DataUpdated += PersonalDataUpdate;
            Companys_data.DataUpdated += CompanyDataUpdate;

            InitializeUI();
        }

        private void InitializeUI()
        {
            if (_currentUser.admin == 1)
                Admin_window.Visibility = Visibility.Visible;

            if (_currentUser.isSercher == 1)
            {
                InitializeSearcherUI();
            }
            else
            {
                InitializeEmployerUI();
            }
        }

        private void InitializeSearcherUI()
        {
            appPage = new ApplicationsPage(_currentUser);
            using (var db = new AplicationContext()) 
            { 
                _personalData = db.Users_data.FirstOrDefault(u => u.Id == _currentUser.id);
            }
            _personalData.PropertyChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(PersonalData));
            };
            DataContext = _personalData;
            cabPage = new CabinetPage(_currentUser);
            myResponsesPage = new MyResponsesPage(_currentUser);
            MyResponsesPage.UpdateData += ResponsesUpdate;
            MainPanel.Content = appPage;
        }

        private void CompanyDataUpdate()
        {
            Dispatcher.Invoke(() =>
            {
                using (var db = new AplicationContext())
                {
                    _companyData = db.Companys_data.FirstOrDefault(u => u.Id == _currentUser.id);
                    DataContext = _companyData;
                }
            });
        }
        private void PersonalDataUpdate()
        {
            Dispatcher.Invoke(() =>
            {
                using (var db = new AplicationContext())
                {
                    _personalData = db.Users_data.FirstOrDefault(u => u.Id == _currentUser.id);
                    DataContext = _personalData;
                }
            });
        }
        private void ResponsesUpdate()
        {
            Dispatcher.Invoke(() =>
            {
                myResponsesPage = new MyResponsesPage(_currentUser);
            });
        }

        private void InitializeEmployerUI()
        {
            headerPhoto.Visibility = Visibility.Collapsed;
            Vacaitions_label.Content = "Мои вакансии";
            CompanyResponses_page.Visibility = Visibility.Visible;
            companyResponsesPage = new CompanyResponsesPage(_currentUser);
            CVs_page.Visibility = Visibility.Visible;
            MyResponses_page.Visibility = Visibility.Collapsed;
            using(var db = new AplicationContext())
            {
                _companyData = db.Companys_data.FirstOrDefault(u => u.Id == _currentUser.id);
            }
            DataContext = _companyData;
            _companyData.PropertyChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(CompanyData));
            };
            cabCompPage = new CabinetCompanyPage(_currentUser);
            cvsPage = new CVsPage();
            myVacationsPage = new MyVacationsPage(_currentUser);
            MainPanel.Content = myVacationsPage;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            Close();
        }

        private void LoggedPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_currentUser.isSercher == 1)
                MainPanel.Content = cabPage;
            else 
                MainPanel.Content = cabCompPage;
        }

        private void Vacaitions_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_currentUser.isSercher == 1)
                MainPanel.Content = appPage;
            else
                MainPanel.Content = myVacationsPage;

        }

        private void Admin_window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AdminWindow window = new AdminWindow(_currentUser);
            window.Show();
            Close();
        }
        private void CVs_page_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPanel.Content = cvsPage;
        }
        private void MyResponses_page_MouseDown(object sender, MouseButtonEventArgs e)
        {
            appPage.ResponseAdded += (sender, e) =>
            {
                // Обновляем страницу откликов при добавлении нового отклика
                if (myResponsesPage != null)
                {
                    myResponsesPage.LoadDataFromDataBase();
                }
            };
            MainPanel.Content = myResponsesPage;
        }
        private void CompanyResponses_page_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPanel.Content = companyResponsesPage;
        }

        public static event Action? UpdatePersonalData;
        public static void NotifyPersonalDataUpdated()
        {
            UpdatePersonalData?.Invoke();
        }
        public static event Action? UpdateCompanyData;
        public static void NotifyCompanyDataUpdated()
        {
            UpdateCompanyData?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
