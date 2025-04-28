using JA.Classes;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Windows;

namespace JA
{
    public partial class App : Application
    {
        // Статическое свойство с ленивой инициализацией
        private static AplicationContext? _database;
        public static AplicationContext Database => _database ?? throw new InvalidOperationException("База данных не инициализирована");

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e); // Важно вызвать базовый метод!

            try
            {
                // Инициализация БД
                _database = new AplicationContext();

                // Проверка/создание БД
                _database.Database.EnsureCreated();

                // Для отладки: выводим путь к БД
                //MessageBox.Show($"БД создана: {Path.GetFullPath("JAdb.db")}", "Info",
                //    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при инициализации БД:\n{ex.Message}",
                    "Critical Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown(1); // Завершаем приложение с кодом ошибки
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _database?.Dispose();
            base.OnExit(e);
        }
    }
}