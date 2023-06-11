using Microsoft.AspNetCore.Mvc;
using ShoesShop.Interfaces;
using ShoesShop.Models;
using ShoesShop.ViewModels;
using System.Diagnostics;

namespace ShoesShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllShoes ShoesRepository;

        public HomeController(IAllShoes shoesRepositry)
        {
            ShoesRepository = shoesRepositry;
        }

        public ViewResult Index()
        {
            var homeShoes = new HomeViewModel
            {
                FavoriteShoes = ShoesRepository.GetFavoriteShoes
            };
            
            return View(homeShoes);
        }
    }
}