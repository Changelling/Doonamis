using FluentValidation;

namespace SilliconPower.Backend.Application.Activities.Commands.UpdateActivity
{
    public class UpdateActivityCommandValidator : AbstractValidator<UpdateActivityCommand>
    {
        public UpdateActivityCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty();
            RuleFor(v => v.Name)
                .MaximumLength(200)
                .NotEmpty();
            RuleFor(v => v.Price)
                .NotEmpty();
            RuleFor(v => v.LocationId)
                .NotEmpty();
            RuleFor(v => v.CategoryId)
                .NotEmpty();
        }
    }
}
