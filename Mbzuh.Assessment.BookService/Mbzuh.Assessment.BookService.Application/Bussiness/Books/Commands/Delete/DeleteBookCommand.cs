namespace Mbzuh.Assessment.BookService.Application.Bussiness.Books.Commands.Delete;

public record DeleteBookCommand() : IRequest<Result>
{
    [DefaultValue("")]
    public Guid Id { get; set; }
};
