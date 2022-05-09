using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Platforms.Queries.ListAllPlatforms
{
    public class ListAllPlatformsQuery : IRequest<List<ListPlatformVm>>
    {
    }
}
