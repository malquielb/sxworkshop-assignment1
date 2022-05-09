using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuasarGames.Application.Features.Games.Commands.CreateGame;
using QuasarGames.Application.Features.Games.Commands.DeleteGame;
using QuasarGames.Application.Features.Games.Commands.UpdateGame;
using QuasarGames.Application.Features.Games.Queries.GetGameDetailById;
using QuasarGames.Application.Features.Games.Queries.ListAllGames;

namespace QuasarGames.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListGameVm>>> GetAllGames()
        {
            var dtos = await _mediator.Send(new ListAllGamesQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameDetailVm>> GetGameById(int id)
        {
            var dto = await _mediator.Send(new GetGameDetailByIdQuery() { Id = id });
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<GameCreatedVm>> CreateGame(CreateGameCommand createGameCommand)
        {
            var dto = await _mediator.Send(createGameCommand);
            return Ok(dto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateGame(UpdateGameCommand updateGameCommand)
        {
            await _mediator.Send(updateGameCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGame(int id)
        {
            await _mediator.Send(new DeleteGameCommand() { Id = id} );
            return NoContent();
        }
    }
}
