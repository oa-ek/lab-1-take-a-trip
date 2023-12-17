using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.AppUserFeatures.Commands.UpdateAppUser
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand, string>
    {
        private readonly IUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public UpdateAppUserCommandHandler(
            IUserRepository appUserRepository,
            IMapper mapper)
        {
            (_appUserRepository, _mapper) = (appUserRepository, mapper);
        }

        public async Task<string> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _appUserRepository.GetAsync(request.Id);

            appUser.FirstName = request.FirstName;
            appUser.LastName = request.LastName;
            appUser.Email = request.Email;

            await _appUserRepository.UpdateAsync(appUser, request.Role);

            return appUser.Id;
        }
    }
}
