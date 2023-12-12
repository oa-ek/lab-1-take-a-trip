using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.AppUserFeatures.Commands.CreateAppUser
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, CreateAppUserDto>
    {
        private readonly IUserRepository _appUserRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public CreateAppUserCommandHandler(
            IUserRepository appUserRepository,
            UserManager<AppUser> userManager,
            IMapper mapper)
        {
            (_appUserRepository, _userManager, _mapper) = (appUserRepository, userManager, mapper);
        }

        public async Task<CreateAppUserDto> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new AppUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                CoverPath = request.CoverPath,
            };

            _userManager.CreateAsync(newUser, request.Password);

            return _mapper.Map<AppUser, CreateAppUserDto>(newUser);

        }
    }
}