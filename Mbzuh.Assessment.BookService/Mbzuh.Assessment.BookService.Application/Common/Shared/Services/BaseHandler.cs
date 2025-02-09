namespace Mbzuh.Assessment.BookService.Application.Common.Shared.Services;

public class BaseHandler
{
    protected readonly IApplicationDbContext _context;
    protected readonly IMapper _mapper;

    public BaseHandler(IApplicationDbContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);
    public BaseHandler(IApplicationDbContext context) => _context = context;
}
