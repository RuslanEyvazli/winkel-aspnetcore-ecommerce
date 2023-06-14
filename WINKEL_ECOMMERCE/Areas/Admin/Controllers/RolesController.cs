using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WINKEL_ECOMMERCE.Models;

namespace WINKEL_ECOMMERCE.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = nameof(Admin))]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            ViewData["active_nav"] = "roles";
            return View(_roleManager.Roles.OrderBy(role=>role.Name));
        }
        public IActionResult Create() 
        {
            ViewData["active_nav"] = "roles";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if(!ModelState.IsValid) return View(role);
            IdentityResult result = await _roleManager.CreateAsync(role);

            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(role);
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
