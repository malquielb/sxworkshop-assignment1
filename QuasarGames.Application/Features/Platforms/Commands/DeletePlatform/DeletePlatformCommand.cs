using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Features.Platforms.Commands.DeletePlatform
{
    public class DeletePlatformCommand : IRequest
    {
        public int Id { get; set; }
    }
}
