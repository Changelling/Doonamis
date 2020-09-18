using SilliconPower.Backend.Application.Common.Interfaces;
using SilliconPower.Backend.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using SilliconPower.Backend.Domain.ValueObjects;

namespace SilliconPower.Backend.Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateActivityCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Money Price { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
    }

    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateActivityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            var entity = new Activity
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                LocationId = request.LocationId,
                CategoryId = request.CategoryId
            };

            _context.Activities.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
