using DemoVerticalSliceArchitecture.Features.Product.CreateProduct;
using DemoVerticalSliceArchitecture.Features.Product.DeleteProduct;
using DemoVerticalSliceArchitecture.Features.Product.GetAllProduct;
using DemoVerticalSliceArchitecture.Features.Product.GetProductById;
using DemoVerticalSliceArchitecture.Features.Product.UpdateProduct;
using MediatR;

namespace DemoVerticalSliceArchitecture.Features.Product
{
    public static class ProductEndpoints
    {
        public static IEndpointConventionBuilder MapProductEndpoints
            (this IEndpointRouteBuilder endpoint)
        {
            var productGroup = endpoint.MapGroup("/product");
            productGroup.MapPost("/create", async (CreateProductRequest product, ISender sender) =>
            {
                var response = await sender.Send(new CreateProductCommand(product));
                return response.Success ? Results.Ok(response) : Results.BadRequest(response);
            });
            productGroup.MapPut("/update", async (UpdateProductRequest product, ISender sender) =>
            {
                var response = await sender.Send(new UpdateProductCommand(product));
                return response.Success ? Results.Ok(response) : Results.BadRequest(response);
            });

            productGroup.MapDelete("/delete/{id}", async (int id, ISender sender) =>
            {
                var response = await sender.Send(new DeleteProductCommand(id));
                return response.Success ? Results.Ok(response) : Results.BadRequest(response);
            });
            productGroup.MapGet("/single/{id}", async (int id, ISender sender) =>
            {
                var response = await sender.Send(new GetProductByIdQuery(id));
                return response != null ? Results.Ok(response) : Results.NotFound();
            });
            productGroup.MapGet("/all", async (ISender sender) =>
            {
                var response = await sender.Send(new GetAllProductQuery());
                return response != null ? Results.Ok(response) : Results.NotFound();
            });
            return productGroup;

        }
    }
}
