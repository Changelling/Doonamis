using MediatR;
using SilliconPower.Backend.Application.Common.Exceptions;
using SilliconPower.Backend.Application.Common.Interfaces;
using SilliconPower.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPower.Backend.Application.Users.Commands.DeleteAssessment
{
    public class DeleteAssessmentCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteAssessmentCommandHandler : IRequestHandler<DeleteAssessmentCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteAssessmentCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(DeleteAssessmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Assessments.FindAsync(request.Id);

            if (entity == null || !entity.UserId.Equals(_currentUserService.UserId))
            {
                throw new NotFoundException(nameof(Assessment), request.Id);
            }

            _context.Assessments.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
