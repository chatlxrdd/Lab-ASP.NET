using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Lab3.Models; // Upewnij się, że ta przestrzeń nazw zawiera klasy ComputerEntity i ManufacturerEntity
using System;

namespace Lab3.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<ComputerEntities> Computers { get; set; }
        public DbSet<ManufacturerEntities> Manufacturers { get; set; }

        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "computers.db");
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={DbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ComputerEntities>().HasData(
                new ComputerEntities { ComputerId = 1, Name = "Komputer1", Processor = "Intel i5", Memory = "8GB", GraphicsCard = "NVIDIA GTX 1050", ManufacturerId = 1, ProductionDate = new DateTime(2020, 1, 1) },
                new ComputerEntities { ComputerId = 2, Name = "Komputer2", Processor = "AMD Ryzen 5", Memory = "16GB", GraphicsCard = "AMD Radeon RX 5600", ManufacturerId = 2, ProductionDate = new DateTime(2021, 1, 1) }
            );

            modelBuilder.Entity<ManufacturerEntities>().HasData(
                new ManufacturerEntities { ManufacturerId = 1, Name = "Producent1" },
                new ManufacturerEntities { ManufacturerId = 2, Name = "Producent2" }
            );
        }
    }
}
