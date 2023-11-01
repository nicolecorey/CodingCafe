using System.ComponentModel.DataAnnotations;

namespace CodingCafe.Models
{
    public class Favorites
    {
        [Display(Name = "Favorite ID")]
        public int FavoritesId { get; set; }

        [Display(Name = "Favorite Coffee")]
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
