using FluentValidation;
using QuasarGames.Application.Contracts.Persistence;
using QuasarGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        private readonly IAsyncRepository<Genre> _genreRepository;

        public DeleteGenreCommandValidator(IAsyncRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;

            RuleFor(genre => genre.Id)
                .NotEmpty().NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

            RuleFor(genre => genre)
                .MustAsync(GenreExists)
                .WithMessage("Cannot delete an event that doesn't exists.");
        }

        private async Task<bool> GenreExists(DeleteGenreCommand genre, CancellationToken token)
        {
            return !(await _genreRepository.Exists(genre.Id));
        }
    }
}
