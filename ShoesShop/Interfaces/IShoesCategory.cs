using System.Collections.Generic;
using ShoesShop.Models;

namespace ShoesShop.Interfaces
{
    /// <summary>
    /// Responsible for getting categories
    /// </summary>
    public interface IShoesCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
