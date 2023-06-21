using Microsoft.EntityFrameworkCore;


namespace ShoesShop.Models
{
    public class ShopBasket
    {
        private readonly DataBaseContent DataBaseContent;

        public ShopBasket(DataBaseContent dataBaseContent)
        {
            this.DataBaseContent = dataBaseContent;
        }

        public string ShopBasketId { get; set; }

        public List<ShopShoesItem> ListShopItems { get; set; }

        /// <summary>
        /// Recognize if there is any item in basket 
        /// </summary>
        /// <returns></returns>
        public static ShopBasket GetBasket(IServiceProvider services)
        {
            //Create new session
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; 
            var context = services.GetService<DataBaseContent>();
            string shopBasketId = session.GetString("BasketId") ?? Guid.NewGuid().ToString();
            session.SetString("BasketId", shopBasketId);
            return new ShopBasket(context) { ShopBasketId = shopBasketId };
        }

        public void AddToBasket(Shoes shoes)
        {
            DataBaseContent.ShopShoesItem.Add(new ShopShoesItem
            {
                ShopShoesId = ShopBasketId,
                Shoes = shoes,
                Price = shoes.Price
            });

            DataBaseContent.SaveChanges();
        }

        public List<ShopShoesItem> GetShopItems()
        {
            return DataBaseContent.ShopShoesItem.Where(item => 
                item.ShopShoesId == ShopBasketId).Include(item => item.Shoes).ToList();
        }

    }
}


