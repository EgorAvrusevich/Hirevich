using JA.Classes;
using System.Windows;

namespace JA.Views
{
    public partial class ChangeStatusDialog : Window
    {
        public ResponseStatus SelectedStatus { get; private set; }

        public ChangeStatusDialog(ResponseStatus currentStatus)
        {
            InitializeComponent();
            SelectedStatus = currentStatus;
            StatusComboBox.SelectedItem = currentStatus;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedStatus = (ResponseStatus)StatusComboBox.SelectedItem;
            DialogResult = true;
            Close();
        }
    }
}