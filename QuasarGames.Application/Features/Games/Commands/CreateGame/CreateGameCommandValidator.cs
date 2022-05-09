using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Games.Commands.CreateGame
{
    public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
    {
        public CreateGameCommandValidator()
        {
            RuleFor(game => game.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(game => game.Publisher)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(game => game.Developer)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(game => game.Engine)
                .MaximumLength(25).WithMessage("{PropertyName} must not exceed 25 characters.");

            RuleFor(game => game.ReleaseYear)
                .GreaterThanOrEqualTo(1947)
                .LessThanOrEqualTo(DateTime.Now.Year);

            RuleFor(game => game.AgeRating)
                .IsInEnum()
                .NotNull();

            RuleFor(game => game.CreatedDate)
                .Empty()
                .Unless(game => game.CreatedDate == DateTime.Now, ApplyConditionTo.CurrentValidator);
        }
    }
}
