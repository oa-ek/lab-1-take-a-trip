using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.AppUserFeatures.Commands.CreateAppUser
{
    public class CreateAppUserCommandHandler
        : IRequestHandler<CreateAppUserCommand, CreateAppUserDto>
    {
        private readonly IUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public CreateAppUserCommandHandler(
            IUserRepository appUserRepository,
            IMapper mapper)
        {
            (_appUserRepository, _mapper) = (appUserRepository, mapper);
        }

        public async Task<CreateAppUserDto> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new AppUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
                NormalizedUserName = request.Email.ToLower(),
                EmailConfirmed = true,
                PasswordHash = request.Password,
            };

            string fileName = Path.GetFileNameWithoutExtension(request.CoverFile.FileName);

            string extension = Path.GetExtension(request.CoverFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            newUser.CoverPath = "/img/user/" + fileName;
            string path = Path.Combine(request.wwwRootPath + "/img/user/", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
                request.CoverFile.CopyTo(fileStream);

            await _appUserRepository.CreateAsync(newUser, request.Role);

            return _mapper.Map<AppUser, CreateAppUserDto>(newUser);

        }
    }
}