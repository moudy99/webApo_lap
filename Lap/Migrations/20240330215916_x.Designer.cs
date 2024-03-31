﻿// <auto-generated />
using Lap.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lap.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240330215916_x")]
    partial class x
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lap.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description 1",
                            Name = "Product 1",
                            price = 10
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description 2",
                            Name = "Product 2",
                            price = 20
                        },
                        new
                        {
                            Id = 3,
                            Description = "Description 3",
                            Name = "Product 3",
                            price = 30
                        },
                        new
                        {
                            Id = 4,
                            Description = "Description 4",
                            Name = "Product 4",
                            price = 40
                        },
                        new
                        {
                            Id = 5,
                            Description = "Description 5",
                            Name = "Product 5",
                            price = 50
                        });
                });
#pragma warning restore 612, 618
        }
    }
}