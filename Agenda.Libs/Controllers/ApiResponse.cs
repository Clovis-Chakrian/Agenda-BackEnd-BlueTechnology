using System.Net;

namespace Agenda.Libs.Controllers;

public abstract class ApiResponse(HttpStatusCode statusCode)
{
  public bool Success { get; set; } = ((int)statusCode) >= 200 && ((int)statusCode) <= 299;
  public HttpStatusCode StatusCode { get; set; } = statusCode;
}