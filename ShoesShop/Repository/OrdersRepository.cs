using ShoesShop.Interfaces;
using ShoesShop.Models;

namespace ShoesShop.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly DataBaseContent Content;

        private readonly ShopBasket ShopBasket;

        public OrdersRepository (DataBaseContent content, ShopBasket shopBasket)
        {
            Content = content;
            ShopBasket = shopBasket;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            Content.Order.Add(order);
            var items = ShopBasket.ListShopItems;

            foreach (var item in items)
            {
                var orderDetail = new OrderDetail()
                {
                    ShoesId = item.Shoes.Id,
                    OrderId = order.Id,
                    Price = item.Shoes.Price
                };

                Content.OrderDetail.Add(orderDetail);
            }

            Content.SaveChanges();
        }
    }
}
