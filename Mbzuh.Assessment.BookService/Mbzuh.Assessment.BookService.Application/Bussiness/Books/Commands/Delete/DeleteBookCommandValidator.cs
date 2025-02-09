namespace Mbzuh.Assessment.BookService.Application.Bussiness.Books.Commands.Delete;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(book => book.Id).GuidNotEmpty();
    }
}
