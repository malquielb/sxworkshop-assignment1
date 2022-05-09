using AutoMapper;
using MediatR;
using QuasarGames.Application.Contracts.Persistence;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Games.Commands.CreateGame
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, GameCreatedVm>
    {
        private readonly IAsyncRepository<Game> _gameRepository;
        private readonly IMapper _mapper;

        public CreateGameCommandHandler(IAsyncRepository<Game> gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<GameCreatedVm> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateGameCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            request.CreatedDate = DateTime.Now;
            var game = _mapper.Map<Game>(request);
            game = await _gameRepository.AddAsync(game);

            return _mapper.Map<GameCreatedVm>(game);
        }
    }
}
