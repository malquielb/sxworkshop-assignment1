using AutoMapper;
using MediatR;
using QuasarGames.Application.Contracts.Persistence;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Games.Commands.UpdateGame
{
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand>
    {
        private readonly IAsyncRepository<Game> _gameRepository;
        private readonly IMapper _mapper;

        public UpdateGameCommandHandler(IAsyncRepository<Game> gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGameCommandValidator(_gameRepository);
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var game = await _gameRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, game, typeof(UpdateGameCommand), typeof(Game));
            await _gameRepository.UpdateAsync(game);

            return Unit.Value;
        }
    }
}
