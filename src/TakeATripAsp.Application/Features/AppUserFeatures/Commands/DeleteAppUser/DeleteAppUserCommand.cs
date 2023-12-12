using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeTripAsp.Application.Features.AppUserFeatures.Commands.DeleteAppUser
{
    public class DeleteAppUserCommand : IRequest<string>
    {
        public string Id { get; set; }
    }
}
