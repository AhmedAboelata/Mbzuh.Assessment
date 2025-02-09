using Mbzuh.Assessment.BookService.Application.Bussiness.Genres.Commands.Create;
using Mbzuh.Assessment.BookService.Application.Bussiness.Genres.Commands.Update;
using Mbzuh.Assessment.BookService.Application.Bussiness.Genres.Queries.GetAll;

namespace Mbzuh.Assessment.BookService.API.Controllers;

public class GenreController : BaseController
{
    [HttpPost] // POST: api/Genre/Create
    public async Task<IActionResult> Create(CreateGenreCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPost] // POST: api/Genre/Update
    public async Task<IActionResult> Update(UpdateGenreCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet] // GET: api/Genre/GetAll
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAllGenreQuery()));
    }
}