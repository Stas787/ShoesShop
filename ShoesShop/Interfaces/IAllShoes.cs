using System.Collections.Generic;
using ShoesShop.Models;

namespace ShoesShop.Interfaces
{
    public interface IAllShoes
    {
        IEnumerable<Shoes> Shoes { get; }

        IEnumerable<Shoes> GetFavoriteShoes { get; }

        Shoes GetObjectShoes(int shoesID);
    }
}
