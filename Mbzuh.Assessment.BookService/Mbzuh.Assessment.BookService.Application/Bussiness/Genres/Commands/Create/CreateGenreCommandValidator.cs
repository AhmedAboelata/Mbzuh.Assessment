namespace Mbzuh.Assessment.BookService.Application.Bussiness.Genres.Commands.Create;

public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
{
    public CreateGenreCommandValidator()
    {
        RuleFor(genre => genre.Name).StringNotEmptyAndMaxLength(100);
    }
}
