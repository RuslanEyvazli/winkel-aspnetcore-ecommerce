using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WINKEL_ECOMMERCE.DAL;
using WINKEL_ECOMMERCE.Models;

namespace WINKEL_ECOMMERCE.Controllers
{
#nullable disable
    public class CardController : Controller
    {
        private readonly WINKEL_ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public CardController(WINKEL_ApplicationDbContext context, UserManager<AppUser> _userManager)
        {
            _context = context;
        }
        public async Task<IActionResult> Add(int? id)
        {
            if (id == null || id <= 0) return NotFound();
            Product product = await _context.Products.FindAsync(id);
            BasketProduct basketProduct = product;
            //AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            //basketProduct.AppUserId = user.Id;
            if (product == null) return NotFound();

            string card = HttpContext.Session.GetString("card");

            List<BasketProduct> products = new List<BasketProduct>();
            if(card is not null) 
            {
                products = JsonConvert.DeserializeObject<List<BasketProduct>>(card);
            }
            var pr = products.FirstOrDefault(pr => pr.Id == id);
            if (pr != null)
            {
                pr.Quantity++;
            }
            else
            {
                products.Add(basketProduct);
            }
            string productsJSON = JsonConvert.SerializeObject(products);
            HttpContext.Session.SetString("card", productsJSON);
            //return RedirectToAction("Index","Home");

            return Ok(new {
                status = 200,
                data = products.Sum(p => p.Quantity),
                message = "Product was added"
            });
        }
        public IActionResult Index()
        {
            string card = HttpContext.Session.GetString("card");
            List<BasketProduct> products = new List<BasketProduct>(); //{ new Product {Id = 12 ,Name = "Default Picture",Price = 9.99M, Image = "about-1.jpg" } };
            if(card != null)
            {
                products = JsonConvert.DeserializeObject<List<BasketProduct>>(card);
            }
            return View(products);
        }
        public  IActionResult Remove(int? id)
        {
            if (id == null || id <= 0) return NotFound();

            string card = HttpContext.Session.GetString("card");
            if (card is null) return NotFound();
            List<BasketProduct> products = JsonConvert.DeserializeObject<List<BasketProduct>>(card);
            BasketProduct product = products.Find(pr=> pr.Id == id);
            if (product == null) return NotFound();


            products.Remove(product);
            string productsJSON = JsonConvert.SerializeObject(products);
            HttpContext.Session.SetString("card", productsJSON);

            return Ok(new {
                status = 200,
                data = products.Sum(p => p.Quantity),
                message = "Product was successfully removed from Cart"
            });
        }
    }
}
