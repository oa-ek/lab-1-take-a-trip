using MediatR;
using TakeTripAsp.Application.Features.SelectedTourFeatures.SelectedTourDtos;

namespace TakeTripAsp.Application.Features.SelectedTourFeatures.Queries.GetAllSelectedTour
{
    public class GetAllSelectedTourQueries
        : IRequest<IEnumerable<ReadSelectedTourDto>> { }
}

