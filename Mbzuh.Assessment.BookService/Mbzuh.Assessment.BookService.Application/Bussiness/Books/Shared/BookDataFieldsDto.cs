namespace Mbzuh.Assessment.BookService.Application.Bussiness.Books.Shared;

public record BookDataFieldsDto
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string ISBN { get; set; }
    public int PublicationYear { get; set; }
    public required string Genre { get; set; }
}
