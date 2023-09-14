using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }
        
        public int ProductId { get; set; }
        
        [ForeignKey("ProductId")]
        public Product Product { get; set; } // one to many
    }
}
