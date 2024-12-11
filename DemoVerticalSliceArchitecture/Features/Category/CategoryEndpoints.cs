using DemoVerticalSliceArchitecture.Features.Category.CreateCategory;
using DemoVerticalSliceArchitecture.Features.Product.CreateProduct;
using MediatR;

namespace DemoVerticalSliceArchitecture.Features.Category
{
    public static class CategoryEndpoints
    {
        public static IEndpointConventionBuilder MapCategoryEndpoints
            (this IEndpointRouteBuilder endpoint)
        {
            var categoryGroup = endpoint.MapGroup("/category");
            categoryGroup.MapPost("/create", async (CreateCategoryRequest category, ISender sender) =>
            {
                var response = await sender.Send(new CreateCategoryCommand(category));
                return response.Success ? Results.Ok(response) : Results.BadRequest(response);
            });
            return categoryGroup;
        }
    }
}
