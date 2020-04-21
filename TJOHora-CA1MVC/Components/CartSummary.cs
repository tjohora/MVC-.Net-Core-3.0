using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TJOHora_CA1MVC.Models;
using TJOHora_CA1MVC.ViewModels;

namespace TJOHora_CA1MVC.Components
{
    public class CartSummary : ViewComponent
    {
        private readonly Cart _cart;

        public CartSummary (Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
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
    }
}
