using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.BookingFeatures.BookingsDtos;

namespace TakeTripAsp.Application.Features.BookingFeatures.Commands.CreateBookings
{
    public class CreateBookingsCommand 
        : IRequest<CreateBookingsDto>
    {
        public bool IsFullPayment { get; set; }

        public string ClientId { get; set; }

        public int TourId { get; set; }
    }
}
