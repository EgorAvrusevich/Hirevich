using JA.Classes;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireVich.Classes
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Exists(int id);
    }

    public class UserRepository : IRepository<User>
    {
        private readonly SqliteConnection _connectionString;  
        private SqliteTransaction? _transaction;

        public UserRepository(SqliteConnection connectionString, SqliteTransaction tran)
        {
            _connectionString = connectionString;
            _transaction = tran;
        }

        public IEnumerable<User> GetAll()
        {

                var command = new SqliteCommand("SELECT * FROM Users", _connectionString,_transaction);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new User
                        {
                            id = reader.GetInt32("id"),
                            login = reader.GetString("login"),
                            password = reader.GetString("password"),
                            isSercher = reader.GetInt32("isSearcher"),
                            admin = reader.GetInt32("admin")
                        };
                    }
                }
        }

        public User GetById(int id)
        {

                var command = new SqliteCommand("SELECT * FROM Users WHERE id = @id", _connectionString, _transaction);

                command.Parameters.AddWithValue("@id", id);
                using(var reader = command.ExecuteReader())
                {
                    reader.Read();
                    return new User
                    {
                        id = reader.GetInt32("id"),
                        login = reader.GetString("login"),
                        password = reader.GetString("password"),
                        isSercher = reader.GetInt32("isSearcher"),
                        admin = reader.GetInt32("admin")
                    };
                }
        }

        public void Add(User user)
        {
                var command = new SqliteCommand(
                    "INSERT INTO Users (login, password, isSearcher, admin) VALUES (@login, @password, @isSearcher, @admin)",
                    _connectionString,_transaction);

                command.Parameters.AddWithValue("@login", user.login);
                command.Parameters.AddWithValue("@password", user.password);
                command.Parameters.AddWithValue("@isSearcher", user.isSercher);
                command.Parameters.AddWithValue("@admin", user.admin);

                command.ExecuteNonQuery();
        }

        public void Delete(User user)
        {
                var command = new SqliteCommand("DELETE FROM Users WHERE id = @id", _connectionString, _transaction);

                command.Parameters.AddWithValue("@id", user.id);
                command.ExecuteNonQuery();
        }
        public void Update(User user)
        {
                var query = @"
                UPDATE Users 
                SET 
                    login = @login,
                    password = @password,
                    isSearcher = @isSearcher,
                    admin = @admin
                WHERE id = @id";

                using (var command = new SqliteCommand(query, _connectionString, _transaction))
                {
                    command.Parameters.AddWithValue("@id", user.id);
                    command.Parameters.AddWithValue("@login", user.login);
                    command.Parameters.AddWithValue("@password", user.password);
                    command.Parameters.AddWithValue("@isSearcher", user.isSercher);
                    command.Parameters.AddWithValue("@admin", user.admin);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException($"Пользователь с ID {user.id} не найден");
                    }
                }
        }
        public bool Exists(int id)
        {
                var query = "SELECT * FROM Users WHERE id = @id";

                using(var command = new SqliteCommand(query, _connectionString, _transaction))
                {
                    command.Parameters.AddWithValue("@id", id);
                    return (command.ExecuteNonQuery() != 0) ? true : false;
                }
        }
    }
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }

        void Commit();
        void Rollback();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqliteConnection _connection;
        private SqliteTransaction _transaction;

        public UnitOfWork(string connectionString)
        {
            _connection = new SqliteConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();

            Users = new UserRepository(_connection, _transaction);
        }

        public IRepository<User> Users { get; }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = _connection.BeginTransaction();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }
    }
}
