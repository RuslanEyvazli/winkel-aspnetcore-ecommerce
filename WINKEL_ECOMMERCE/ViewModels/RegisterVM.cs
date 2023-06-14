using System.ComponentModel.DataAnnotations;

namespace WINKEL_ECOMMERCE.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [StringLength(maximumLength: 70, MinimumLength = 7)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required]
        [MinLength(3)]
        public string Username { get; set; }
        [Required]
        [MinLength(3)]
        public string Firstname { get; set; }

        public string Lastname { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } 
        [DataType(DataType.Password)]
        [Required,Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
