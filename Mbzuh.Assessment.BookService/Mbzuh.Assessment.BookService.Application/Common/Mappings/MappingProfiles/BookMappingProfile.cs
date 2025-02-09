using Mbzuh.Assessment.BookService.Application.Bussiness.Books.Commands.Create;
using Mbzuh.Assessment.BookService.Application.Bussiness.Books.Commands.Update;
using Mbzuh.Assessment.BookService.Application.Bussiness.Books.Shared;

namespace Mbzuh.Assessment.BookService.Application.Common.Mappings.MappingProfiles;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<CreateBookCommand, Book>().ForMember(x => x.Genre, opt => opt.Ignore());
        CreateMap<UpdateBookCommand, Book>().ForMember(x => x.Genre, opt => opt.Ignore());
        CreateMap<Book, BookFieldsDto>().ForMember(x => x.Genre, opt => opt.MapFrom(z => z.Genre.Name));
    }
}
