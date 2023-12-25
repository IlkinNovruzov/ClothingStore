using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingShop.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Username { get; set; }
        public DateTime DateTime { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        [NotMapped]
        public IFormFile ImgFile { get; set; }
    }
}
