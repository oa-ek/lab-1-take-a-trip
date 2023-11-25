using Microsoft.EntityFrameworkCore;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Domain.Configuration
{
    public class StatusBookingConfiguration : IEntityTypeConfiguration<BookingStatus>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BookingStatus> builder)
        {
            builder.HasData
                (
                    new BookingStatus
                    {
                        Id = 1,
                        BookingStatusName = "Не заброньовано",
                    },
                    new BookingStatus
                    {
                        Id = 2,
                        BookingStatusName = "Заброньовано",
                    },
                    new BookingStatus
                    {
                        Id = 3,
                        BookingStatusName = "Оплачено",
                    },
                    new BookingStatus
                    {
                        Id = 4,
                        BookingStatusName = "Скасовано",
                    }
                );

        }
    }
}
