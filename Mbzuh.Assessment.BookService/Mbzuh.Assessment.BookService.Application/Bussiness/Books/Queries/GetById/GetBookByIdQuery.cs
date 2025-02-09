using Mbzuh.Assessment.BookService.Application.Bussiness.Books.Shared;

namespace Mbzuh.Assessment.BookService.Application.Bussiness.Books.Queries.GetById;

public record GetBookByIdQuery() : IRequest<RecordResult<BookFieldsDto>>
{
    [DefaultValue("")]
    public Guid Id { get; set; }
}
