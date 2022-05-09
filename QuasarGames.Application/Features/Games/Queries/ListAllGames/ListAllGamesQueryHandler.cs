using AutoMapper;
using MediatR;
using QuasarGames.Application.Contracts.Persistence;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Games.Queries.ListAllGames
{
    public class ListAllGamesQueryHandler : IRequestHandler<ListAllGamesQuery, List<ListGameVm>>
    {
        private IAsyncRepository<Game> _gameRepository;
        private IMapper _mapper;

        public ListAllGamesQueryHandler(IAsyncRepository<Game> gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<List<ListGameVm>> Handle(ListAllGamesQuery request, CancellationToken cancellationToken)
        {
            var gameList = (await _gameRepository.ListAllAsync())
                                .OrderBy(g => g.Title);
            return _mapper.Map<List<ListGameVm>>(gameList);
        }
    }
}
