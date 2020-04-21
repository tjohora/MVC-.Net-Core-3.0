using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TJOHora_CA1MVC.Models;

namespace TJOHora_CA1MVC.ViewModels
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }
        public decimal CartTotal { get; set; }
    }
}
