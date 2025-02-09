namespace Mbzuh.Assessment.BookService.Application.Bussiness.Genres.Queries.GetAll;

public record GetAllGenreQuery : IRequest<ListResult<GetAllGenreDto>>;

public class GetAllGenreQueryHandler(IApplicationDbContext context, IMapper mapper) : BaseHandler(context, mapper), IRequestHandler<GetAllGenreQuery, ListResult<GetAllGenreDto>>
{
    public async Task<ListResult<GetAllGenreDto>> Handle(GetAllGenreQuery request, CancellationToken cancellationToken)
    {
        var genres = await _context.Genre.ToListAsync(cancellationToken);
        return new ListResult<GetAllGenreDto>(_mapper.Map<List<GetAllGenreDto>>(genres), genres.Count);
    }
}