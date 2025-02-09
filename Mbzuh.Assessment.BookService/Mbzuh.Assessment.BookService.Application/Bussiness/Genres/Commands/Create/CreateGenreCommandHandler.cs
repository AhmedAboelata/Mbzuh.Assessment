namespace Mbzuh.Assessment.BookService.Application.Bussiness.Genres.Commands.Create;

public class CreateGenreCommandHandler(IApplicationDbContext context) : BaseHandler(context), IRequestHandler<CreateGenreCommand, Result>
{
    public async Task<Result> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        await Validate(request, cancellationToken);
        await _context.Genre.AddAsync(new Genre { Name = request.Name }, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return new Result(Constants.CreationSuccessMessage);
    }

    public async Task Validate(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        if (await _context.Genre.AnyAsync(genre => genre.Name == request.Name, cancellationToken))
            throw new AlreadyExistsException();
    }
}
