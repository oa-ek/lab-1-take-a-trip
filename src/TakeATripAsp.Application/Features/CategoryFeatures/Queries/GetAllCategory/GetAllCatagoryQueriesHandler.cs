using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.CategoryFeatures.CategoryDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.CategoryFeatures.Queries.GetAllCategory
{
    public class GetAllCatagoryQueriesHandler
        : IRequestHandler<GetAllCatagoryQueries, IEnumerable<ReadCategoryDto>>
    {
        protected readonly IBaseRepository<Category, int>? _categoryRepository;
        protected readonly IMapper _mapper;

        public GetAllCatagoryQueriesHandler(
            IBaseRepository<Category, int> categoryRepository,
            IMapper mapper)
        {
            (_categoryRepository, _mapper) = (categoryRepository, mapper);
        }

        public async Task<IEnumerable<ReadCategoryDto>> Handle(
            GetAllCatagoryQueries request, 
            CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Category>,
                IEnumerable<ReadCategoryDto>>(await _categoryRepository.GetAllAsync());
        }
    }
}
