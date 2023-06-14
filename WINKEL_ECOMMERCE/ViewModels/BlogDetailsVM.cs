using WINKEL_ECOMMERCE.Models;

namespace WINKEL_ECOMMERCE.ViewModels
{
    public class BlogDetailsVM
    {
        public Post Post { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public Comment Comment { get; set; }
    }
}
