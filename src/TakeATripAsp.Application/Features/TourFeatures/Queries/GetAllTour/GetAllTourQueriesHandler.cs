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

namespace TakeTripAsp.Application.Features.Tourfeatures.Queries.GetAllTour
{
    public class GetAllTourQueriesHandler 
        : IRequestHandler<GetAllTourQueries, IEnumerable<ReadTourDto>>
    {
        protected readonly IBaseRepository<Tour, int> _tourRepository;
        protected readonly IMapper _mapper;

        public GetAllTourQueriesHandler(IBaseRepository<Tour, int> tourRepository, IMapper mapper)
        {
            (_tourRepository, _mapper) = (tourRepository, mapper);
        }

        public async Task<IEnumerable<ReadTourDto>> Handle(
            GetAllTourQueries request, 
            CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Tour>, IEnumerable<ReadTourDto>>(await _tourRepository.GetAllAsync());
        }
    }
}
