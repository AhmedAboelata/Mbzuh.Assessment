namespace Mbzuh.Assessment.BookService.Application.Bussiness.Books.Queries.GetAll;

public class GetAllBooksQueryValidator : AbstractValidator<GetAllBooksQuery>
{
    public GetAllBooksQueryValidator()
    {
        RuleFor(x => x.Start).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Length).GreaterThanOrEqualTo(1);
    }
}
