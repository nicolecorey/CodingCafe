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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>().HasData(
                new Customers
                {
                    ID = 1,
                    FirstName = "Jack",
                    LastName = "Smith",
                    Email = "jacksmith@gmail.com"
                },
                new Customers
                {
                    ID = 2,
                    FirstName = "Jill",
                    LastName = "Smith",
                    Email = "jillsmith@gmail.com"
                },
                new Customers
                {
                    ID = 3,
                    FirstName = "Steve",
                    LastName = "Jobs"
                },
                new Customers
                {
                    ID = 4,
                    FirstName = "Bill",
                    LastName = "Gates"
                },
                new Customers
                {
                    ID = 5,
                    FirstName = "Mark",
                    LastName = "Zuckerberg"
                }


            );

        }
    }
}