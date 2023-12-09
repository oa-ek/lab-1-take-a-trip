using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.BookingFeatures.BookingsDtos
{
    public class ReadBookingsDto
    {
        public int Id { get; set; }

        public bool IsFullPayment { get; set; }

        public decimal Payment { get; set; }

        public string ClientId { get; set; }

        public int TourId { get; set; }

        public int BookingStatusId { get; set; }

    }
}
