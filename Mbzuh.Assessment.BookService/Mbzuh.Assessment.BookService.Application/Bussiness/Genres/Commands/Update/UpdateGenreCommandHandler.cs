namespace Mbzuh.Assessment.BookService.Application.Bussiness.Genres.Commands.Update;

public class UpdateGenreCommandHandler(IApplicationDbContext context) : BaseHandler(context), IRequestHandler<UpdateGenreCommand, Result>
{
    public async Task<Result> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        await Validate(request, cancellationToken);
        await _context.Genre.Where(x => x.Id == request.Id).ExecuteUpdateAsync(x => x.SetProperty(z => z.Name, request.Name), cancellationToken);
        return new Result(Constants.ModificationSuccessMessage);
    }

    public async Task Validate(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        if (!await _context.Genre.AnyAsync(x => x.Id == request.Id, cancellationToken))
            throw new ObjectNotFoundException();
        if (await _context.Genre.AnyAsync(DbGenre => DbGenre.Name == request.Name && DbGenre.Id != request.Id, cancellationToken))
            throw new AlreadyExistsException();
    }
}
