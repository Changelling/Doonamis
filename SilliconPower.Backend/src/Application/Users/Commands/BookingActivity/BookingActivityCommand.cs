using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using SilliconPower.Backend.Application.Common.Exceptions;
using SilliconPower.Backend.Application.Common.Interfaces;
using SilliconPower.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPower.Backend.Application.Users.Commands.BookingActivity
{
    public class BookingActivityCommand : IRequest<int>
    {
        public DateTime Date { get; set; }

        public int ActivityId { get; set; }
    }

    public class BookingActivityCommandHandler : IRequestHandler<BookingActivityCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public BookingActivityCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(BookingActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities.FindAsync(request.ActivityId);

            if (activity == null || !activity.Availabilities.Any(date => date.Equals(request.Date)))
            {
                throw new NotFoundException(nameof(Activity), request.ActivityId);
            }

            var entity = new Booking
            {
                Date = request.Date,
                ActivityId = request.ActivityId,
                UserId = _currentUserService.UserId
            };

            _context.Bookings.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
