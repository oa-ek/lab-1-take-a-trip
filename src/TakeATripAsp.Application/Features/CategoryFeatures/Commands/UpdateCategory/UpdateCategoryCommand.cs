using MediatR;
using TakeTripAsp.Application.Features.CategoryFeatures.CategoryDtos;

namespace TakeTripAsp.Application.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryCommand
        : IRequest<ReadCategoryDto>
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}
