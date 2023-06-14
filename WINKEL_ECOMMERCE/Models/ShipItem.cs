using System.ComponentModel.DataAnnotations;

namespace WINKEL_ECOMMERCE.Models
{
#nullable disable
    public class ShipItem
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength:100)]
        public string Icon { get; set; }

        [StringLength(maximumLength: 100)]
        public string Title { get; set; }

        [StringLength(maximumLength: 300)]
        public string Content { get; set; }

        public int ShipId { get; set; }
        public virtual Ship Ship { get; set; }
    }
}
