using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ShoesShop.Models;

namespace ShoesShop.ViewModels
{
    /// <summary>
    /// All categories displays as one object
    /// </summary>
    public class ShoesListViewModel
    {
        public IEnumerable<Shoes> AllShoes { get; set; }

        public string CurrentCategory { get; set; }
    }
}
