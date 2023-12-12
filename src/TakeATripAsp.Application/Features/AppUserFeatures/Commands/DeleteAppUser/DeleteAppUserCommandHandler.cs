using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.AppUserFeatures.Commands.DeleteAppUser
{
    public class DeleteAppUserCommandHandler : IRequestHandler<DeleteAppUserCommand, string>
    {
        private readonly IUserRepository _appUserRepository;

        public DeleteAppUserCommandHandler(IUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<string> Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _appUserRepository.GetAsync(request.Id);

            await _appUserRepository.DeleteAsync(appUser.Id);

            return appUser.Id;
        }
    }
}
