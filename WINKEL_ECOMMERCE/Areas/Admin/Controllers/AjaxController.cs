using Microsoft.AspNetCore.Mvc;
using WINKEL_ECOMMERCE.DAL;
using WINKEL_ECOMMERCE.Models;

namespace WINKEL_ECOMMERCE.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class AjaxController : Controller
    {

        private readonly WINKEL_ApplicationDbContext _context;
        public AjaxController(WINKEL_ApplicationDbContext context)
        {
            _context = context;
        }
        public  IActionResult Index(int? page = 1)
        {
            if (page < 1) page = 1;
            ViewData["total_products_count"] = _context.Products.ToList().Count;
            int totalPages = (int)Math.Ceiling(Convert.ToDecimal(ViewData["total_products_count"]) / 3);
            if (page > totalPages) page = totalPages;
            ViewData["active_page"] = page;
            IEnumerable<Product> products = _context.Products.Skip(((int)page - 1) * 3).Take(3).ToList();
            ViewData["active_nav"] = "products";

            return PartialView("_ProductPartialView",products);

            //return Json(products);

        }

    }
}
