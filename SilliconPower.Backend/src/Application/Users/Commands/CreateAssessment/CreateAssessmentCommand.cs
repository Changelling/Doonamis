using MediatR;
using SilliconPower.Backend.Application.Common.Interfaces;
using SilliconPower.Backend.Domain.Entities;
using SilliconPower.Backend.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPower.Backend.Application.Users.Commands.CreateAssessment
{
    public class CreateAssessmentCommand : IRequest<int>
    {
        public string Comment { get; set; }
        public Rating Rating { get; set; }

        public int ActivityId { get; set; }
    }

    public class CreateAssessmentCommandHandler : IRequestHandler<CreateAssessmentCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreateAssessmentCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(CreateAssessmentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Assessment
            {
                Comment = request.Comment,
                Rating = request.Rating,
                ActivityId = request.ActivityId,
                UserId = _currentUserService.UserId
            };

            _context.Assessments.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
