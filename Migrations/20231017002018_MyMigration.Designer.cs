﻿// <auto-generated />
using CodingCafe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodingCafe.Migrations
{
    [DbContext(typeof(CafeContext))]
    [Migration("20231017002018_MyMigration")]
    partial class MyMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CodingCafe.Models.Customers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Favorite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FavoritesId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("GenderIdentity")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Zip")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Email = "jacksmith@gmail.com",
                            FavoritesId = 0,
                            FirstName = "Jack",
                            LastName = "Smith"
                        },
                        new
                        {
                            ID = 2,
                            Email = "jillsmith@gmail.com",
                            FavoritesId = 0,
                            FirstName = "Jill",
                            LastName = "Smith"
                        },
                        new
                        {
                            ID = 3,
                            FavoritesId = 0,
                            FirstName = "Steve",
                            LastName = "Jobs"
                        },
                        new
                        {
                            ID = 4,
                            FavoritesId = 0,
                            FirstName = "Bill",
                            LastName = "Gates"
                        });
                });

            modelBuilder.Entity("CodingCafe.Models.Favorites", b =>
                {
                    b.Property<int>("FavoritesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FavoritesId"), 1L, 1);

                    b.Property<string>("Favorite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FavoritesId");

                    b.ToTable("Favorite");

                    b.HasData(
                        new
                        {
                            FavoritesId = 1,
                            Favorite = "Javascript Java"
                        },
                        new
                        {
                            FavoritesId = 2,
                            Favorite = ".NET Decaf"
                        },
                        new
                        {
                            FavoritesId = 3,
                            Favorite = "HTML Hot Cocoa"
                        },
                        new
                        {
                            FavoritesId = 4,
                            Favorite = "LINQ Latte"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
