using System.Net;

namespace Agenda.Libs.Controllers;

public class ApiSuccessResponse<T> : ApiResponse
{
  public T Data { get; set; }
  public ApiSuccessResponse(HttpStatusCode statusCode, T data) : base(statusCode)
  {
    Data = data;
  }
}