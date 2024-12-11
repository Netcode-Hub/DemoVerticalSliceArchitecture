using DemoVerticalSliceArchitecture.Infrastructure;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace DemoVerticalSliceArchitecture.Features.Product.GetAllProduct
{
    public class GetAllProductHandler(AppDbContext context)
        : IRequestHandler<GetAllProductQuery, IEnumerable<GetProductResponse>>
    {
        public async Task<IEnumerable<GetProductResponse>> Handle(GetAllProductQuery request, 
            CancellationToken cancellationToken)
        {
            var products = await context.Products
                .Include(c=>c.Category)
                .ToListAsync(cancellationToken: cancellationToken);
            return products.Adapt<IEnumerable<GetProductResponse>>();
        }
    }
}
