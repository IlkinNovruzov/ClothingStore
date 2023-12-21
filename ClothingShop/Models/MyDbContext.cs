using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set;}
        public DbSet<Category> Categories { get; set;}
        public DbSet<Blog> Blogs { get; set;}
    }
}
