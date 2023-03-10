using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCrudNimapInfoteck.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(20)]
        public string? ProductName { get; set; }
        public int CategoryId { get; set; }
        [NotMapped]
        public string? CategoryName { get; set; }
    }
}
