using System.Net;

namespace Agenda.Libs.Controllers;

public class ApiErrorResponse : ApiResponse
{
  public string Message { get; set; }
  public IEnumerable<string> Errors { get; set; }
  public ApiErrorResponse(HttpStatusCode statusCode, string message, IEnumerable<string> errors) : base(statusCode)
  {
    Message = message;
    Errors = errors;
  }
}