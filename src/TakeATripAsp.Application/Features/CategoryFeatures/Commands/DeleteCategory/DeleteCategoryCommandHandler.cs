using MediatR;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.CategoryFeatures.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler
        : IRequestHandler<DeleteCategoryCommand, int>
    {
        protected readonly IBaseRepository<Category, int> _categoryRepository;

        public DeleteCategoryCommandHandler(IBaseRepository<Category, int> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(
            DeleteCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(request.Id);

            await _categoryRepository.DeleteAsync(category);

            return category.Id;
        }
    }
}
