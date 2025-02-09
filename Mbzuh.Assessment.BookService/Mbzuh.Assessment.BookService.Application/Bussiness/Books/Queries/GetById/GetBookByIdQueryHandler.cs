using Mbzuh.Assessment.BookService.Application.Bussiness.Books.Shared;

namespace Mbzuh.Assessment.BookService.Application.Bussiness.Books.Queries.GetById;

public class GetBookByIdHandler(IApplicationDbContext context, IMapper mapper) : BaseHandler(context, mapper), IRequestHandler<GetBookByIdQuery, RecordResult<BookFieldsDto>>
{
    public async Task<RecordResult<BookFieldsDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _context.Book.Include(x => x.Genre).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new ObjectNotFoundException();
        return new RecordResult<BookFieldsDto>(_mapper.Map<BookFieldsDto>(book));
    }
}
