namespace Mbzuh.Assessment.BookService.Application.Common.Shared.Dtos.Response;

public class Result
{
    public string Message { get; set; }
    public bool Success { get; set; }

    public Result(string message = "", bool success = true) => (Message, Success) = (message, success);
}
