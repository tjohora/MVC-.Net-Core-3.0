using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TJOHora_CA1MVC.Models
{
    public class Game
    {
        public int gameId { get; set; }

        [Required(ErrorMessage = "Please enter the game's name.")]
        [StringLength(50, ErrorMessage = "The name must be less than {1} characters.")]
        [Display(Name = "Game Name:")]
        public String name { get; set; }

        [Required(ErrorMessage = "Please enter the develper's name")]
        [StringLength(50, ErrorMessage = "The name must be less than {1} characters.")]
        [Display(Name = "Developer Name:")]
        public String developer { get; set; }

        [Required(ErrorMessage = "Please enter a release date.")]
        public String releaseDate { get; set; }

        [Required(ErrorMessage = "Please enter the genre name.")]
        public String genre { get; set; }

        [Required(ErrorMessage = "Please enter the price.")]
        public decimal Price { get; set; }
    }
}
