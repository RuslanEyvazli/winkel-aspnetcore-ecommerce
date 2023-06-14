using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WINKEL_ECOMMERCE.DAL;
using WINKEL_ECOMMERCE.Models;
using WINKEL_ECOMMERCE.ViewModels;

namespace WINKEL_ECOMMERCE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WINKEL_ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, WINKEL_ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _context.Sliders.ToListAsync();
            Ship ship = await _context.Ships.Include(nav => nav.ShipItems).FirstAsync();
            IEnumerable<Product> products = await _context.Products.ToListAsync();
            Summer summer = await _context.Summers.FirstAsync();
            IEnumerable<Static> statics = await _context.Statics.ToListAsync();
            IEnumerable<SatisfiedCustomer> satisfiedCustomers = await _context.SatisfiedCustomers.ToListAsync();
            HomeIndexVM homeIndexVM = new HomeIndexVM()
            {
                Sliders = sliders,
                Ship = ship,
                Products = products,
                Summer = summer,
                Static = statics,
                SatisfiedCustomers = satisfiedCustomers
            };
            return View(homeIndexVM);
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            TempData["m"] = "sdfsd";
            int? count = HttpContext.Session.GetInt32("Count");
            if (count is not null) 
            { 
                count++; 
            } 
            else 
            { 
                count = 1; 
            }
            HttpContext.Session.SetInt32("Count", (int)count);
            return View(count);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}