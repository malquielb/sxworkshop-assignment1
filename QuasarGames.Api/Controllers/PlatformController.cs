using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuasarGames.Application.Features.Platforms.Commands.CreatePlatform;
using QuasarGames.Application.Features.Platforms.Commands.DeletePlatform;
using QuasarGames.Application.Features.Platforms.Queries.ListAllPlatforms;

namespace QuasarGames.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformController : ControllerBase
    {
        private IMediator _mediator;

        public PlatformController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListPlatformVm>>> GetAllPlatforms()
        {
            var dtos = await _mediator.Send(new ListAllPlatformsQuery());
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<PlatformCreatedVm>> CreateGenre(CreatePlatformCommand createPlatformCommand)
        {
            var dto = await _mediator.Send(createPlatformCommand);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlatform(int id)
        {
            await _mediator.Send(new DeletePlatformCommand() { Id = id });
            return NoContent();
        }
    }
}
