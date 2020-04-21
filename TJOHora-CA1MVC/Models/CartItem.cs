using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJOHora_CA1MVC.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public Game Game { get; set; }
        public int NoOfItems { get; set; }
        public String CartId { get; set; }
    }
}
