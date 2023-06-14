using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WINKEL_ECOMMERCE.DAL;
using WINKEL_ECOMMERCE.Extensions;
using WINKEL_ECOMMERCE.Models;
using static WINKEL_ECOMMERCE.Utilities.Utilities;
namespace WINKEL_ECOMMERCE.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly WINKEL_ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductsController(WINKEL_ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int? page = 1)
        {
            if (page < 1) page = 1;
            ViewData["total_products_count"] = _context.Products.ToList().Count;
            int totalPages = (int)Math.Ceiling(Convert.ToDecimal(ViewData["total_products_count"]) / 3);
            if (page > totalPages) page = totalPages;
            ViewData["active_page"] = page;
            IEnumerable<Product> products = _context.Products.Skip(((int)page - 1) * 3).Take(3).ToList();
            ViewData["active_nav"] = "products";

            return View(products);

            //return Json(products);

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["active_nav"] = "products";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            if(product.DiscountPrice >= product.Price)
            {
                ModelState.AddModelError("DiscountPrice", "DiscountPrice must be less than Price");
            } 
            if (product.Photo is null)
            {
                ModelState.AddModelError("Photo", "Image should be selected");
                return View(product);
            }
            if (!product.Photo.ContentType.Contains(@"image/"))
            {
                ModelState.AddModelError("Photo", "Image is not valid.");
                return View(product);
            }

            string uniqueFileName = Guid.NewGuid().ToString() + product.Photo.FileName;
            string path = _env.WebRootPath + @"\image\" + uniqueFileName;
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                await product.Photo.CopyToAsync(fs);
            }
            product.Image = uniqueFileName;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            ViewData["active_nav"] = "products";

            return View(product);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null & id <= 0) return NotFound();
            Product product = await _context.Products.FindAsync(id);
            if (product is null) return NotFound();
            ViewData["active_nav"] = "products";

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id is null & id <= 0) return NotFound();
            Product product = await _context.Products.FindAsync(id);
            if (product is null) return NotFound();
            if (product.Image is not null) RemoveFile(product.Image, _env);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return NotFound();
            if (id is null & id <= 0) return NotFound();
            Product product = await _context.Products.FindAsync(id);
            if (product is null) return NotFound();
            ViewData["active_nav"] = "products";

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Product product)
        {
            if (!ModelState.IsValid) return NotFound();
            Product productFromDB = await _context.Products.FindAsync(id);
            if (productFromDB is null) return NotFound();
            if (product.DiscountPrice >= product.Price)
            {
                ModelState.AddModelError("DiscountPrice", "DiscountPrice must be less than Price");
            }
            if (product.Photo is not null)
            {
                if (product.Photo.IsImage())
                {
                    if (product.Image is not null) RemoveFile(productFromDB.Image, _env);
                    productFromDB.Image = await product.Photo.SaveFileAsync(_env);
                }
                else
                {
                    ModelState.AddModelError("Photo", "Image is not valid.");
                    return View(product);
                }
            }
            productFromDB.Name = product.Name;
            productFromDB.Price = product.Price;
            productFromDB.HasDiscount = product.HasDiscount;
            productFromDB.DiscountPrice = product.DiscountPrice;
            productFromDB.Rating = product.Rating;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
