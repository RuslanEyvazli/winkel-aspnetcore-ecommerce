using System.ComponentModel.DataAnnotations;
namespace WINKEL_ECOMMERCE.ViewModels
{
    public class LoginVM
    {

        [Required]
        [StringLength(maximumLength: 70, MinimumLength = 7)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;

    }
}
