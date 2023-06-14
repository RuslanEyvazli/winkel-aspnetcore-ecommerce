using WINKEL_ECOMMERCE.Models;

namespace WINKEL_ECOMMERCE.ViewModels
{
    public class HomeIndexVM
    {
    #nullable disable
        public IEnumerable<Slider> Sliders { get; set; }
        public Ship Ship { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Summer Summer { get; set; }
        public IEnumerable<Static> Static { get; set; }
        public IEnumerable<SatisfiedCustomer> SatisfiedCustomers { get; set; }
    }
}
