using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Application.Users.Commands.CreateAssessment
{
     public class CreateAssessmentCommandValidator : AbstractValidator<CreateAssessmentCommand>
    {
        public CreateAssessmentCommandValidator()
        {
            RuleFor(v => v.Comment)
                .NotEmpty();
            RuleFor(v => v.Rating)
                .NotEmpty();
            RuleFor(v => v.ActivityId)
                .NotEmpty();
        }
    }
}
