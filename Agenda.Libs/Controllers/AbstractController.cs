using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Libs.Controllers;

[ApiController]
public class AbstractController : ControllerBase
{
  public static IActionResult CustomResponse<T>(T data)
  {
    return new OkObjectResult(new ApiSuccessResponse<T>(HttpStatusCode.OK, data));
  }

  public static IActionResult CustomResponse<T>(T data, HttpStatusCode statusCode)
  {
    return new ObjectResult(new ApiSuccessResponse<T>(statusCode, data))
    {
      StatusCode = (int)statusCode
    };
  }
}