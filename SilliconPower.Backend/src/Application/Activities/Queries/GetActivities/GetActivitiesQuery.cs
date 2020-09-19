using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilliconPower.Backend.Application.Common.Interfaces;
using SilliconPower.Backend.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPower.Backend.Application.Activities.Queries.GetActivities
{
    public class GetActivitiesQuery : IRequest<ActivitiesVm>
    {
    }

    public class GetActivitiesQueryHandler : IRequestHandler<GetActivitiesQuery, ActivitiesVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetActivitiesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActivitiesVm> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
        {
            return new ActivitiesVm
            {
                Lists = await _context.Activities.AsNoTracking()
                    .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider)
                    .OrderBy(activity => activity.Name)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
