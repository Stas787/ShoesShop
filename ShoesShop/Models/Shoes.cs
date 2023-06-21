using System.Collections.Generic;

namespace ShoesShop.Models
{
    public class Shoes
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string ShortExposition { get; set; }

        public string ExtensiveExposition { get; set; }

        public string Img { get; set; }

        public decimal Price { get; set; }

        public bool IsFavorite { get; set; }

        public int Available { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
