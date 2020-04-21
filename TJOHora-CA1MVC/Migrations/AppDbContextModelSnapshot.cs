﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TJOHora_CA1MVC.Data;

namespace TJOHora_CA1MVC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TJOHora_CA1MVC.Models.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CartId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfItems")
                        .HasColumnType("int");

                    b.Property<int?>("gameId")
                        .HasColumnType("int");

                    b.HasKey("CartItemId");

                    b.HasIndex("gameId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("TJOHora_CA1MVC.Models.Game", b =>
                {
                    b.Property<int>("gameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("developer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("releaseDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("gameId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            gameId = 1,
                            Price = 30.50m,
                            developer = "Respawn Entertainment",
                            genre = "Shooter",
                            name = "Titanfall 2",
                            releaseDate = "28/10/2016"
                        },
                        new
                        {
                            gameId = 2,
                            Price = 50.50m,
                            developer = "Id Software",
                            genre = "Shooter",
                            name = "Doom",
                            releaseDate = "15/1/2016"
                        },
                        new
                        {
                            gameId = 3,
                            Price = 10.99m,
                            developer = "From Software",
                            genre = "Rpg",
                            name = "Dark Souls",
                            releaseDate = "10/9/2009"
                        });
                });

            modelBuilder.Entity("TJOHora_CA1MVC.Models.CartItem", b =>
                {
                    b.HasOne("TJOHora_CA1MVC.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("gameId");
                });
#pragma warning restore 612, 618
        }
    }
}
