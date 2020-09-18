using AutoMapper;
using MediatR;
using SilliconPower.Backend.Application.Common.Exceptions;
using SilliconPower.Backend.Application.Common.Interfaces;
using SilliconPower.Backend.Application.Entities;
using SilliconPower.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPower.Backend.Application.Activities.Queries.GetActivity
{
    public class GetActivityQuery : IRequest<ActivityDetailDto>
    {
        public int Id { get; set; }
    }

    public class GetActivityQueryHandler : IRequestHandler<GetActivityQuery, ActivityDetailDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetActivityQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActivityDetailDto> Handle(GetActivityQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Activities.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Activity), request.Id);
            }

            return _mapper.Map<ActivityDetailDto>(entity); ;
        }
    }
}
