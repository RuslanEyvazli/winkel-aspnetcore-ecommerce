using WINKEL_ECOMMERCE.Models;
namespace WINKEL_ECOMMERCE.ViewModels
{
    public class ProductPartialVM
    {
        public IEnumerable<Product> Products { get; set; }
        public string ClassName { get; set; }
    }
}
