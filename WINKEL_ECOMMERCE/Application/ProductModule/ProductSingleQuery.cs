using MediatR;
using Microsoft.EntityFrameworkCore;
using WINKEL_ECOMMERCE.DAL;
using WINKEL_ECOMMERCE.Models;

namespace WINKEL_ECOMMERCE.Application.ProductModule
{
    public class ProductSingleQuery:IRequest<List<Product>>
    {
        public class ProductSingleQueryHandler : IRequestHandler<ProductSingleQuery, List<Product>>
        {
            private readonly WINKEL_ApplicationDbContext _context;
            public ProductSingleQueryHandler(WINKEL_ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<List<Product>> Handle(ProductSingleQuery request, CancellationToken cancellationToken)
            {
                var products = await _context.Products.OrderByDescending(pr => pr.CreatedAt).Take(3).ToListAsync();

                return products;
            }
        }
    }

}
