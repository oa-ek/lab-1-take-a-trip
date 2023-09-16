using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeTripAsp.Core.Entity
{
    public class Bookings : BaseEntity
    {
        public bool IsFullPayment { get; set; }

        public int UserId { get; set; }

        public AppUser? User { get; set; }

        public int TourId { get; set; }

        public Tour? Tour { get; set; }

        public int BookingStatusId { get; set; }

        public BookingStatus? BookingStatus { get; set; }
    }
}
