using AutoMapper;
using MediatR;
using QuasarGames.Application.Contracts.Persistence;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Games.Queries.GetGameDetailById
{
    public class GetGameDetailByIdQueryHandler : IRequestHandler<GetGameDetailByIdQuery, GameDetailVm>
    {
        private readonly IAsyncRepository<Game> _gameRepository;
        private readonly IMapper _mapper;

        public GetGameDetailByIdQueryHandler(IAsyncRepository<Game> gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<GameDetailVm> Handle(GetGameDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetByIdAsync(request.Id);
            return _mapper.Map<GameDetailVm>(game);
        }
    }
}
