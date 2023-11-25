using MediatR;
using TakeTripAsp.Application.Features.CategoryFeatures.CategoryDtos;

namespace TakeTripAsp.Application.Features.CategoryFeatures.Queries.GetAllCategory
{
    public class GetAllCatagoryQueries
        : IRequest<IEnumerable<ReadCategoryDto>> { }
}
