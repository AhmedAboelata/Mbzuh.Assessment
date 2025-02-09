using MediatR;

namespace Mbzuh.Assessment.BookService.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]

public abstract class BaseController : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
