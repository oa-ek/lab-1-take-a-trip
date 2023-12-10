using MediatR;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.CountryFeatures.Commands.DeleteCountry
{
    public class DeleteCountryCommandHandler
    : IRequestHandler<DeleteCountryCommand, int>
    {
        protected readonly IBaseRepository<Country, int> _countryRepository;

        public DeleteCountryCommandHandler(IBaseRepository<Country, int> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<int> Handle(
            DeleteCountryCommand request,
            CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetAsync(request.Id);

            await _countryRepository.DeleteAsync(country);

            return country.Id;
        }
    }
}

