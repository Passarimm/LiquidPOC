using LiquidPoc.Domain.Entities;
using LiquidPoc.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace LiquidPoc.Infra.Data.Base
{
    public class DataContext : DbContext
    {
        public DbSet<EmployeeEntity> Assembly { get; set; }
        public DbSet<CompanyEntity> Company { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(Console.WriteLine)
                .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=LiquidPocDB;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Commands:
            //Add-Migration NameMigration
            //Update-Database

            modelBuilder.Entity<EmployeeEntity>(new EmployeeMap().Configure);
            modelBuilder.Entity<CompanyEntity>(new CompanyMap().Configure);
        }
    }
}
