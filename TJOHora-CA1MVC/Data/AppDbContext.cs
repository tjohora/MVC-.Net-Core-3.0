using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TJOHora_CA1MVC.Models;

namespace TJOHora_CA1MVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(new Game
            {
                gameId = 1,
                name = "Titanfall 2",
                developer = "Respawn Entertainment",
                releaseDate = "28/10/2016",
                genre = "Shooter"
            });
            modelBuilder.Entity<Game>().HasData(new Game
            {
                gameId = 2,
                name = "Doom",
                developer = "Id Software",
                releaseDate = "15/1/2016",
                genre = "Shooter"
            });
            modelBuilder.Entity<Game>().HasData(new Game
            {
                gameId = 3,
                name = "Dark Souls",
                developer = "From Software",
                releaseDate = "10/9/2009",
                genre = "Shooter"
            });
        }
        
        
    }
}
