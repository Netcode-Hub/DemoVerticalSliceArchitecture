using DemoVerticalSliceArchitecture.Shared;
using MediatR;

namespace DemoVerticalSliceArchitecture.Features.Product.CreateProduct
{
    public record CreateProductCommand(CreateProductRequest Product)
        : IRequest<ServiceResponse>
    {
    }
}
