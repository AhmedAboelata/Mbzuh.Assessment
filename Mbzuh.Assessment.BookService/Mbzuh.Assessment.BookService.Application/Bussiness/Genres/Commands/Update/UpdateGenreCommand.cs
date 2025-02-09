namespace Mbzuh.Assessment.BookService.Application.Bussiness.Genres.Commands.Update;

public record UpdateGenreCommand : IRequest<Result>
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
