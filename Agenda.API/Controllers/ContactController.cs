using Agenda.API.Models;
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

        [HttpPost]
        public async Task<IActionResult> Post(Contact contact)
        {
            var success = await _contactService.CreateContact(contact);
            if (success)
                return Created("", contact);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Contact contact)
        {
            var success = await _contactService.UpdateContact(id, contact);
            if (success)
                return Ok(contact);
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = _contactService.DeleteContact(id);
            return Ok("Opa");
        }
    }
}