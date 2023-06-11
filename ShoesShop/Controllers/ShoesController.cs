using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ShoesShop.Interfaces;
using ShoesShop.ViewModels;
using ShoesShop.Models;

namespace WebApplicationPractice.Controllers
{
    public class ShoesController : Controller
    {
        private readonly IAllShoes AllShoes;
        public readonly IShoesCategory ShoesCategory;

        public ShoesController(IAllShoes iAllShoes, IShoesCategory iShoesCategory)
        {
            AllShoes = iAllShoes;
            ShoesCategory = iShoesCategory;
        }

        [Route("Shoes/ListOfItems/{category}")]
        [Route("Shoes/ListOfItems")]
        /// <summary>
        /// Return list of all items. 
        /// </summary>
        /// <returns></returns>        
        public ViewResult ListOfItems(string category)
        {
            IEnumerable<Shoes> shoes = null;
            string currentCategory= "";

            if (string.IsNullOrEmpty(category))
            {
                shoes = AllShoes.Shoes.OrderBy(item => item.Id);
            }            
            else if (string.Equals("Sneakers", category, StringComparison.OrdinalIgnoreCase))
            {
                shoes = AllShoes.Shoes.Where(item => item.Category.StringName.Equals("Sneakers")).OrderBy(item => item.Id);
                currentCategory = "Sneakers";
            }
            else if (string.Equals("RunningShoes", category, StringComparison.OrdinalIgnoreCase))
            {
                shoes = AllShoes.Shoes.Where(item => item.Category.StringName.Equals("Running shoes")).OrderBy(item => item.Id);
                currentCategory = "Running shoes";
            }

            var shoesObject = new ShoesListViewModel
            {
                AllShoes = shoes,
                CurrentCategory = currentCategory,
            };

            ViewBag.Title = "Shoes";

            return View(shoesObject);
         }
    }
}
