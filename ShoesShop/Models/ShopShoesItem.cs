namespace ShoesShop.Models
{
    /// <summary>
    /// Responsible for items in basket
    /// </summary>
    public class ShopShoesItem
    {
        public int Id { get; set; } //id of shoes

        public Shoes Shoes { get; set; }

        public decimal Price { get; set; }

        public string ShopShoesId { get; set; } // id of shoes in basket

    }
}
