using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Games.Queries.ListAllGames
{
    public class ListAllGamesQuery : IRequest<List<ListGameVm>>
    {
    }
}
