using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TJOHora_CA1MVC.Data;
using TJOHora_CA1MVC.Models;
using TJOHora_CA1MVC.ViewModels;

namespace TJOHora_CA1MVC.Controllers
{
    public class GameController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IGameRepository _GameRepository;
        public GameController(IGameRepository GameRepository, AppDbContext context) //change MockGameRepository to GameRepository when db is used
        {
            _GameRepository = GameRepository;
            _context = context;
        }
        public ViewResult List()
        {
            GameListViewModel gameListViewModel = new GameListViewModel();
            gameListViewModel.Games = _GameRepository.AllGames;
            ViewBag.CurrenCategory = "Games";
            return View(gameListViewModel);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("gameId,name,developer,releaseDate,genre,Price")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return Redirect(nameof(List));
            }
            return View(game);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("gameId,name,developer,releaseDate,genre,Price")] Game game)
        {
            game.gameId = id;
            if(id != game.gameId)
            {
                return NotFound();
            }
            Console.WriteLine(ModelState.IsValid);
            //if (ModelState.IsValid)
            if(true)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.gameId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                Console.WriteLine("Done!");
                return RedirectToAction(nameof(List));
            }
            Console.WriteLine("Not Done!");
            return View(game);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _context.Games.FindAsync(id);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(g => g.gameId == id);
        }
    }
}