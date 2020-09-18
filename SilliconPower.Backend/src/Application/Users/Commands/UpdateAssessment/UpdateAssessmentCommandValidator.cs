using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Application.Users.Commands.UpdateAssessment
{
    public class UpdateAssessmentCommandValidator : AbstractValidator<UpdateAssessmentCommand>
    {
        public UpdateAssessmentCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty();
            RuleFor(v => v.Comment)
                .NotEmpty();
            RuleFor(v => v.Rating)
                .NotEmpty();
            RuleFor(v => v.ActivityId)
                .NotEmpty();
        }
    }
}
