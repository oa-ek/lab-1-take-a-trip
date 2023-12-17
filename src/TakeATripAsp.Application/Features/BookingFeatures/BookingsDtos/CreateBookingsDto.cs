
namespace TakeTripAsp.Application.Features.BookingFeatures.BookingsDtos
{
    public class CreateBookingsDto
    {
        public bool IsFullPayment { get; set; }

        public int TourId { get; set; }

        public string TourName { get; set; }
    }
}
