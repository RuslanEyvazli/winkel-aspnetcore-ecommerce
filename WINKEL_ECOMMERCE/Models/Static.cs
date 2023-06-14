using System.ComponentModel.DataAnnotations;

namespace WINKEL_ECOMMERCE.Models
{
    public class Static
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 50)]
        public string Name { get; set; } 
        public int Count { get; set; }
    }
}
