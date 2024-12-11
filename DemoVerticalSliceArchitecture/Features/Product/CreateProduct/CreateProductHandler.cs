using DemoVerticalSliceArchitecture.Infrastructure;
using DemoVerticalSliceArchitecture.Shared;
using Mapster;
using MediatR;

namespace DemoVerticalSliceArchitecture.Features.Product.CreateProduct
{
    public class CreateProductHandler(AppDbContext context)
        : IRequestHandler<CreateProductCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = request.Product.Adapt<Domain.Product>();
            context.Products.Add(product);
            await context.SaveChangesAsync(cancellationToken);
            return new ServiceResponse(true, "Saved");
        }
    }
}
