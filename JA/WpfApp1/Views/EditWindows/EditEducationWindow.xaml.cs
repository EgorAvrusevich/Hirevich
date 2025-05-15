using System.ComponentModel;
using System.Windows;

namespace JA.Views.EditWindows
{
    public partial class EditEducationWindow : Window, INotifyPropertyChanged
    {
        private string _educationText;
        public string EducationText
        {
            get => _educationText;
            set
            {
                _educationText = value;
                OnPropertyChanged(nameof(EducationText));
            }
        }

        public EditEducationWindow(string currentEducation)
        {
            InitializeComponent();
            EducationText = currentEducation;
            DataContext = this;
            Loaded += (s, e) => EducationBox.Focus();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EducationText))
            {
                MessageBox.Show("Поле образования не может быть пустым",
                              "Ошибка",
                              MessageBoxButton.OK,
                              MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}