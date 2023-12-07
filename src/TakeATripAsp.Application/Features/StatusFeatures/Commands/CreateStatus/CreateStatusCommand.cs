using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Application.Features.CategoryFeatures.CategoryDtos;
using TakeTripAsp.Application.Features.StatusFeatures.StatusDtos;

namespace TakeTripAsp.Application.Features.StatusFeatures.Commands.CreateStatus
{
    public class CreateStatusCommand
        : IRequest<CreateStatusDto>
    {
        public required string Name { get; set; }
    }
}