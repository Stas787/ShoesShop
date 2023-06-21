using Microsoft.EntityFrameworkCore;
using ShoesShop.Interfaces;
using ShoesShop.Models;

namespace ShoesShop.Repository
{
    public class ShoesRepository : IAllShoes
    {
        private readonly DataBaseContent DataBaseContent;

        public ShoesRepository (DataBaseContent dataBaseContent)
        {
            DataBaseContent = dataBaseContent;    
        }

        public IEnumerable<Shoes> Shoes => DataBaseContent.Shoes.Include(data => data.Category) ;

        public IEnumerable<Shoes> GetFavoriteShoes => DataBaseContent.Shoes.Where(choose => 
            choose.IsFavorite).Include(data => data.Category);

        public Shoes GetObjectShoes(int shoesID) => DataBaseContent.Shoes.FirstOrDefault(identifire => 
            identifire.Id == shoesID);
       
    }
}
