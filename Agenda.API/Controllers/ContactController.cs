using Agenda.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var contacts = await _contactService.GetAllContacts();
            if (contacts.Any())
                return Ok(contacts);
            return Ok("Nenhum contato cadastrado ainda.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _contactService.GetContactById(id);
            if (contact != null)
                return Ok(contact);
            return NotFound("Não foi encontrado nenhum contato para o Id recebido.");
        }
    }
}