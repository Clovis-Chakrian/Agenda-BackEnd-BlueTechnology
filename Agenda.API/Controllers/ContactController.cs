using System.Net;
using Agenda.Libs.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : AbstractController
    {
        [HttpGet]
        public IActionResult GetAll([FromQuery] HttpStatusCode? statusCode)
        {
            if (statusCode.HasValue) return CustomResponse($"ola {statusCode}", statusCode.Value);
            return CustomResponse("Ola");
        }
    }
}