using Mbzuh.Assessment.BookService.Application.Bussiness.Books.Shared;

namespace Mbzuh.Assessment.BookService.Application.Bussiness.Books.Commands.Create;

public record CreateBookCommand : BookDataFieldsDto, IRequest<Result>;

public class CreateBookCommandHandler(IApplicationDbContext context, IMapper mapper) : BaseHandler(context, mapper), IRequestHandler<CreateBookCommand, Result>
{
    public async Task<Result> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var genreId = await Validate(request, cancellationToken);
        var book = _mapper.Map<Book>(request);
        book.GenreId = genreId;
        await _context.Book.AddAsync(book, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return new Result(Constants.CreationSuccessMessage);
    }

    public async Task<int> Validate(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var genre = await _context.Genre.FirstOrDefaultAsync(x => x.Name == request.Genre, cancellationToken)
            ?? throw new ObjectNotFoundException(nameof(Genres));

        if (await _context.Book.Include(book => book.Genre).AnyAsync(dbBook => dbBook.Title == request.Title && dbBook.Author == request.Author
            && dbBook.ISBN == request.ISBN && dbBook.PublicationYear == request.PublicationYear && dbBook.Genre.Name == request.Genre, cancellationToken))
            throw new AlreadyExistsException();

        return genre.Id;
    }
}
