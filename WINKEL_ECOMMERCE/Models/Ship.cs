using System.ComponentModel.DataAnnotations;

namespace WINKEL_ECOMMERCE.Models
{
#nullable disable
    public class Ship
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength:255)]
        public string Image { get; set; }

        [StringLength(maximumLength: 100)]
        public string AltImage { get; set; }
        
        [StringLength(maximumLength: 300)]
        public string Link { get; set; }

        [StringLength(maximumLength: 100)]
        public string Header { get; set; }

        [StringLength(maximumLength: 300)]
        public string Description { get; set; }

        public virtual ICollection<ShipItem> ShipItems { get; set; }
    }
}
