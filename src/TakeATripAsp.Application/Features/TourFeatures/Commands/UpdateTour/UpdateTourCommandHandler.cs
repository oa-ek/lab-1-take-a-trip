using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.TourFeatures.TourDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.TourFeatures.Commands.UpdateTour
{
    public class UpdateTourCommandHandler : IRequestHandler<UpdateTourCommand, UpdateTourDto>
    {
        protected readonly IBaseRepository<Category, int>? _categoryRepository;
        protected readonly IBaseRepository<City, int>? _cityRepository;
        protected readonly IBaseRepository<Tour, int>? _tourRepository;
        protected readonly IMapper _mapper;

        public UpdateTourCommandHandler(
            IBaseRepository<Category, int> categoryRepository,
            IBaseRepository<Tour, int> tourRepository,
            IBaseRepository<Status, int> statusRepository,
            IBaseRepository<City, int> cityRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _tourRepository = tourRepository;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<UpdateTourDto> Handle(UpdateTourCommand request, CancellationToken cancellationToken)
        {
            var tour = await _tourRepository.GetAsync(request.Id);

            tour.Cities.Clear();
            tour.Categories.Clear();

            tour.Name = request.Name;
            tour.Description = request.Description;
            tour.Start = request.Start;
            tour.End = request.End;
            tour.FullPrice = request.FullPrice;
            tour.BookingPrice = request.BookingPrice;
            tour.StatusId = request.StatusId;


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

            List<City> cities = new List<City>();

            foreach (var cityId in request.CityIds)
            {
                cities.Add(await _cityRepository.GetAsync(cityId));
            }

            tour.Categories = categories;
            tour.Cities = cities;

            await _tourRepository.UpdateAsync(tour);

            return _mapper.Map<Tour, UpdateTourDto>(tour);
        }
    }
}