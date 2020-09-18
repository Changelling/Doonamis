using FluentValidation;

namespace SilliconPower.Backend.Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateActivityCommandValidator : AbstractValidator<CreateActivityCommand>
    {
        public CreateActivityCommandValidator()
        {
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
