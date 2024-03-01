using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "computers.db");
        }
        public DbSet<ComputerEntity> Computers { get; set; }
        public DbSet<ProducerEntity> Producers { get; set; }

        private string DbPath { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProducerEntity>()
                .OwnsOne(e => e.Company);

            modelBuilder.Entity<ComputerEntity>()
                .HasOne(e => e.Producer)
                .WithMany(o => o.Computers)
                .HasForeignKey(e => e.ProducerId);

            modelBuilder.Entity<ProducerEntity>().HasData(
                new ProducerEntity()
                {
                    Id = 1,
                    Title = "ACTION",
                    Nip = "83492384",
                    Regon = "13424234",
                },
                new ProducerEntity()
                {
                    Id = 2,
                    Title = "X-KOM",
                    Nip = "2498534",
                    Regon = "0873439249",
                },
               new ProducerEntity()
               {
                   Id = 3,
                   Title = "Media Expert",
                   Nip = "3252312",
                   Regon = "12523654326",
               },
                new ProducerEntity()
                {
                    Id = 4,
                    Title = "Media Markt",
                    Nip = "151532",
                    Regon = "124164312",
                },
                new ProducerEntity()
                {
                    Id = 5,
                    Title = "Morele",
                    Nip = "249812534",
                    Regon = "0873439249",
                },
                new ProducerEntity()
                {
                    Id = 6,
                    Title = "Komputeronik",
                    Nip = "1312315",
                    Regon = "1251325",
                }
            );

            modelBuilder.Entity<ComputerEntity>().HasData(
                new ComputerEntity()
                {
                    Id = 1,
                    Name = "GamerComp",
                    Processor = "Intel-Core i7",
                    Memory = "16 Gb",
                    GraphicsCard = "RTX 3070",
                    Manufacturer = "NVIDIA",
                    ProductionDate = new DateTime(2021, 9, 23),
                    Priority = 3,
                    ProducerId = 1
                },
                new ComputerEntity()
                {
                    Id = 2,
                    Name = "GamerComp",
                    Processor = "AMD Ryzen 5",
                    Memory = "32 Gb",
                    GraphicsCard = "AMD Radeon RX 6700 XT",
                    Manufacturer = "AMD",
                    ProductionDate = new DateTime(2023, 10, 5),
                    Priority = 3,
                    ProducerId = 2
                },
               new ComputerEntity()
               {
                   Id = 3,
                   Name = "GamerComp",
                   Processor = "AMD Ryzen 7",
                   Memory = "16 Gb",
                   GraphicsCard = "RTX 4090",
                   Manufacturer = "NVIDIA",
                   ProductionDate = new DateTime(2023, 8, 22),
                   Priority = 3,
                   ProducerId = 3
               },
               new ComputerEntity()
               {
                   Id = 4,
                   Name = "GamerComp",
                   Processor = "AMD Radeon RX 6700 XT",
                   Memory = "16 Gb",
                   GraphicsCard = "RTX 3070Ti",
                   Manufacturer = "NVIDIA",
                   ProductionDate = new DateTime(2022, 12, 11),
                   Priority = 3,
                   ProducerId = 4
               },
               new ComputerEntity()
               {
                   Id = 5,
                   Name = "GamerComp",
                   Processor = "Intel-Core i9",
                   Memory = "16 Gb",
                   GraphicsCard = "RTX 3070Ti",
                   Manufacturer = "NVIDIA",
                   ProductionDate = new DateTime(2023, 5, 4),
                   Priority = 3,
                   ProducerId = 5
               }

            );
            modelBuilder.Entity<ProducerEntity>()
                .OwnsOne(e => e.Company)
                .HasData(
                    new { ProducerEntityId = 1, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150", Region = "małopolskie" },
                    new { ProducerEntityId = 2, City = "Kraków", Street = "Krowoderska 45/6", PostalCode = "31-150", Region = "małopolskie" }
                );
            string ADMIN_ID = Guid.NewGuid().ToString();
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Name = "admin",
                    NormalizedName = "ADMIN",
                    Id = ADMIN_ROLE_ID,
                    ConcurrencyStamp = ADMIN_ROLE_ID
                });
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Name = "user",
                    NormalizedName = "USER",
                    Id = USER_ROLE_ID,
                    ConcurrencyStamp = USER_ROLE_ID
                });
            var admin = new IdentityUser()
            {
                Id = ADMIN_ID,
                Email = "admin@wsei.edu.pl",
                NormalizedEmail = "ADMIN@WSEI.EDU.PL",
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedUserName = "ADMIN"
            };
            var user = new IdentityUser()
            {
                Id = USER_ID,
                Email = "user@wsei.edu.pl",
                NormalizedEmail = "USER@WSEI.EDU.PL",
                EmailConfirmed = true,
                UserName = "user",
                NormalizedUserName = "USER"
            };
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "admin");
            user.PasswordHash = ph.HashPassword(user, "user");
            modelBuilder.Entity<IdentityUser>().HasData(admin);
            modelBuilder.Entity<IdentityUser>().HasData(user);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID,
                });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID,
                });
        }
    }
}