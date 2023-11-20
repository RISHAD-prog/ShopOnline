using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Data
{
    public class ShopOnlineContext: DbContext
    {
        public ShopOnlineContext( DbContextOptions<ShopOnlineContext> dbContextOptions ) : base( dbContextOptions )
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }

    }
}
