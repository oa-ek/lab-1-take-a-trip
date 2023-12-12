using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.Tourfeatures.TourDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.TourFeatures.Queries.GetTour
{
    public class GetTourQueriesHandler
       : IRequestHandler<GetTourQueries, ReadTourDto>
    {
        protected readonly IBaseRepository<Tour, int>? _tourRepository;
        protected readonly IMapper _mapper;
        public GetTourQueriesHandler(
            IBaseRepository<Tour, int>? tourRepository,
            IMapper mapper)
        {
            _tourRepository = tourRepository;
            _mapper = mapper;
        }

        public async Task<ReadTourDto> Handle(GetTourQueries request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Tour, ReadTourDto>(await _tourRepository.GetAsync(request.Id));
        }
    }
}
