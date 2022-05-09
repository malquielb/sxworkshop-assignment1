using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Platforms.Commands.CreatePlatform
{
    public class CreatePlatformCommandValidator : AbstractValidator<CreatePlatformCommand>
    {
        public CreatePlatformCommandValidator()
        {
            RuleFor(platform => platform.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(25).WithMessage("{PropertyName} must not exceed 25 characters.");
        }
    }
}
