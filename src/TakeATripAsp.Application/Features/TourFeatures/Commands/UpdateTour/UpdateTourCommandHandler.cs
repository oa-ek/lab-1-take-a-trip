using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.Tourfeatures.TourDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.Tourfeatures.Commands.UpdateTour
{
    public class UpdateTourCommandHandler : IRequestHandler<UpdateTourCommand, ReadTourDto>
    {
        protected readonly IBaseRepository<Category, int>? _categoryRepository;
        protected readonly IBaseRepository<Tour, int>? _tourRepository;
        protected readonly IMapper _mapper;

        public UpdateTourCommandHandler(
            IBaseRepository<Category, int> categoryRepository,
            IBaseRepository<Tour, int> tourRepository,
            IBaseRepository<Status, int> statusRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _tourRepository = tourRepository;
            _mapper = mapper;
        }

        public async Task<ReadTourDto> Handle(UpdateTourCommand request, CancellationToken cancellationToken)
        {
            var tour = await _tourRepository.GetAsync(request.Id);

            tour.Name = request.Name;
            tour.Description = request.Description;
            tour.Continent = request.Continent;
            tour.Start = request.Start;
            tour.End = request.End;
            tour.FullPrice = request.FullPrice;
            tour.BookingPrice = request.BookingPrice;
            tour.StatusId = request.StatusId;
            tour.CityId = request.CityId;

            string fileName = Path.GetFileNameWithoutExtension(request.CoverFile.FileName);

            string extension = Path.GetExtension(request.CoverFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            tour.CoverPath = "/img/tour/" + fileName;
            string path = Path.Combine(request.wwwRootPath + "/img/tour/", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                request.CoverFile.CopyTo(fileStream);
            }

            List<Category> categories = new List<Category>();

            foreach (var categoryId in request.CategoryIds)
            {
                categories.Add(await _categoryRepository.GetAsync(categoryId));
            }

            tour.Categories = categories;

            await _tourRepository.UpdateAsync(tour);

            return _mapper.Map<Tour, ReadTourDto>(tour);
        }
    }
}