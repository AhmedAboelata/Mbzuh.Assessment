namespace Mbzuh.Assessment.BookService.Application.Common.Exceptions;
using Mbzuh.Assessment.BookService.Domain.Constants;

public class AlreadyExistsException(string entityName = "record") : Exception(string.Format(Constants.AnotherObjectExists, entityName));
