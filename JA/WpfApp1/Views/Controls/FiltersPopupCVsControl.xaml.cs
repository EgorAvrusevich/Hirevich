using JA.Classes;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JA.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для FiltersPopupCVsControl.xaml
    /// </summary>
    public partial class FiltersPopupCVsControl : UserControl
    {
        public FiltersViewModel ViewModel { get; }

        public FiltersPopupCVsControl()
        {
            InitializeComponent();
            ViewModel = new FiltersViewModel();
            DataContext = ViewModel;
        }

        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(FiltersPopupCVsControl),
                new PropertyMetadata(false));

        public bool IsOpen
        {
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }
    }
}
