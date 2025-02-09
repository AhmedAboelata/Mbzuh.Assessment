namespace Mbzuh.Assessment.BookService.Application.Bussiness.Books.Commands.Create;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(book => book.Title).StringNotEmptyAndMaxLength(200);
        RuleFor(book => book.Author).StringNotEmptyAndMaxLength(200);
        RuleFor(book => book.ISBN).StringLength(10, 13).NumbersOnly();
        RuleFor(book => book.PublicationYear).IntRange(1900, 9999);
        RuleFor(book => book.Genre).StringNotEmptyAndMaxLength(100);
    }
}
