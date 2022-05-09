using AutoMapper;
using MediatR;
using QuasarGames.Application.Contracts.Persistence;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Genres.Commands.CreateGenre
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, GenreCreatedVm>
    {
        private readonly IAsyncRepository<Genre> _genreRepository;
        private readonly IMapper _mapper;

        public CreateGenreCommandHandler(IAsyncRepository<Genre> genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<GenreCreatedVm> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateGenreCommandValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var genre = _mapper.Map<Genre>(request);
            genre = await _genreRepository.AddAsync(genre);

            return _mapper.Map<GenreCreatedVm>(genre);
        }
    }
}
