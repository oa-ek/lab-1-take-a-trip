using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.Tourfeatures.TourDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.Tourfeatures.Commands.CreateTour
{
    public class CreateTourCommandHandler : IRequestHandler<CreateTourCommand, CreateTourDto>
    {
        protected readonly IBaseRepository<Category, int>? _categoryRepository;
        protected readonly IBaseRepository<City, int>? _cityRepository;
        protected readonly IBaseRepository<Tour, int>? _tourRepository;
        protected readonly IBaseRepository<Status, int>? _statusRepository;
        protected readonly IMapper _mapper;

        public CreateTourCommandHandler(
            IBaseRepository<Category, int> categoryRepository,
            IBaseRepository<Tour, int> tourRepository,
            IBaseRepository<Status, int> statusRepository,
            IBaseRepository<City, int> cityRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _tourRepository = tourRepository;
            _statusRepository = statusRepository;
            _cityRepository = cityRepository;   
            _mapper = mapper;
        }

        public async Task<CreateTourDto> Handle(CreateTourCommand request, CancellationToken cancellationToken)
        {
            var tour = new Tour
            {
                Name = request.Name,
                Description = request.Description,
                Continent = request.Continent,
                Start = request.Start,
                End = request.End,
                FullPrice = request.FullPrice,
                BookingPrice = request.BookingPrice,
                ManagerId = request.ManagerId,
            };

            var status = await _statusRepository.GetAllAsync();

            tour.StatusId = status.FirstOrDefault(x => x.StatusName == "Активний").Id;

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

            await _tourRepository.CreateAsync(tour);

            return _mapper.Map<Tour, CreateTourDto>(tour);
        }
    }
}
