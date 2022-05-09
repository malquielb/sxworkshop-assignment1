using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Platforms.Commands.CreatePlatform
{
    public class CreatePlatformCommand : IRequest<PlatformCreatedVm>
    {
        public string Name { get; set; }
    }
}
