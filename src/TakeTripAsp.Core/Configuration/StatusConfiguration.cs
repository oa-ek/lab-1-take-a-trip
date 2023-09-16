using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TakeTripAsp.Core.Entity;

namespace TakeTripAsp.Core.Configuration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasData
            (
                new Status
                {
                    Id = 1,
                    StatusName = "Активний",
                },
                new Status
                {
                    Id = 2,
                    StatusName = "Перенесений",
                },
                new Status
                {
                    Id = 3,
                    StatusName = "Скасований",
                }
            );
        }
    }
}
