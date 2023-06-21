namespace ShoesShop.Models
{
    /// <summary>
    /// Responsible for items in basket
    /// </summary>
    public class ShopShoesItem
    {
        public int Id { get; set; }

        public Shoes Shoes { get; set; }

        public decimal Price { get; set; }

        public string ShopShoesId { get; set; } 

    }
}
