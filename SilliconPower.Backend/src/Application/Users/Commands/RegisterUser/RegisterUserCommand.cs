using MediatR;
using SilliconPower.Backend.Application.Common.Exceptions;
using SilliconPower.Backend.Application.Common.Interfaces;
using SilliconPower.Backend.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SilliconPower.Backend.Application.Users.Commands.RegisterUser
{
    public partial class RegisterUserCommand : IRequest<UserDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserDto>
    {
        private readonly IIdentityService _identityService;

        public RegisterUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.CreateUserAsync(request.UserName, request.Password);
            if (result.Result.Errors.Length > 0)
                throw new ValidationException();
            return new UserDto() { Id = result.UserId };
        }
    }
}
