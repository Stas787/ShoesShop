using Microsoft.AspNetCore.Mvc;
using ShoesShop.Interfaces;
using ShoesShop.Models;
using ShoesShop.ViewModels;

namespace ShoesShop.Controllers
{
    public class ShopBasketController : Controller
    {
        private readonly IAllShoes ShoesRepository;
        private readonly ShopBasket ShopBasket;
        
        public ShopBasketController(IAllShoes shoesRepository, ShopBasket shopBasket)
        {
            ShoesRepository = shoesRepository;
            ShopBasket = shopBasket;
        }

        public ViewResult Index()
        {
            var items = ShopBasket.GetShopItems();
            ShopBasket.ListShopItems = items;

            ShopBasketViewModel basket = new ShopBasketViewModel
            {
                ShopBasketView = ShopBasket
            };

            return View(basket);
        }
        
        /// <summary>
        /// add items, readirect to the new page
        /// </summary>
        /// <returns></returns>
        public RedirectToActionResult AddToBasket(int id)
        {
            var item = ShoesRepository.Shoes.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                ShopBasket.AddToBasket(item);
            }

            return RedirectToAction("Index");
        }

    }
}
