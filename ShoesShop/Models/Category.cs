using System.Collections.Generic;

namespace ShoesShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string StringName { get; set; }

        public string Exposition { get; set; }

        public List<Shoes> ShoesType { get; set; }

    }
}
