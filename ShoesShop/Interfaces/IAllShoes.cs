using System.Collections.Generic;
using ShoesShop.Models;

namespace ShoesShop.Interfaces
{
    public interface IAllShoes
    {
        IEnumerable<Shoes> Shoes { get; } //when it is needed to return collcentions of items
        IEnumerable<Shoes> GetFavoriteShoes { get; }

        Shoes GetObjectShoes(int shoesID);
    }
}
