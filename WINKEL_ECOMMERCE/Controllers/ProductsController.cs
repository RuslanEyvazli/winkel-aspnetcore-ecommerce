using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WINKEL_ECOMMERCE.Application.ProductModule;
using WINKEL_ECOMMERCE.DAL;
using WINKEL_ECOMMERCE.Models;

namespace WINKEL_ECOMMERCE.Controllers
{
    public class ProductsController : Controller
    {
        private readonly WINKEL_ApplicationDbContext _context;
        private readonly IMediator _mediator;
        public ProductsController(WINKEL_ApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        //[Authorize]
        public async Task<IActionResult> Index()
        {
            ProductSingleQuery query = new ProductSingleQuery(); 
            List<Product> products = await _mediator.Send(query);
            // var products = _context.Products.OrderByDescending(pr => pr.CreatedAt).Take(3);
            ViewData["total_products"] = _context.Products.Count();
            return View(products);
        }
    }
}
