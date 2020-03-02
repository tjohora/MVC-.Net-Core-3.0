using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TJOHora_CA1MVC.Data;

namespace TJOHora_CA1MVC.Models
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _appDbContext;

        public GameRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Game> AllGames
        {
            get
            {
                return _appDbContext.Games;
            }
            
        }

        public Game GetGameById(int id)
        {
            return _appDbContext.Games.FirstOrDefault(b => b.gameId == id);
        }
    }
}
