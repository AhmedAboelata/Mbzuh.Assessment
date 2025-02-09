using Mbzuh.Assessment.BookService.Application.Bussiness.Books.Shared;

namespace Mbzuh.Assessment.BookService.Application.Bussiness.Books.Queries.GetAll;

public record GetAllBooksQuery : IRequest<ListResult<BookFieldsDto>>
{
    public string? SearchText { get; set; }
    public int Start { get; init; } = 0;
    public int Length { get; init; } = 5;
}
