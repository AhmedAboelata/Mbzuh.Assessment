namespace Mbzuh.Assessment.BookService.Application.Bussiness.Books.Commands.Delete;

public class DeleteBookCommandHandler(IApplicationDbContext context) : BaseHandler(context), IRequestHandler<DeleteBookCommand, Result>
{
    public async Task<Result> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await Validate(request, cancellationToken);
        _context.Book.Remove(book);
        await _context.SaveChangesAsync(cancellationToken);
        return new Result(Constants.DeletionSuccessMessage);
    }

    public async Task<Book> Validate(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        return await _context.Book.FindAsync([request.Id], cancellationToken)
            ?? throw new ObjectNotFoundException();
    }
}
