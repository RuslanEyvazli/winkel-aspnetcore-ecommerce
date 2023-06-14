using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WINKEL_ECOMMERCE.ViewModels;
using WINKEL_ECOMMERCE.Models;
using System.Net.Mail;
using System.Net;
using WINKEL_ECOMMERCE.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace WINKEL_ECOMMERCE.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            AppUser appUser = new AppUser
            {
                Email = registerVM.Email,
                Firstname = registerVM.Firstname,
                Lastname = registerVM.Lastname,
                UserName = registerVM.Username
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);

            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                string subject = "Welcome to Winkel Registration";
                // string path = $"{Request.Scheme}//{Request.Host}/Auth/RegisterConfirm?email={appUser.Email}&token={token}";
                string? path = Url.Action("RegisterConfirm", "Auth",
                  new { email = appUser.Email, token = token }, Request.Scheme);
                string body = $"Zehmet olmasa hesabi doğrulamaq üçün bu <a href={path}> link </a> klik edin.";
                var emailResponse = _configuration.SendEmail(appUser.Email, subject, body);




                //return RedirectToAction(actionName: "Confirming",controllerName: "Auth", routeValues : new { email = registerVM.Email });
                return RedirectToAction(nameof(Confirming));
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            }
        }
        //[Route("/{Auth}/{Confirming}/{email}")]
        //public IActionResult Confirming(string? email)
        //{
        //    return View(email);
        //}
        [AllowAnonymous]

        public IActionResult Confirming()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> RegisterConfirm(string email, string token)
        {
            var foundedUser = await _userManager.FindByEmailAsync(email);
            if( foundedUser == null)
            {
                ViewBag.Message = "Xetali token";
                goto end;
            }
            token = token.Replace(" ", "+");
            IdentityResult result = await _userManager.ConfirmEmailAsync(foundedUser, token);

            if (!result.Succeeded)
            {
                ViewBag.Message = "Xetali token";
                goto end;
            }
            end:
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);
            AppUser appUser = await _userManager.FindByEmailAsync(loginVM.Email);
            if (appUser == null) 
            {
                ModelState.AddModelError("", "Username or Password is invalid");
                return View(loginVM);
            }
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.RememberMe,true);
            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or Password is invalid");
                return View(loginVM);
            }
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
