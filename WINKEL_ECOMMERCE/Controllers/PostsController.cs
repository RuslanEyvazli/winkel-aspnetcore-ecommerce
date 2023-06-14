using Microsoft.AspNetCore.Mvc;
using WINKEL_ECOMMERCE.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WINKEL_ECOMMERCE.Models;
using WINKEL_ECOMMERCE.ViewModels;

namespace WINKEL_ECOMMERCE.Controllers
{
    public class PostsController : Controller
    {
        private readonly WINKEL_ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public PostsController(WINKEL_ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Route("Posts/Index/{username?}")]
        public async Task<IActionResult> Index(string? username)
        {
            if(username != null)
            {
                AppUser user = await _userManager.FindByNameAsync(username);
                if(user != null)
                {
                    return View(_context.Posts.Where(post => post.AppUserId == user.Id).OrderByDescending(post => post.CreatedAt).ToList());

                }
            }

            //Eager loading
            //return View(_context.Posts.Include(post => post.AppUser).ToList());
            //LazyLoading
            return View(_context.Posts.OrderByDescending(post => post.CreatedAt).ToList());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id <= 0) return RedirectToAction(nameof(Index));
            Post post = await _context.Posts.FindAsync(id);
<<<<<<< HEAD
            
=======
>>>>>>> b9795eb545a5c97e33d4e33e1211f5ef04577782
            if(post == null) return RedirectToAction(nameof(Index));
            BlogDetailsVM blogDetailsVM = new BlogDetailsVM()
            {
                Post = post,
                Posts = await _context.Posts.OrderByDescending(post => post.CreatedAt).Where(p => p.Id != post.Id).Take(3).ToListAsync()
            };
<<<<<<< HEAD

            return View(blogDetailsVM);
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(int? commentId, int postId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return Json(new
                {
                    error = true,
                    message = "Comment could not be empty"
                });
            }
            if(postId < 1)
            {
                return Json(new
                {
                    error = true,
                    message = "Post does not exsist"
                });
            }
            var post = _context.Posts.FirstOrDefault(c => c.Id == postId);
            if (post == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Post does not exsist"
                });
            }

            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            Comment comment = new Comment
            {
                AppUserId = appUser.Id,
                PostId = postId,
                Contents = content,
                
            };
            if (commentId == null && !await _context.Comments.AnyAsync(u => u.Id == commentId))
            {
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                comment.ParentId = comment.Id;
                _context.Comments.Update(comment);
                await _context.SaveChangesAsync();
            }
            else
            {
                comment.ParentId = (int)commentId;
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();

            }

            return PartialView("_CommentPartialView", comment);
            //return Json(new
            //{
            //    error = false,
            //    message = "Commemt added successfully"
            //});
=======
           TempData["post"] = post;
            return View(blogDetailsVM);
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment,int postId)
        {
            Post post = (Post)TempData["post"];
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            comment.Post = post;
            comment.PostId = post.Id;
            comment.AppUser = appUser;
            comment.AppUserId = appUser.Id;
            if (comment.Contents.Trim() == null) return RedirectToAction(nameof(Details), post.Id);
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details));
>>>>>>> b9795eb545a5c97e33d4e33e1211f5ef04577782
        }
    }
}
