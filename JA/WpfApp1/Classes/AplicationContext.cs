using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.IO;

namespace JA.Classes
{
    public class AplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        internal DbSet<PersonalData> Users_data { get; set; }
        internal DbSet<Companys_data> Companys_data { get; set; }
        internal DbSet<Application> Applications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(AppContext.BaseDirectory, "JAdb.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath};Cache=Shared;");
        }
    }
}