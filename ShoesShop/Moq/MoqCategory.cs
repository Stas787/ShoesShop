using System.Collections.Generic;
using ShoesShop.Interfaces;
using ShoesShop.Models;

namespace ShoesShop.Moq
{
    public class MoqCategory : IShoesCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category> {
                    new Category { StringName = "Running shoes", Exposition = "For sport and living" },
                    new Category { StringName  = "Sneakers", Exposition = "Simple, stylish, comfortable "}
                };


            }
        }
    }
}
