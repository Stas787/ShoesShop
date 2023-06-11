using ShoesShop.Models;

namespace ShoesShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Shoes> FavoriteShoes { get; set; }   
    }
}
