using Mbzuh.Assessment.BookService.Application.Common.Mappings;

namespace Mbzuh.Assessment.BookService.Application.Bussiness.Genres.Queries.GetAll;

public class GetAllGenreDto : IMapFrom<Genre>
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
