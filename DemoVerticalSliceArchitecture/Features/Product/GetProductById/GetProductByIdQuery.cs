using MediatR;

namespace DemoVerticalSliceArchitecture.Features.Product.GetProductById
{
    public record GetProductByIdQuery(int Id):IRequest<GetProductResponse>
    {
    }
}
