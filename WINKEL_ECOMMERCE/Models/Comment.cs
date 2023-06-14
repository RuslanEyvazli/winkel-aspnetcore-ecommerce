<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> b9795eb545a5c97e33d4e33e1211f5ef04577782
using System.ComponentModel.DataAnnotations.Schema;

namespace WINKEL_ECOMMERCE.Models
{
    public class Comment
    {
        [Key ]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        [StringLength(maximumLength: 300,MinimumLength =1)]
        [Required]
        public string Contents { get; set; }
<<<<<<< HEAD
        public int PostId { get; set; }
        public string AppUserId { get; set; }
        public int? ParentId { get; set; }
=======
 
        public int? PostId { get; set; }
        public string AppUserId { get; set; }
        public int ParentId { get; set; }
>>>>>>> b9795eb545a5c97e33d4e33e1211f5ef04577782
        public virtual Comment Parent { get; set; }
        public virtual ICollection<Comment> Children { get; set; }
        [ForeignKey(nameof(AppUserId))]
        public virtual AppUser AppUser { get; set; }
        [ForeignKey(nameof(PostId))]
        public virtual Post Post { get; set; }

    }
}
