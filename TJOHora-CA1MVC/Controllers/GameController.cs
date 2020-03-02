using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TJOHora_CA1MVC.Models;
using TJOHora_CA1MVC.ViewModels;

namespace TJOHora_CA1MVC.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _GameRepository;
        public GameController(IGameRepository GameRepository) //change MockGameRepository to GameRepository when db is used
        {
            _GameRepository = GameRepository;
        }
        public ViewResult List()
        {
            GameListViewModel gameListViewModel = new GameListViewModel();
            gameListViewModel.Games = _GameRepository.AllGames;
            ViewBag.CurrenCategory = "Games";
            return View(gameListViewModel);
        }
    }
}