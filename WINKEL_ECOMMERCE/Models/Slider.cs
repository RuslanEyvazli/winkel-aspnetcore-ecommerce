using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WINKEL_ECOMMERCE.Models
{
    #nullable disable
    public class Slider
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        [DisplayName(displayName: "Vertical text for the left side")]
        public string LeftVerticalText { get; set; }
        [Required]
        [StringLength(maximumLength:150)]
        [DisplayName(displayName: "Super header for the slider")]

        public string SupHeader { get; set; }
        [Required]
        [StringLength(maximumLength: 150, MinimumLength = 10)]
        public string Header { get; set; }
        [Required]
        [StringLength(maximumLength:400, MinimumLength = 10)]
        public string Description { get; set; }

        [StringLength(maximumLength:255)]
        public string Image { get; set; }

        [StringLength(maximumLength: 100)]
        public string AltImage { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
