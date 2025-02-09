namespace Mbzuh.Assessment.BookService.Application.Common.Shared.Dtos.Response;

public class RecordResult<T>(T data, string message = "", bool success = true) : Result(message, success)
{
    public T Data { get; set; } = data;
}
