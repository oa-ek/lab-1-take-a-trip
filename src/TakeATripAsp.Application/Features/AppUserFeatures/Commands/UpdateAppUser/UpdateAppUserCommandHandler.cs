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
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand, ReadAppUserDto>
    {
        private readonly IUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public UpdateAppUserCommandHandler(
            IUserRepository appUserRepository,
            IMapper mapper)
        {
            (_appUserRepository, _mapper) = (appUserRepository, mapper);
        }

        public async Task<ReadAppUserDto> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _appUserRepository.GetAsync(request.Id);

            //appUser.FirstName = request.FirstName;
            //appUser.LastName = request.LastName;
            //appUser.Email = request.Email;
            //appUser.Password = request.Password;
            //appUser.CoverPath = request.CoverPath;
            //appUser.Role = request.Role;

            //await _appUserRepository.UpdateAsync(appUser);

            //return _mapper.Map<AppUser, ReadAppUserDto>(appUser);
            return  _mapper.Map<ReadAppUserDto>(appUser);
        }
    }
}
