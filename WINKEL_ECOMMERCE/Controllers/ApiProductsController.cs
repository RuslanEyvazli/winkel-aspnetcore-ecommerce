using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WINKEL_ECOMMERCE.DAL;
using WINKEL_ECOMMERCE.Extensions;
using WINKEL_ECOMMERCE.Models;
using static WINKEL_ECOMMERCE.Utilities.Utilities;

namespace WINKEL_ECOMMERCE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProductsController : ControllerBase
    {
        private readonly WINKEL_ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ApiProductsController(WINKEL_ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> Get()
        {
            var products = _context.Products.ToList();
            for (int i = 0; i < products.Count; i++)
            {
                products[i].Image = Path.Combine(_env.WebRootPath, "image", products[i].Image);
            }
            return products;
        }
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product is null) return NotFound();
            product.Image = GetAbsolutePath(_env, product.Image);
            return product;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product) 
        {
            //if (!ModelState.IsValid) return BadRequest();
            //if (product.Photo != null) return BadRequest("Image is not valid");
            //if (!product.Photo.IsImage()) return BadRequest("Image is not valid");

            //product.Image = await product.Photo.SaveFileAsync(_env);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Put([FromRoute]int id, [FromQuery]Product product)
        {
            Product productFromDb = await _context.Products.FindAsync(id);

            if (productFromDb == null) return NotFound();

            productFromDb.Name = product.Name;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
