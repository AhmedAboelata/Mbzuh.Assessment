namespace Mbzuh.Assessment.BookService.Application.Bussiness.Books.Commands.Update;

public class UpdateBookCommandHandler(IApplicationDbContext context, IMapper mapper) : BaseHandler(context, mapper), IRequestHandler<UpdateBookCommand, Result>
{
    public async Task<Result> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var genreId = await Validate(request, cancellationToken);
        Book? book = _mapper.Map<Book>(request);
        book.GenreId = genreId;
        _context.Book.Update(book);
        await _context.SaveChangesAsync(cancellationToken);
        return new Result(Constants.ModificationSuccessMessage);
    }

    public async Task<int> Validate(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var genre = await _context.Genre.FirstOrDefaultAsync(x => x.Name == request.Genre, cancellationToken)
            ?? throw new ObjectNotFoundException(nameof(Genre));

        if (await _context.Book.Include(book => book.Genre).AnyAsync(dbBook => dbBook.Title == request.Title && dbBook.Author == request.Author
            && dbBook.ISBN == request.ISBN && dbBook.PublicationYear == request.PublicationYear && dbBook.Genre.Name == request.Genre
            && dbBook.Id != request.Id, cancellationToken))
            throw new AlreadyExistsException();

        var book = await _context.Book.AsNoTracking().FirstOrDefaultAsync(book => book.Id == request.Id, cancellationToken)
            ?? throw new ObjectNotFoundException(nameof(Book));

        return genre.Id;
    }
}
