using Microsoft.AspNetCore.Mvc;
using WINKEL_ECOMMERCE.DAL;
using WINKEL_ECOMMERCE.ViewModels;

namespace WINKEL_ECOMMERCE.Controllers
{
    public class AjaxController : Controller
    {
        private readonly WINKEL_ApplicationDbContext _context;
        public AjaxController(WINKEL_ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Subscribe(string? email)
        {
            if (_context.Subscribers.Any(s => s.Email == email))
            {
                return Ok(new
                {
                    status = 410,
                    data = "",
                    message = "Email exists"
                });
            }
            else
            {
                await _context.Subscribers.AddAsync(new Models.Subscriber { Email = email });
                await _context.SaveChangesAsync();
            }

            return Ok(new
            {
                status = 200,
                data = "",
                message = "Email was added"
            });
        }
        public IActionResult LoadProducts(int skip)
        {
            //var products = _context.Products.OrderByDescending(pr => pr.CreatedAt).Skip(skip).Take(3);

            //return Ok(new
            //{
            //    status = 200,
            //    message = "",
            //    data = products
            //});

            if (skip >= _context.Products.Count()) return NoContent();
            return PartialView("_ProductPartialView",new ProductPartialVM() { Products = _context.Products.OrderByDescending(pr => pr.CreatedAt).Skip(skip).Take(3), ClassName = "col-lg-4 col-md-6" });
        }
    }
}
