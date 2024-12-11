using MediatR;

namespace DemoVerticalSliceArchitecture.Features.Product.GetAllProduct
{
    public record GetAllProductQuery : IRequest<IEnumerable<GetProductResponse>>
    {
    }
}
