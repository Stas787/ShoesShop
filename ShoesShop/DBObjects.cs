using ShoesShop.Models;

namespace ShoesShop
{
    public class DBObjects
    {
        private static Dictionary<string, Category> Category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (Category == null)
                {
                    var list = new Category[]
                    {
                        new Category { StringName = "Running shoes", Exposition = "For sport and living" },
                    new Category { StringName  = "Sneakers", Exposition = "Simple, stylish, comfortable "}
                    };

                    Category = new Dictionary<string, Category>();

                    foreach (var item in list)
                    {
                        Category.Add(item.StringName, item);
                    }
                }

                return Category;
            }
        }

        public static void Initial(DataBaseContent content)
        {
            

            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(content => content.Value));
            }

            if (!content.Shoes.Any())
            {
                content.AddRange(
                    new Shoes
                    {
                        Name = "Model 1",
                        ShortExposition = "Basic model for life",
                        ExtensiveExposition = "Extremly comfortable",
                        Img = "/img/base model 1/base model 1.jpg",
                        Price = 4000,
                        Available = 3,
                        IsFavorite = true,
                        Category = Category["Sneakers"]
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
                        Category = Category["Sneakers"]
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
                        Category = Category["Running shoes"]
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
                        Category = Category["Sneakers"]
                    }

                    );
            }
            content.SaveChanges();
        }



    }
}
