using DemoVerticalSliceArchitecture.Shared;
using MediatR;

namespace DemoVerticalSliceArchitecture.Features.Product.UpdateProduct
{
    public record UpdateProductCommand(UpdateProductRequest Product)
        :IRequest<ServiceResponse>
    {
    }
}
