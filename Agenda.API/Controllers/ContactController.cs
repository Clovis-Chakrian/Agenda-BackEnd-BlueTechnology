using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() {
            return Ok("Tudo rodando!");
        }
    }
}