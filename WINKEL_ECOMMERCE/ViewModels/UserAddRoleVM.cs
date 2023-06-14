using WINKEL_ECOMMERCE.Models;

namespace WINKEL_ECOMMERCE.ViewModels
{
    public class UserAddRoleVM
    {
        public AppUser AppUser { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
