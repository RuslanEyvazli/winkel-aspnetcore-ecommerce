using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WINKEL_ECOMMERCE.Models;
using WINKEL_ECOMMERCE.ViewModels;

namespace WINKEL_ECOMMERCE.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UsersController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager =roleManager;
        }

        public IActionResult Index()
        {
            ViewData["active_nav"] = "users";
            return View(_userManager.Users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            ViewData["active_nav"] = "users";
            if (id == null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(id);
            return View(user);
        }

        public async Task<IActionResult> Delete(string userId, string role)
        {
            if (userId is null || role is null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(userId);
            if(user == null) return NotFound();
            IdentityResult result = await _userManager.RemoveFromRoleAsync(user, role);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Role Cannot be removed");
                return RedirectToAction(nameof(Edit), new { id = userId });
            }
            return RedirectToAction(nameof(Edit), new { id = userId});
        }

        public async Task<IActionResult> AddRole(string userId)
        {
            if (userId is null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            IList<string> userRole = await _userManager.GetRolesAsync(user);

            UserAddRoleVM userAddRoleVM = new UserAddRoleVM
            {
                AppUser = user,
                Roles = _roleManager.Roles.Select(role => role.Name).ToList().Except(userRole)
                //Roles = _roleManager.Roles.Where(role => userRole.IndexOf(role.Name) == -1);
            };

            return View(userAddRoleVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddRole(string userId,string role)
        {
            if (userId is null) return NotFound();
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            IdentityResult result = await _userManager.AddToRoleAsync(user,role);
            if (!result.Succeeded) 
            {
                ModelState.AddModelError("", "");
                return View(userId);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
