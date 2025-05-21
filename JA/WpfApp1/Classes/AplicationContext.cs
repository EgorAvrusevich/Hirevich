using Microsoft.EntityFrameworkCore;
using System.IO;

namespace JA.Classes
{
    public class AplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PersonalData> Users_data { get; set; }
        public DbSet<Companys_data> Companys_data { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Response> Responses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(AppContext.BaseDirectory, "JAdb.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath};Cache=Shared;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("Applications");
                entity.HasKey(a => a.Id);

                // Явно маппим все существующие поля
                entity.Property(a => a.Id_Company).HasColumnName("Id_Company");
                entity.Property(a => a.Vacation_Name).HasColumnName("Vacation_Name");
                entity.Property(a => a.Wage).HasColumnName("Wage");
                entity.Property(a => a.Experience).HasColumnName("Experience");
                entity.Property(a => a.Country).HasColumnName("Country");
                entity.Property(a => a.Description).HasColumnName("Description");
                entity.Property(a => a.Company_name).HasColumnName("Company_name");

                // Явно игнорируем несуществующие поля
            });
            // Настройка отношений один-к-одному User ↔ Users_data
            modelBuilder.Entity<User>()
                .HasOne(u => u.Users_data)
                .WithOne(ud => ud.User)
                .HasForeignKey<PersonalData>(ud => ud.Id);

            // Настройка отношений один-к-одному User ↔ Companys_data
            modelBuilder.Entity<User>()
                .HasOne(u => u.Companys_data)
                .WithOne(cd => cd.User)
                .HasForeignKey<Companys_data>(cd => cd.Id);

            // Настройка отношений один-ко-многим Companys_data ↔ Applications
            modelBuilder.Entity<Companys_data>()
                .HasMany(cd => cd.Applications)
                .WithOne(a => a.Companys_data)
                .HasForeignKey(a => a.Id_Company);

            // Настройка отношений один-ко-многим Application ↔ Responses
            modelBuilder.Entity<Application>()
                .HasMany(a => a.Responses)
                .WithOne(r => r.Application)
                .HasForeignKey(r => r.VacancyId);

            // Настройка отношений один-ко-многим User ↔ Responses (для соискателей)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Responses)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.ApplicantId);
        }
    }
}