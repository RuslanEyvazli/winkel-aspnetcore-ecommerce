using System.ComponentModel.DataAnnotations;

namespace WINKEL_ECOMMERCE.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}
