using SilliconPower.Backend.Application.Common.Exceptions;
using SilliconPower.Backend.Application.Common.Interfaces;
using SilliconPower.Backend.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SilliconPower.Backend.Domain.ValueObjects;

namespace SilliconPower.Backend.Application.Activities.Commands.UpdateActivity
{
    public partial class UpdateActivityCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Money Price { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
    }

    public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateActivityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Activities.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Activity), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Price = request.Price;
            entity.LocationId = request.LocationId;
            entity.CategoryId = request.CategoryId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
