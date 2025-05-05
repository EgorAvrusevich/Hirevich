using JA.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace JA.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для CVsPage.xaml
    /// </summary>
    public partial class CVsPage : Page
    {
        public CVsPage()
        {
            InitializeComponent();
            DataContext = this;
            LoadDataFromDataBase();
        }

        private ObservableCollection<PersonalData> CVs = new ObservableCollection<PersonalData>();

        private void LoadDataFromDataBase()
        {
            try
            {
                using (var db = new AplicationContext())
                {
                    // Очищаем текущую коллекцию перед загрузкой новых данных
                    CVs.Clear();

                    // Загружаем данные из базы
                    var CVsFromDb = db.Users_data.ToList();

                    // Добавляем загруженные данные в коллекцию
                    foreach (var CV in CVsFromDb)
                    {
                        CVs.Add(CV);
                    }
                }

                // Обновляем привязку данных (если используется в WPF)
                CVsList.ItemsSource = CVs;
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }
    }
}
