﻿using JA.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace JA.Views
{
    /// <summary>
    /// Логика взаимодействия для CVWindow.xaml
    /// </summary>
    public partial class CVWindow : Window
    {
        internal CVWindow(PersonalData data)
        {
            InitializeComponent();
            DataContext = data;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
