using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.CategoryFeatures.CategoryDtos;

namespace TakeTripAsp.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommand 
        : IRequest<CreateCategoryDto> 
    {
        public required string Name { get; set; }
    }
}
