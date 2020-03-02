using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJOHora_CA1MVC.Models
{
    public class MockGameRepository : IGameRepository
    {
        public IEnumerable<Game> AllGames =>
        new List<Game>
        {
            new Game{gameId = 1, name = "Halo", developer = "Bungie", releaseDate = "1/2/2010", genre = "Shooter"},
            new Game{gameId = 2, name = "Tetris", developer = "Alexy Pajitnov", releaseDate = "2/4/1980", genre = "Puzzle"},
            new Game{gameId = 3, name = "Rainbow Six: Siege", developer = "Ubisoft", releaseDate = "5/7/2015", genre = "Shooter"}
        };

        public Game GetGameById(int id)
        {
            return AllGames.FirstOrDefault(b => b.gameId == id);
        }

    }
}
