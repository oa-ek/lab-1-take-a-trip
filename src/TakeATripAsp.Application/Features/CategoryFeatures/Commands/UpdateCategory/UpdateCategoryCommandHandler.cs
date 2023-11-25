using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.CategoryFeatures.CategoryDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler
        : IRequestHandler<UpdateCategoryCommand, ReadCategoryDto>
    {
        protected readonly IBaseRepository<Category, int> _categoryRepository;
        protected readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(
            IBaseRepository<Category, int> categoryRepository,
            IMapper mapper)
        {
            (_categoryRepository, _mapper) = (categoryRepository, mapper);
        }

        public async Task<ReadCategoryDto> Handle(
            UpdateCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(request.Id);

            category.Name = request.Name;

            await _categoryRepository.UpdateAsync(category);

            return _mapper.Map<Category, ReadCategoryDto>(category);
        }
    }
}
