namespace Mbzuh.Assessment.BookService.Application.Common.Exceptions;
using Mbzuh.Assessment.BookService.Domain.Constants;

public class ObjectNotFoundException(string entityName = "record") : Exception(string.Format(Constants.NoObjectWithThatKey, entityName));