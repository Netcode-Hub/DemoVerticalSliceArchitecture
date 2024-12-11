using DemoVerticalSliceArchitecture.Infrastructure;
using DemoVerticalSliceArchitecture.Shared;
using Mapster;
using MediatR;

namespace DemoVerticalSliceArchitecture.Features.Category.CreateCategory
{
    public class CreateCategoryRequest
    {
        public string? Name { get; set; }
    }

    public record CreateCategoryCommand(CreateCategoryRequest Category) :
        IRequest<ServiceResponse>
    { }

    public class CreateCategoryHandler(AppDbContext context)
        : IRequestHandler<CreateCategoryCommand, ServiceResponse>
    {
        public async Task<ServiceResponse> Handle(CreateCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = request.Category.Adapt<Domain.Category>();
            context.Categories.Add(category);
            await context.SaveChangesAsync(cancellationToken);
            return new ServiceResponse(true, "Saved");
        }
    }
}
