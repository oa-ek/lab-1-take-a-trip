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

namespace TakeTripAsp.Application.Features.Tourfeatures.Commands.UpdateTour
{
    public class UpdateTourCommandHandler : IRequestHandler<UpdateTourCommand, ReadTourDto>
    {
        protected readonly IBaseRepository<Tour, int> _tourRepository;
        protected readonly IMapper _mapper;

        public UpdateTourCommandHandler(IBaseRepository<Tour, int> tourRepository, IMapper mapper)
        {
            (_tourRepository, _mapper) = (tourRepository, mapper);
        }

        public async Task<ReadTourDto> Handle(UpdateTourCommand request, CancellationToken cancellationToken)
        {
            var tour = await _tourRepository.GetAsync(request.Id);

            tour.Name = request.Name;
            tour.Description = request.Description;
            tour.Continent = request.Continent;
            tour.Start = request.Start;
            tour.End = request.End;
            tour.FullPrice = request.FullPrice;
            tour.BookingPrice = request.BookingPrice;
            tour.StatusId = request.StatusId;
            tour.ManagerId = request.ManagerId;
            tour.CoverPath = request.CoverPath;
            tour.CityId = request.CityId;

            await _tourRepository.UpdateAsync(tour);

            return _mapper.Map<Tour, ReadTourDto>(tour);
        }
    }
}
