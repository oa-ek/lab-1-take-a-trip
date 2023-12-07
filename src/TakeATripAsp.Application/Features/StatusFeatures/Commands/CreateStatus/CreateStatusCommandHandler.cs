using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TakeTripAsp.Application.Features.StatusFeatures.StatusDtos;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Entity;

namespace TakeTripAsp.Application.Features.StatusFeatures.Commands.CreateStatus
{
    public class CreateStatusCommandHandler
        : IRequestHandler<CreateStatusCommand, CreateStatusDto>
    {
        protected readonly IBaseRepository<Status, int>? _statusRepository;
        protected readonly IMapper _mapper;

        public CreateStatusCommandHandler(
            IBaseRepository<Status, int> statusRepository,
            IMapper mapper)
        {
            (_statusRepository, _mapper) = (statusRepository, mapper);
        }

        public async Task<CreateStatusDto> Handle(
            CreateStatusCommand request,
            CancellationToken cancellationToken)
        {
            var status = await _statusRepository.CreateAsync(
                new Status { StatusName = request.Name });

            return _mapper.Map<Status, CreateStatusDto>(status);
        }
    }
}