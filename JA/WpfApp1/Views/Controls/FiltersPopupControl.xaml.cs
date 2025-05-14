using JA.Classes;
using System.Windows;
using System.Windows.Controls;

namespace JA.Views.Controls
{
    public partial class FiltersPopupControl : UserControl
    {
        public FiltersViewModel ViewModel { get; }

        public FiltersPopupControl()
        {
            InitializeComponent();
            ViewModel = new FiltersViewModel();
            DataContext = ViewModel;
        }

        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(FiltersPopupControl),
                new PropertyMetadata(false));

        public bool IsOpen
        {
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }
    }
}