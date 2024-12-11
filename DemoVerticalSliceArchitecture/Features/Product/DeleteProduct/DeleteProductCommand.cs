using DemoVerticalSliceArchitecture.Shared;
using MediatR;

namespace DemoVerticalSliceArchitecture.Features.Product.DeleteProduct
{
    public record DeleteProductCommand(int Id) : IRequest<ServiceResponse>
    {
    }
}
