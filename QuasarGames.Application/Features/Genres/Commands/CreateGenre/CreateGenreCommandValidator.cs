using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Genres.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(genre => genre.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(25).WithMessage("{PropertyName} must not exceed 25 characters.");
        }
    }
}
