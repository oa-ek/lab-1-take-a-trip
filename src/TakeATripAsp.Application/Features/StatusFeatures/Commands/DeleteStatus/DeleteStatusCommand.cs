using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeTripAsp.Application.Features.StatusFeatures.Commands.DeleteStatus
{
    public class DeleteStatusCommand
         : IRequest<int>
    {
        public int Id { get; set; }
    }
}
