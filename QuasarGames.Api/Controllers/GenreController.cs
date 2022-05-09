using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuasarGames.Application.Features.Genres.Commands.CreateGenre;
using QuasarGames.Application.Features.Genres.Commands.DeleteGenre;
using QuasarGames.Application.Features.Genres.Queries.ListAllGenres;

namespace QuasarGames.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListGenreVm>>> GetAllGenres()
        {
            var dtos = await _mediator.Send(new ListAllGenresQuery());
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<GenreCreatedVm>> CreateGenre(CreateGenreCommand createGenreCommand)
        {
            var dto = await _mediator.Send(createGenreCommand);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            await _mediator.Send(new DeleteGenreCommand() { Id = id });
            return NoContent();
        }
    }
}
