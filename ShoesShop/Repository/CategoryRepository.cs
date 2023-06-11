using ShoesShop.Interfaces;
using ShoesShop.Models;

namespace ShoesShop.Repository
{
    public class CategoryRepository : IShoesCategory
    {
        private readonly DataBaseContent DataBaseContent;

        public CategoryRepository (DataBaseContent dataBaseContent)
        {
            DataBaseContent = dataBaseContent;
        }
        public IEnumerable<Category> AllCategories => DataBaseContent.Category;
    }
}
