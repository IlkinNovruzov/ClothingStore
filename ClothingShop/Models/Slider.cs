using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ClothingShop.Models
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Image { get; set; }
        [ValidateNever]
        public string Description { get; set; }
        [NotMapped]
        public IFormFile ImgFile { get; set; }
    }
}
