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

namespace TakeTripAsp.Application.Features.Tourfeatures.Commands.CreateTour
{
    public class CreateTourCommandHandler : IRequestHandler<CreateTourCommand, CreateTourDto>
    {
        protected readonly IBaseRepository<Tour, int>? _tourRepository;
        protected readonly IMapper _mapper;

        public CreateTourCommandHandler(IBaseRepository<Tour, int> tourRepository, IMapper mapper)
        {
            (_tourRepository, _mapper) = (tourRepository, mapper);
        }

        public async Task<CreateTourDto> Handle(CreateTourCommand request, CancellationToken cancellationToken)
        {
            var tour = await _tourRepository.CreateAsync(new Tour
            {
                Name = request.Name,
                Description = request.Description,
                Continent = request.Continent,
                Start = request.Start,
                End = request.End,
                FullPrice = request.FullPrice,
                BookingPrice = request.BookingPrice,
                StatusId = request.StatusId,
                ManagerId = request.ManagerId,
                CoverPath = request.CoverPath,
                CityId = request.CityId
            });

            return _mapper.Map<Tour, CreateTourDto>(tour);
        }
    }
}
