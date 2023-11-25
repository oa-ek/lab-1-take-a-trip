using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Domain.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Екстримальний відпочинок"
                },
                new Category
                {
                    Id = 2,
                    Name = "Активний"
                },
                new Category
                {
                    Id = 3,
                    Name = "Пасивний"
                },
                new Category
                {
                    Id = 4,
                    Name = "Спортивний"
                },
                new Category
                {
                    Id = 5,
                    Name = "Пляжний"
                },
                new Category
                {
                    Id = 6,
                    Name = "Гірський"
                },
                new Category
                {
                    Id = 7,
                    Name = "Шопінг"
                },
                new Category
                {
                    Id = 8,
                    Name = "Лікувально-оздоровчий"
                },
                new Category
                {
                    Id = 9,
                    Name = "Гастрономічний"
                },
                new Category
                {
                    Id = 10,
                    Name = "Зелений"
                }
                );
        }
    }
}
