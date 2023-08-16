using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        [DisplayName("Category Name")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage = "The field Display Order must be between 1 - 100 (my custom message)")]
        public int DisplayOrder { get; set; }
    }
}
