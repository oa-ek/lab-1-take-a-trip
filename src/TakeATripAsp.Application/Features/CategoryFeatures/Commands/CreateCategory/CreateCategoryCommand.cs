using MediatR;
using Microsoft.AspNetCore.Http;
using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;
using TakeTripAsp.Application.Features.CategoryFeatures.CategoryDtos;

namespace TakeTripAsp.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommand
       : IRequest<CreateCategoryDto>
    {
        public required string Name { get; set; }
    }
}
