using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using WINKEL_ECOMMERCE.DAL;

namespace WINKEL_ECOMMERCE.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = nameof(Admin))]
    public class DashboardController : Controller
    {
        private readonly WINKEL_ApplicationDbContext _context;
        public DashboardController(WINKEL_ApplicationDbContext context)
        {
            _context = context;
        }
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public  IActionResult Index()
        {
            ViewData["active_nav"] = "dashboard";
            return View();
        }
    }
}
