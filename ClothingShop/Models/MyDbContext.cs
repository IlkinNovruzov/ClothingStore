using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Models
{
    public class MyDbContext : IdentityDbContext<AppUser>
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set;}
        public DbSet<Category> Categories { get; set;}
        public DbSet<Blog> Blogs { get; set;}
        public DbSet<Slider> Sliders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slider>().HasData(
                new Slider
                {
                    Id = 1,
                    Name = "New Trend",
                    Title="Summer Sale Stylish",
                    Description="TestDescription",
                    Image= "slideshow-character2.png"
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
