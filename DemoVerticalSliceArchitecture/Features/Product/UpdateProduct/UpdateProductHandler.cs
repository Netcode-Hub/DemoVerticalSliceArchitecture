using DemoVerticalSliceArchitecture.Infrastructure;
using DemoVerticalSliceArchitecture.Shared;
using Mapster;
using MediatR;
namespace DemoVerticalSliceArchitecture.Features.Product.UpdateProduct
{
    public class UpdateProductHandler(AppDbContext context) :
        IRequestHandler<UpdateProductCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = request.Product.Adapt<Domain.Product>();
            context.Products.Update(product);
            await context.SaveChangesAsync(cancellationToken);
            return new ServiceResponse(true, "Updated");
        }
    }
}
