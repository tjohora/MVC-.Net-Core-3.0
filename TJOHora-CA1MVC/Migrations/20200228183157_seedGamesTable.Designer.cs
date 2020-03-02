﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TJOHora_CA1MVC.Data;

namespace TJOHora_CA1MVC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200228183157_seedGamesTable")]
    partial class seedGamesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TJOHora_CA1MVC.Models.Game", b =>
                {
                    b.Property<int>("gameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                            developer = "Respawn Entertainment",
                            genre = "Shooter",
                            name = "Titanfall 2",
                            releaseDate = "28/10/2016"
                        },
                        new
                        {
                            gameId = 2,
                            developer = "Id Software",
                            genre = "Shooter",
                            name = "Doom",
                            releaseDate = "15/1/2016"
                        },
                        new
                        {
                            gameId = 3,
                            developer = "From Software",
                            genre = "rpg",
                            name = "Dark Souls",
                            releaseDate = "10/9/2009"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
