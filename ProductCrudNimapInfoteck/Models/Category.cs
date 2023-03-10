using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCrudNimapInfoteck.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [ScaffoldColumn(false)]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(20)]
        public string? CategoryName { get; set; }
    }
}
