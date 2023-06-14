using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace WINKEL_ECOMMERCE.Models
{
    #nullable disable
    public class Summer
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 255)]
        public string LeftImage { get; set; }

        [StringLength(maximumLength: 200)]
        public string LeftHeading { get; set; }

        [StringLength(maximumLength: 300)]
        public string LeftContent { get; set; }

        [StringLength(maximumLength: 255)]
        public string RightImage { get; set; }

        [StringLength(maximumLength: 200)]
        public string RightHeading { get; set; }

        [StringLength(maximumLength: 300)]
        public string RightContent { get; set; }
    }
}
