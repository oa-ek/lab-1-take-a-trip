using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.Tourfeatures.Commands.DeleteTour
{
    public class DeleteTourCommandHandler : IRequestHandler<DeleteTourCommand, int>
    {
        protected readonly IBaseRepository<Tour, int> _tourRepository;

        public DeleteTourCommandHandler(IBaseRepository<Tour, int> tourRepository)
        {
            _tourRepository = tourRepository;
        }

        public async Task<int> Handle(DeleteTourCommand request, CancellationToken cancellationToken)
        {
            var tour = await _tourRepository.GetAsync(request.Id);

            await _tourRepository.DeleteAsync(tour);

            return tour.Id;
        }
    }
}
