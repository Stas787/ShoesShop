using System.Collections.Generic;
using System.Linq;
using ShoesShop.Interfaces;
using ShoesShop.Models;

namespace ShoesShop.Moq
{
    public class MoqShoes : IAllShoes
    {
        private readonly IShoesCategory ShoesCategory = new MoqCategory();
        public IEnumerable<Shoes> Shoes
        {
            get
            {
                return new List<Shoes> {
                    new Shoes
                    {
                        Name = "Model 1",
                        ShortExposition = "Basic model for life",
                        ExtensiveExposition = "Extremly comfortable",
                        Img = "/img/base model 1/base model 1.jpg",
                        Price = 4000,
                        Available = 3,
                        IsFavorite = true,
                        Category = ShoesCategory.AllCategories.First()
                    },
                    new Shoes
                    {
                        Name = "Model 2",
                        ShortExposition = "Basic model for active life",
                        ExtensiveExposition = "Comfortable and ideal for active life",
                        Img = "/img/base model 2/base model 2.jpg",
                        Price = 4000,
                        Available = 4,
                        IsFavorite = false,
                        Category = ShoesCategory.AllCategories.Last()
                    },
                    new Shoes
                    {
                        Name = "Model 3",
                        ShortExposition = "Black variant of comfort",
                        ExtensiveExposition = "Black, comfortable and stylish",
                        Img = "/img/base model 3/base model 3.jpg",
                        Price = 4000,
                        Available = 5,
                        IsFavorite = true,
                        Category = ShoesCategory.AllCategories.First()
                    },
                    new Shoes
                    {
                        Name = "Model 4",
                        ShortExposition = "Black sneakers for active life",
                        ExtensiveExposition = "Comfort for active life has it's own colour",
                        Img = "/img/base model 4/space 1.jpg",
                        Price = 4000,
                        Available = 3,
                        IsFavorite = false,
                        Category = ShoesCategory.AllCategories.Last()
                    }
                };
            }

        }
        public IEnumerable<Shoes> GetFavoriteShoes { get; set; }

        public Shoes GetObjectShoes(int shoesID)
        {
            throw new System.NotImplementedException();
        }
    }
}