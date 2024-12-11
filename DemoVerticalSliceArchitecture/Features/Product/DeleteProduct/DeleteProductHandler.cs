using DemoVerticalSliceArchitecture.Infrastructure;
using DemoVerticalSliceArchitecture.Shared;
using MediatR;

namespace DemoVerticalSliceArchitecture.Features.Product.DeleteProduct
{
    public class DeleteProductHandler(AppDbContext context)
        : IRequestHandler<DeleteProductCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(DeleteProductCommand request, 
            CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(request.Id);
            context.Products.Remove(product!);
            await context.SaveChangesAsync(cancellationToken);
            return new ServiceResponse(true, "Deleted");
        }
    }
}
