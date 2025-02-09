namespace Mbzuh.Assessment.BookService.Application.Bussiness.Books.Shared;

public record BookFieldsDto : BookDataFieldsDto
{
    [DefaultValue("")]
    public Guid Id { get; set; }
}
