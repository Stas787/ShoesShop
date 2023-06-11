using Microsoft.EntityFrameworkCore;
using ShoesShop.Models;

namespace ShoesShop
{
    public class DataBaseContent : DbContext
    {
        public DataBaseContent(DbContextOptions<DataBaseContent> options) : base(options)
        {

        }

        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopShoesItem> ShopShoesItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
