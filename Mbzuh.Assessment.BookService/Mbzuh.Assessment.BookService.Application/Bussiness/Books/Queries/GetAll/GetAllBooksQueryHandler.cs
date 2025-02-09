using Mbzuh.Assessment.BookService.Application.Bussiness.Books.Shared;

namespace Mbzuh.Assessment.BookService.Application.Bussiness.Books.Queries.GetAll;

public class GetAllBooksQueryHandler(IApplicationDbContext context, IMapper mapper) : BaseHandler(context, mapper), IRequestHandler<GetAllBooksQuery, ListResult<BookFieldsDto>>
{
    public async Task<ListResult<BookFieldsDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Book.Include(book => book.Genre).Where(book => string.IsNullOrEmpty(request.SearchText)
            || book.Title.Contains(request.SearchText) || book.Author.Contains(request.SearchText)
            || book.Genre.Name.Contains(request.SearchText) || book.ISBN == request.SearchText
            || book.PublicationYear.ToString() == request.SearchText).AsQueryable();
        var count = await query.CountAsync(cancellationToken);
        var books = await query.OrderBy(x => x.Title).Skip(request.Start).Take(request.Length).ToListAsync(cancellationToken);
        return new ListResult<BookFieldsDto>(_mapper.Map<List<BookFieldsDto>>(books), count);
    }
}