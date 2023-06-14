using System.ComponentModel.DataAnnotations;

namespace WINKEL_ECOMMERCE.Models
{
    public class SatisfiedCustomer
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 255)]
        public string Image { get; set; }

        [StringLength(maximumLength: 100)]
        public string AltImage { get; set; }

        [StringLength(maximumLength: 100)]
        public string Icon { get; set; }

        [StringLength(maximumLength: 300)]
        public string Content { get; set; }

        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
        [StringLength(maximumLength: 100)]
        public string? Position { get; set; }
    }
}
