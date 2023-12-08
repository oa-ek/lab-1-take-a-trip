using MediatR;
using TakeTripAsp.Application.Features.CategoryFeatures.CategoryDtos;

namespace TakeTripAsp.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommand 
        : IRequest<CreateCategoryDto> 
    {
        public required string Name { get; set; }
    }
}
