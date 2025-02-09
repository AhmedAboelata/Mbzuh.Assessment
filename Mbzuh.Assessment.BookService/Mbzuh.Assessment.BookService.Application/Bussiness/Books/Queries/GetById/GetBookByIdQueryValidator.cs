namespace Mbzuh.Assessment.BookService.Application.Bussiness.Books.Queries.GetById;

public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
{
    public GetBookByIdQueryValidator()
    {
        RuleFor(book => book.Id).GuidNotEmpty();
    }
}
