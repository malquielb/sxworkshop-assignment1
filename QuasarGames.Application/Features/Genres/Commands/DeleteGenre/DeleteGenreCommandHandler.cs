using AutoMapper;
using MediatR;
using QuasarGames.Application.Contracts.Persistence;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand>
    {
        private readonly IAsyncRepository<Genre> _genreRepository;

        public DeleteGenreCommandHandler(IAsyncRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteGenreCommandValidator(_genreRepository);
            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var genre = await _genreRepository.GetByIdAsync(request.Id);
            await _genreRepository.DeleteAsync(genre);

            return Unit.Value;
        }
    }
}
