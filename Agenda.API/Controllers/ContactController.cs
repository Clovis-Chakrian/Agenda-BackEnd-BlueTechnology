using Agenda.API.Dtos;
using Agenda.API.Mappers;
using Agenda.API.Models;
using Agenda.API.Services;
using AutoMapper;
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
        public async Task<IActionResult> Post(ContactDto contact)
        {
            var success = await _contactService.CreateContact(contact);
            if (success)
                return Created("", contact);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ContactDto contact)
        {
            var success = await _contactService.UpdateContact(id, contact);
            if (success)
                return Ok($"Usuário de id {id} atualizado com sucesso!");
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _contactService.DeleteContact(id);
            if (success)
                return Ok($"Usuário de id {id} foi deletado com sucesso.");
            return BadRequest($"Não foi possível deletar o contato de id {id}. Tente novamente mais tarde!");
        }
    }
}