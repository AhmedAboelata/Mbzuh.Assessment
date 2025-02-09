using Mbzuh.Assessment.BookService.Application.Bussiness.Books.Commands.Create;
using Mbzuh.Assessment.BookService.Application.Bussiness.Books.Commands.Delete;
using Mbzuh.Assessment.BookService.Application.Bussiness.Books.Commands.Update;
using Mbzuh.Assessment.BookService.Application.Bussiness.Books.Queries.GetAll;
using Mbzuh.Assessment.BookService.Application.Bussiness.Books.Queries.GetById;

namespace Mbzuh.Assessment.BookService.API.Controllers;

public class BookController : BaseController
{
    [HttpPost] // POST: api/Book/Create
    public async Task<IActionResult> Create(CreateBookCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPost] // POST: api/Book/Update
    public async Task<IActionResult> Update(UpdateBookCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPost] // POST: api/Book/Delete
    public async Task<IActionResult> Delete(DeleteBookCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet] // GET: api/Book/GetById
    public async Task<IActionResult> GetById([FromQuery] GetBookByIdQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpGet] // GET: api/Book/Get
    public async Task<IActionResult> Get([FromQuery] GetAllBooksQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
}
