using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Genres.Queries.ListAllGenres
{
    public class ListAllGenresQuery : IRequest<List<ListGenreVm>>
    {
    }
}
