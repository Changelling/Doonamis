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

namespace SilliconPower.Backend.Application.Users.Queries.GetBookings
{
    public class GetBookingsQuery : IRequest<BookingsVm>
    {
    }

    public class GetBookingsQueryHandler : IRequestHandler<GetBookingsQuery, BookingsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetBookingsQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<BookingsVm> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            var bookings = _context.Bookings.Where(b => b.UserId.Equals(_currentUserService.UserId));
            return new BookingsVm
            {
                Lists = await bookings
                    .ProjectTo<BookingDto>(_mapper.ConfigurationProvider)
                    .OrderBy(b => b.Date)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
