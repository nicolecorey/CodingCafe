using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCafe.Models
{
    public class CafeContext : DbContext
    {
        public CafeContext(DbContextOptions<CafeContext> options) : base(options)
        { }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Favorites> Item { get; set; }

             protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
           
            modelBuilder.Entity<Favorites>().HasData(
                new Favorites { FavoritesId = 1, Item = "Javascript Java", Description = "A dark, robust blend." },
                new Favorites { FavoritesId = 2, Item = ".NET Decaf", Description = "A light, decaf blend." },
                new Favorites { FavoritesId = 3, Item = "HTML Hot Cocoa", Description = "Traditional hot chocolate, with whip!" },
                new Favorites { FavoritesId = 4, Item = "LINQ Latte", Description = "A tasty latte made with caramel and vanilla." }

              );
            modelBuilder.Entity<Customers>().HasData(
               new Customers { ID = 1, FavoritesId = 1, FirstName = "Jack", LastName = "Smith", Email = "jacksmith@gmail.com"},
               new Customers { ID = 2, FavoritesId = 2, FirstName = "Jill", LastName = "Smith", Email = "jillsmith@gmail.com"},
               new Customers { ID = 3, FavoritesId = 3, FirstName = "Steve", LastName = "Jobs"},
               new Customers { ID = 4, FavoritesId = 4, FirstName = "Bill", LastName = "Gates"}

             );
        }

    }
 }
