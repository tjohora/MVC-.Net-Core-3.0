using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TJOHora_CA1MVC.Data;

namespace TJOHora_CA1MVC.Models
{
    public class Cart
    {
        private readonly AppDbContext _appDbContext;
        public String CartId { get; set; }
        public List <CartItem> CartItems { get; set; }
        private Cart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new Cart(context) { CartId = cartId };
        }

        public void AddToCart (Game game, int NoOfItems)
        {
            var cartItem = _appDbContext.CartItems.SingleOrDefault(s => s.Game.gameId == game.gameId && s.CartId == CartId);

            if(cartItem == null)
            {
                cartItem = new CartItem
                {
                    CartId = CartId,
                    Game = game,
                    NoOfItems = 1
                };

                _appDbContext.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.NoOfItems++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Game game)
        {
            var cartItem = _appDbContext.CartItems.SingleOrDefault(s => s.Game.gameId == game.gameId && CartId == CartId);

            var localAmount = 0;

            if(cartItem != null)
            {
                if(cartItem.NoOfItems > 1)
                {
                    cartItem.NoOfItems--;
                    localAmount = cartItem.NoOfItems;
                }
                else
                {
                    _appDbContext.CartItems.Remove(cartItem);
                }
            }
            _appDbContext.SaveChanges();

            return localAmount;
        }
        
        public List<CartItem> getCartItems()
        {
            return CartItems ?? (CartItems =_appDbContext.CartItems
                .Where(c => c.CartId == CartId)
                .Include(s => s.Game)
                .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext
                .CartItems
                .Where(c => c.CartId == CartId);

            _appDbContext.CartItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }

        public decimal GetCartTotal()
        {
            var total = _appDbContext.CartItems.Where(c => c.CartId == CartId)
                .Select(c => c.Game.Price * c.NoOfItems).Sum();
            return total;
        }
    }
}
