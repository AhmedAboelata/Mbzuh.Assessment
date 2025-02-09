using Mbzuh.Assessment.BookService.Application.Bussiness.Books.Shared;

namespace Mbzuh.Assessment.BookService.Application.Bussiness.Books.Commands.Update;

public record UpdateBookCommand : BookDataFieldsDto, IRequest<Result>
{
    [DefaultValue("")]
    public Guid Id { get; set; }
}
