using MediatR;
using SilliconPower.Backend.Application.Common.Exceptions;
using SilliconPower.Backend.Application.Common.Interfaces;
using SilliconPower.Backend.Domain.Entities;
using SilliconPower.Backend.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPower.Backend.Application.Users.Commands.UpdateAssessment
{
    public partial class UpdateAssessmentCommand : IRequest
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public Rating Rating { get; set; }

        public int ActivityId { get; set; }
    }

    public class UpdateAssessmentCommandHandler : IRequestHandler<UpdateAssessmentCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public UpdateAssessmentCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(UpdateAssessmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Assessments.FindAsync(request.Id);

            if (entity == null || !entity.UserId.Equals(_currentUserService.UserId))
            {
                throw new NotFoundException(nameof(Assessment), request.Id);
            }

            entity.Comment = request.Comment;
            entity.Rating = request.Rating;
            entity.ActivityId = request.ActivityId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
