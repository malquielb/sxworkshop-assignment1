using AutoMapper;
using MediatR;
using QuasarGames.Application.Contracts.Persistence;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Games.Commands.DeleteGame
{
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand>
    {
        private readonly IAsyncRepository<Game> _gameRepository;

        public DeleteGameCommandHandler(IAsyncRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Unit> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteGameCommandValidator(_gameRepository);
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var game = await _gameRepository.GetByIdAsync(request.Id);
            await _gameRepository.DeleteAsync(game);

            return Unit.Value;
        }
    }
}
