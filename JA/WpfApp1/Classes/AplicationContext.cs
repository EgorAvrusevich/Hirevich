using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.IO;

namespace JA.Classes
{
    public class AplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(AppContext.BaseDirectory, "JAdb.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}