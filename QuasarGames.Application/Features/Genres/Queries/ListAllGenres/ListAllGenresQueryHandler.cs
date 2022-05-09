using AutoMapper;
using MediatR;
using QuasarGames.Application.Contracts.Persistence;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Genres.Queries.ListAllGenres
{
    public class ListAllGenreQueryHandler : IRequestHandler<ListAllGenresQuery, List<ListGenreVm>>
    {
        private readonly IAsyncRepository<Genre> _genreRepository;
        private readonly IMapper _mapper;

        public ListAllGenreQueryHandler(IAsyncRepository<Genre> genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<List<ListGenreVm>> Handle(ListAllGenresQuery request, CancellationToken cancellationToken)
        {
            var genresList = await _genreRepository.ListAllAsync();
            return _mapper.Map<List<ListGenreVm>>(genresList);
        }
    }
}
