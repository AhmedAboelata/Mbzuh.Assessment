namespace Mbzuh.Assessment.BookService.Application.Common.Shared.Dtos.Response;

public class ListResult<T>(List<T> data, int? count = null, string message = "", bool success = true) : RecordResult<List<T>>(data, message, success)
{
    public int? RecordsTotal { get; set; } = count;
    public int? RecordsFiltered { get; set; } = count;
}
