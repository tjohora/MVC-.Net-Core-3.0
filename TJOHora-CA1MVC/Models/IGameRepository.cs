using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJOHora_CA1MVC.Models
{
    public interface IGameRepository
    {
        IEnumerable<Game> AllGames { get; }
        Game GetGameById(int id);
    }
}
