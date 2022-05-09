using FluentValidation;
using QuasarGames.Application.Contracts.Persistence;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Games.Commands.UpdateGame
{
    public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand>
    {
        private readonly IAsyncRepository<Game> _gameRepository;

        public UpdateGameCommandValidator(IAsyncRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;

            RuleFor(game => game.Id)
                .NotEmpty().NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

            RuleFor(game => game)
                .MustAsync(GameExists)
                .WithMessage("Cannot update an event that doesn't exists.");

            RuleFor(game => game.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(game => game.Publisher)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(game => game.Developer)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(game => game.Engine)
                .MaximumLength(25).WithMessage("{PropertyName} must not exceed 25 characters.");

            RuleForEach(game => game.Genres)
                .ChildRules(genre => {
                    genre.RuleFor(g => g.Name)
                        .MaximumLength(25).WithMessage("{PropertyName} must not exceed 25 characters.");
                });

            RuleForEach(game => game.Platforms)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .ChildRules(platform => {
                    platform.RuleFor(p => p.Name)
                        .NotEmpty().WithMessage("{PropertyName} must not be empty.")
                        .MaximumLength(25).WithMessage("{PropertyName} must not exceed 25 characters.");
                });

            RuleFor(game => game.ReleaseYear)
                .GreaterThanOrEqualTo(1947)
                .LessThanOrEqualTo(DateTime.Now.Year);

            RuleFor(game => game.AgeRating)
                .IsInEnum()
                .NotNull();
        }

        private async Task<bool> GameExists(UpdateGameCommand game, CancellationToken token)
        {
            return !(await _gameRepository.Exists(game.Id));
        }
    }
}
