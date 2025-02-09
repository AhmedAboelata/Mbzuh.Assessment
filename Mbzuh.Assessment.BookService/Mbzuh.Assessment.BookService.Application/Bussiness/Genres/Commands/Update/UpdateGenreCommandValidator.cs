namespace Mbzuh.Assessment.BookService.Application.Bussiness.Genres.Commands.Update;

public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
{
    public UpdateGenreCommandValidator()
    {
        RuleFor(genre => genre.Id).IntShouldBePositive();
        RuleFor(genre => genre.Name).StringNotEmptyAndMaxLength(100);
    }
}
