using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TJOHora_CA1MVC.Models;
using TJOHora_CA1MVC.ViewModels;

namespace TJOHora_CA1MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly Cart _cart;

        public CartController(IGameRepository gameRepository, Cart cart)
        {
            _gameRepository = gameRepository;
            _cart = cart;
        }
        // GET: Cart
        public ViewResult Index()
        {
            var items = _cart.getCartItems();
            _cart.CartItems = items;

            var cartViewModel = new CartViewModel
            {
                Cart = _cart,
                CartTotal = _cart.GetCartTotal()
            };


            return View(cartViewModel);
        }

        [Route("Cart/AddToShoppingCart/{gameId}")]
        public RedirectToActionResult AddToShoppingCart(int gameId)
        {
            var selectedGame = _gameRepository.AllGames.FirstOrDefault(g => g.gameId == gameId);

            Console.WriteLine("Test");
            Console.WriteLine(gameId);
            if (selectedGame != null)
            {
                _cart.AddToCart(selectedGame, 1);
            }
            return RedirectToAction("Index");
        }

        [Route("Cart/RemoveFromShoppingCart/{gameId}")]
        public RedirectToActionResult RemoveFromShoppingCart(int gameId)
        {
            var selectedGame = _gameRepository.AllGames.FirstOrDefault(g => g.gameId == gameId);

            Console.WriteLine(gameId);
            if (selectedGame != null)
            {
                _cart.RemoveFromCart(selectedGame);
            }
            return RedirectToAction("Index");
        }
    }
}