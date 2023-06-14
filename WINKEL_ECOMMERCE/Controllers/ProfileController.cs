using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WINKEL_ECOMMERCE.DAL;
using WINKEL_ECOMMERCE.Extensions;
using WINKEL_ECOMMERCE.Models;

namespace WINKEL_ECOMMERCE.Controllers
{
    public class ProfileController : Controller
    {
        private readonly WINKEL_ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public ProfileController(WINKEL_ApplicationDbContext context, IWebHostEnvironment env, UserManager<AppUser> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreatePost()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(Post post)
        {
            if (ModelState.IsValid) return View(post);
            if (post.Photo is not null)
            {
                if (!post.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Image is not valid!");
                    return View(post);
                }
                else
                {

                    post.Image = await post.Photo.SaveFileAsync(_env);
                    AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                    post.AppUserId = user.Id;
                    await _context.Posts.AddAsync(post);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Posts");
                }
            }
            else
            {
                ModelState.AddModelError("Photo", "Image should be selected");
                return View(post);
            }

            //string unique = Guid.NewGuid().ToString();
            //string uniqueFileName = unique + post.Photo.FileName;
            //string path = Path.Combine(_env.WebRootPath,"image",uniqueFileName);
            //using(FileStream stream = new FileStream(path, FileMode.Create))
            //{
            //    await post.Photo.CopyToAsync(stream);
            //}
        }

    }
}
