using MediatR;

namespace TakeTripAsp.Application.Features.CountryFeatures.Commands.DeleteCountry
{
    public class DeleteCountryCommand
    : IRequest<int>
    {
        public int Id { get; set; }
    }
}
