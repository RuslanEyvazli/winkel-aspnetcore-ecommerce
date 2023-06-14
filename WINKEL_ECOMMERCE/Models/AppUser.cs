using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WINKEL_ECOMMERCE.Models
{
#nullable disable
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Posts = new HashSet<Post>();
            Comments = new HashSet<Comment>();
        }
        [Required]
        [StringLength(maximumLength:50,MinimumLength =2)]
        public string Firstname { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        [StringLength(maximumLength:255)]
        public string Image { get; set; }
        
        [NotMapped]
        public IFormFile Photo { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }

  
}
