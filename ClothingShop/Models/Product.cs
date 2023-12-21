using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int CatgeoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual List<Category> Categroies { get; set; }
    }
}
