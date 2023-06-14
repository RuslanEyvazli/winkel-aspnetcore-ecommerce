using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WINKEL_ECOMMERCE.Models
{
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            PostTags = new HashSet<PostTags>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 220, MinimumLength = 4)]
        public string Header { get; set; }
        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        [Required]
        [StringLength(255)]
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        [StringLength(450)]
        public string AppUserId { get; set; }
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<PostTags>? PostTags { get; set; }
    }
}
