using System.ComponentModel.DataAnnotations.Schema;
using TakeTripAsp.Domain.Common;

namespace TakeTripAsp.Domain.Entity
{
    public class Bookings : BaseEntity<int>
    {
        public bool IsFullPayment { get; set; }

        public decimal Payment { get; set; }

        public virtual AppUser? Client { get; set; }

        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public int TourId { get; set; }

        public virtual Tour? Tour { get; set; }

        public int BookingStatusId { get; set; }

        public virtual BookingStatus? BookingStatus { get; set; }
    }
}
