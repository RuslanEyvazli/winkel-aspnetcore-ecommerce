namespace WINKEL_ECOMMERCE.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<PostTags> PostTags { get; set; }
    }
}
