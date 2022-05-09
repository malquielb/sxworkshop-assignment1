using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Genres.Commands.CreateGenre
{
    public class CreateGenreCommand : IRequest<GenreCreatedVm>
    {
        public string Name { get; set; }
    }
}
