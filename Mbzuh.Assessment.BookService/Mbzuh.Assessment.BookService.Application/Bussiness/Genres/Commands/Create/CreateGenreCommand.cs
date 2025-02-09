namespace Mbzuh.Assessment.BookService.Application.Bussiness.Genres.Commands.Create;

public record CreateGenreCommand : IRequest<Result>
{
    public required string Name { get; set; }
}
