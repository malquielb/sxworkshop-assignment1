using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Genres.Commands.DeleteGenre
{
    public class DeleteGenreCommand : IRequest
    {
        public int Id { get; set; }
    }
}
