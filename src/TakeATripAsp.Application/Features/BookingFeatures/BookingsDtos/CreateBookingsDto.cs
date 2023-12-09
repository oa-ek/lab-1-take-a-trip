using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeTripAsp.Application.Features.BookingFeatures.BookingsDtos
{
    public class CreateBookingsDto
    {
        public bool IsFullPayment { get; set; }

        public decimal Payment { get; set; }

        public string ClientId { get; set; }

        public int TourId { get; set; }

        public int BookingStatusId { get; set; }
    }
}
