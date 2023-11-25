using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.CategoryFeatures.CategoryDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler
        : IRequestHandler<CreateCategoryCommand, CreateCategoryDto>
    {
        protected readonly IBaseRepository<Category, int>? _categoryRepository;
        protected readonly IMapper _mapper;

        public CreateCategoryCommandHandler(
            IBaseRepository<Category, int> categoryRepository,
            IMapper mapper)
        {
            (_categoryRepository, _mapper) = (categoryRepository, mapper);
        }

        public async Task<CreateCategoryDto> Handle(
            CreateCategoryCommand request, 
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.CreateAsync(
                new Category { Name = request.Name});

            return _mapper.Map<Category, CreateCategoryDto>(category);
        }
    }
}
