using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeTripAsp.Application.Features.TourFeatures.Commands.DeleteTour
{
    public class DeleteTourCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
