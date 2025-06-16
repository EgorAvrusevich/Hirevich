using JA.Classes;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HireVich.Classes
{
    internal class AdoContext : DbContext
    {
        private readonly string _connectinstring;
        private readonly string _dbPath;
        public AdoContext()
        {
            _dbPath = Path.Combine(AppContext.BaseDirectory, "JAdb.db");
            _connectinstring = $"Data Source={_dbPath};Cache=Shared;";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectinstring);
        }

        private void InitializeDatabase()
        {
            if (!File.Exists(_dbPath))
            {
                try
                {
                    // Создаем файл базы данных
                    using (var connection = new SqliteConnection(_connectinstring))
                    {
                        connection.Open();

                        CreateTables(connection);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании БД: {ex.Message}", "Ошибка",
                                  MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void CreateTables(SqliteConnection connection)
        {
            var commands = new[]
            {
                @"CREATE TABLE ""Users"" (
                    ""id"" INTEGER NOT NULL CONSTRAINT ""PK_Users"" PRIMARY KEY AUTOINCREMENT,
                    ""login"" TEXT NOT NULL,
                    ""password"" TEXT NOT NULL,
                    ""isSercher"" INTEGER NOT NULL,
                    ""admin"" INTEGER NOT NULL
                )",
                @"CREATE TABLE ""Responses"" (
                    ""Id"" INTEGER NOT NULL CONSTRAINT ""PK_Responses"" PRIMARY KEY AUTOINCREMENT,
                    ""VacancyId"" INTEGER NOT NULL,
                    ""ApplicantId"" INTEGER NOT NULL,
                    ""ResponseDate"" TEXT NOT NULL,
                    ""Status"" INTEGER NOT NULL,
                    CONSTRAINT ""FK_Responses_Applications_VacancyId"" FOREIGN KEY (""VacancyId"") REFERENCES ""Applications"" (""Id"") ON DELETE CASCADE,
                    CONSTRAINT ""FK_Responses_Users_ApplicantId"" FOREIGN KEY (""ApplicantId"") REFERENCES ""Users"" (""id"") ON DELETE CASCADE
                )",
                @"CREATE TABLE IF NOT EXISTS ""Applications"" (
                    ""Id"" INTEGER NOT NULL CONSTRAINT ""PK_Applications"" PRIMARY KEY AUTOINCREMENT,
                    ""Id_Company"" INTEGER NULL,
                    ""Company_name"" TEXT NULL,
                    ""Vacation_Name"" TEXT NULL,
                    ""Wage"" INTEGER NULL,
                    ""Description"" TEXT NULL,
                    ""Country"" TEXT NULL,
                    ""Experience"" TEXT NULL,
                    ""Userid"" INTEGER NULL,
                    CONSTRAINT ""FK_Applications_Companys_data_Id_Company"" FOREIGN KEY (""Id_Company"") REFERENCES ""Companys_data"" (""Id""),
                    CONSTRAINT ""FK_Applications_Users_Userid"" FOREIGN KEY (""Userid"") REFERENCES ""Users"" (""id"")
                )",
                @"CREATE TABLE IF NOT EXISTS""Companys_data"" (
                    ""Id"" INTEGER NOT NULL CONSTRAINT ""PK_Companys_data"" PRIMARY KEY,
                    ""Discription"" TEXT NULL,
                    ""Email"" TEXT NULL,
                    ""Name"" TEXT NULL,
                    ""Logo"" BLOB NULL,
                    CONSTRAINT ""FK_Companys_data_Users_Id"" FOREIGN KEY (""Id"") REFERENCES ""Users"" (""id"") ON DELETE CASCADE
                )",
                @"CREATE TABLE ""Users_data"" (
                    ""Id"" INTEGER NOT NULL CONSTRAINT ""PK_Users_data"" PRIMARY KEY,
                    ""FirstName"" TEXT NULL,
                    ""LastName"" TEXT NULL,
                    ""Email"" TEXT NULL,
                    ""Age"" TEXT NULL,
                    ""Country"" TEXT NULL,
                    ""About"" TEXT NULL,
                    ""Education"" TEXT NULL,
                    ""Photo"" BLOB NULL,
                    ""Speciality"" TEXT NULL,
                    CONSTRAINT ""FK_Users_data_Users_Id"" FOREIGN KEY (""Id"") REFERENCES ""Users"" (""id"") ON DELETE CASCADE
                )"
            };

            foreach (var commandText in commands)
            {
                using (var command = new SqliteCommand(commandText, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public User? GetUserByLogin(string login)
        {
            try
            {
                if (!File.Exists(_dbPath))
                    InitializeDatabase();
                using (var connection = new SqliteConnection(_connectinstring))
                {
                    connection.Open();

                    var query = "SELECT * FROM Users WHERE login = @login";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User { id = reader.GetInt32("Id"), login = reader.GetString("login"), password = reader.GetString("password"), admin = reader.GetInt32("admin") };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex) {
                MessageBox.Show($"Ошибка доступа к БД: {ex.Message}");
                return null;
            }
        }

        public bool AddNewUser(User newuser)
        {
            try
            {
                using (var connection = new SqliteConnection(_connectinstring))
                {
                    connection.Open();

                    if (GetUserByLogin(newuser.login) is not null)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует",
                                      "Ошибка регистрации",
                                      MessageBoxButton.OK,
                                      MessageBoxImage.Warning);
                        return false;
                    }

                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            var query = "INSERT INTO Users (login, password, isSercher) VALUES (@login, @password, @isSercher)";

                            using (var cmd = new SqliteCommand(query, connection, tran))
                            {
                                cmd.Parameters.AddWithValue("@login", newuser.login);
                                cmd.Parameters.AddWithValue("@password", newuser.password);
                                cmd.Parameters.AddWithValue("@isSercher", newuser.isSercher);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                tran.Commit();
                                return rowsAffected > 0;
                            }
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ушибка удаления");
                return false;
            }
        }

        public bool DeleteResponse(Response response)
        {
            using(var connection = new SqliteConnection(_connectinstring))
            {
                connection.Open();

                var query = "DELETE FROM Responses Where Id = @id";
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new SqliteCommand(query, connection, tran))
                        {
                            cmd.Parameters.AddWithValue("@id", response.Id);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            tran.Commit();
                            return rowsAffected > 0;
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Ошибка удаления отклика");
                        tran.Rollback();
                        return false;
                    }
                }
            }
            return false;
        }

        public ObservableCollection<User> LoadUsers()
        {
            var users = new ObservableCollection<User>();

            try
            {
                using (var connection = new SqliteConnection(_connectinstring))
                {
                    connection.Open();

                    string query = "SELECT id, login, password FROM Users";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users.Add(new User
                                {
                                    id = reader.GetInt32("id"),
                                    login = reader.GetString("login"),
                                    password = reader.GetString("password")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return users;
        }
    }
}
