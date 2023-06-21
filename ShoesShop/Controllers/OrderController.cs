using Microsoft.AspNetCore.Mvc;
using ShoesShop.Interfaces;
using ShoesShop.Models;

namespace ShoesShop.Controllers
{
    public class OrderController: Controller
    {
        private readonly IAllOrders AllOrders;

        private readonly ShopBasket ShopBasket;

        public OrderController (IAllOrders allOrders, ShopBasket shopBasket)
        {
            AllOrders = allOrders;
            ShopBasket = shopBasket;
        }

        /// <summary>
        /// Returns html pattern with action
        /// </summary>
        /// <returns>html pattern</returns>
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            ShopBasket.ListShopItems = ShopBasket.GetShopItems();

            if (ShopBasket.ListShopItems.Count == 0)
            { 
                ModelState.AddModelError("", "You have to buy shoes"); // outputs an error
            }
            else if(ModelState.IsValid)
            {
                AllOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Your order successfully processed";
            return View();
        }
    }
}
