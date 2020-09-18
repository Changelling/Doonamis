using MediatR;
using SilliconPower.Backend.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPower.Backend.Application.Users.Commands.UpdateProfile
{
    public partial class UpdateProfileCommand : IRequest
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand>
    {
        private readonly IIdentityService _identityService;
        private readonly ICurrentUserService _currentUserService;

        public UpdateProfileCommandHandler(IIdentityService identityService, ICurrentUserService currentUserService)
        {
            _identityService = identityService;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            await _identityService.UpdateUserAsync(_currentUserService.UserId, request.Name, request.Image);

            return Unit.Value;
        }
    }
}
