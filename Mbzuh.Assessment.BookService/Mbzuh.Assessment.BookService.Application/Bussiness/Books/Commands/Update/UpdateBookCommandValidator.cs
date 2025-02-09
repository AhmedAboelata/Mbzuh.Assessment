namespace Mbzuh.Assessment.BookService.Application.Bussiness.Books.Commands.Update;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(book => book.Id).GuidNotEmpty();
        RuleFor(book => book.Title).StringNotEmptyAndMaxLength(200);
        RuleFor(book => book.Author).StringNotEmptyAndMaxLength(200);
        RuleFor(book => book.ISBN).StringLength(10, 13).NumbersOnly();
        RuleFor(book => book.PublicationYear).IntRange(1900, 9999);
        RuleFor(book => book.Genre).StringNotEmptyAndMaxLength(100);
    }
}
