using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilliconPower.Backend.Application.Common.Interfaces;
using SilliconPower.Backend.Application.Entities;
using SilliconPower.Backend.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPower.Backend.Application.Activities.Queries.GetActivities
{
    public class FilterActivitiesQuery : IRequest<ActivitiesVm>
    {
        public string ReferencePoint { get; set; }
        public double Distance { get; set; }
        public int CategoryId { get; set; }
    }

    public class FilterActivitiesQueryHandler : IRequestHandler<FilterActivitiesQuery, ActivitiesVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FilterActivitiesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActivitiesVm> Handle(FilterActivitiesQuery request, CancellationToken cancellationToken)
        {
            Coordinate rp = (Coordinate)request.ReferencePoint;
            return new ActivitiesVm
            {
                Lists =  _context.Activities
                    .Include(a=> a.Location)
                    .Include(a => a.Category)
                    .AsEnumerable()
                    .Where(a => a.Location.Coordinate.GetDistanceFrom(rp) < request.Distance)
                    .Where(a=> a.CategoryId.Equals(request.CategoryId))
                    .Select(a=> _mapper.Map<ActivityDto>(a))
                    .OrderBy(activity => activity.Name).ToList()
            };
        }
    }
}
