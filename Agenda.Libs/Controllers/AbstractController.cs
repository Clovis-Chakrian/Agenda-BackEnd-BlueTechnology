using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Libs.Controllers;

[ApiController]
public class AbstractController : ControllerBase
{
  public static ApiSuccessResponse<T> CustomResponse<T>(T data)
  {
    return new ApiSuccessResponse<T>(HttpStatusCode.OK, data);
  }

  public static ApiSuccessResponse<T> CustomResponse<T>(T data, HttpStatusCode statusCode)
  {
    return new ApiSuccessResponse<T>(statusCode, data);
  }
}