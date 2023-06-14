using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WINKEL_ECOMMERCE.Models
{
#nullable disable
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [StringLength(maximumLength: 255)]
        public string Image { get; set; }
        [StringLength(maximumLength: 75)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(9,2)")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public decimal Price { get; set; }

        [DefaultValue(false)]
        public bool HasDiscount { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public decimal DiscountPrice { get; set; } 
        public int Rating { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedAt { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
