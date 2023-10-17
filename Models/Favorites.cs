using System.ComponentModel.DataAnnotations;

namespace CodingCafe.Models
{
    public class Favorites
    {
        public int FavoritesId { get; set; }

        [Display(Name = "Item")]
        public string? Item { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}
