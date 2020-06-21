using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s17911Kolokwium.Models
{
    public class CukierniaContext : DbContext
    {
        public CukierniaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Klient> Clients { get; set; }
        public DbSet<Pracownik> Employees { get; set; }
        public DbSet<WyrobProdukt> ConfectioneryProducts { get; set; }
        public DbSet<Zamowienie> Orders { get; set; }
        public DbSet<ZamowienieProdukt> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ZamowienieProdukt>()
                .HasKey(c => new { c.IdOrder, c.IdConfectioneryProduct });

            modelBuilder.Entity<Klient>().HasData(
                new Klient
                {
                    IdClient = 1,
                    Name = "Seba",
                    Surname = "Sebek"
                },
                new Klient
                {
                    IdClient = 2,
                    Name = "Artur",
                    Surname = "Arturek"
                });
            modelBuilder.Entity<Pracownik>().HasData(
                new Pracownik
                {
                    IdEmployee = 1,
                    Name = "Olka",
                    Surname = "Zwariowana"
                });
            
            modelBuilder.Entity<WyrobProdukt>().HasData(
                new WyrobProdukt
                {
                    IdConfectioneryProduct = 1,
                    Name = "Makowiec",
                    Type = "Ciasto"
                },
                new WyrobProdukt
                {
                    IdConfectioneryProduct = 2,
                    Name = "Sernik",
                    Type = "Ciasto"
                });
            modelBuilder.Entity<Zamowienie>().HasData(
                new Zamowienie
                {
                    IdOrder = 1,
                    AcceptanceDate = DateTime.Now.AddDays(1),
                    RealizationDate = DateTime.Now.AddDays(1),
                    Comments = null,
                    IdClient = 1,
                    IdEmployee = 1
                },
                new Zamowienie
                {
                    IdOrder = 2,
                    AcceptanceDate = DateTime.Now,
                    RealizationDate = DateTime.Now.AddDays(1),
                    Comments = "Na środę!",
                    IdClient = 2,
                    IdEmployee = 2
                });
            modelBuilder.Entity<ZamowienieProdukt>().HasData(
                new ZamowienieProdukt
                {
                    IdOrder = 1,
                    IdConfectioneryProduct = 1,
                    Quantity = 40,
                    Comments = "Szybka dostawa"
                },
                new ZamowienieProdukt
                {
                    IdOrder = 2,
                    IdConfectioneryProduct = 1,
                    Quantity = 20,
                    Comments = null
                });
              
        }
    }
}
