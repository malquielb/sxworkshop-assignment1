using FluentValidation;
using QuasarGames.Application.Contracts.Persistence;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Games.Commands.DeleteGame
{
    public class DeleteGameCommandValidator : AbstractValidator<DeleteGameCommand>
    {
        private readonly IAsyncRepository<Game> _gameRepository;

        public DeleteGameCommandValidator(IAsyncRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;

            RuleFor(game => game.Id)
                .NotEmpty().NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

            RuleFor(game => game)
                .MustAsync(GameExists)
                .WithMessage("Cannot delete an event that doesn't exists.");
        }

        private async Task<bool> GameExists(DeleteGameCommand game, CancellationToken token)
        {
            return !(await _gameRepository.Exists(game.Id));
        }
    }
}
