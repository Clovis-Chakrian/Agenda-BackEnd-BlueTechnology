using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.API.Libs;
using Agenda.API.Models;
using Agenda.API.Repository;

namespace Agenda.API.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<Boolean> CreateContact(Contact contact)
        {
            ContactValidation.Validate(contact);
            contact.CreatedAt = DateTime.Now;
            contact.LastUpdatedAt = DateTime.Now;
            _contactRepository.CreateContact(contact);
            return await _contactRepository.SaveChangesAsync();
        }

        public async Task<Boolean> DeleteContact(int id)
        {
            var contact = await _contactRepository.SearchContact(id);
            if (contact == null)
                return false;
            _contactRepository.DeleteContact(contact);
            return await _contactRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            var contacts = await _contactRepository.GetContacts();
            return contacts;
        }

        public Task<Contact> GetContactById(int id)
        {
            var contact = _contactRepository.SearchContact(id);
            return contact;
        }

        public async Task<Boolean> UpdateContact(int id, Contact contact)
        {
            var bdContact = await _contactRepository.SearchContact(id);
            if (bdContact == null)
                return false;

            bdContact.Name = contact.Name ?? bdContact.Name;
            bdContact.LastName = contact.LastName ?? bdContact.LastName;
            bdContact.Phone = contact.Phone ?? bdContact.Phone;
            bdContact.Email = contact.Email ?? bdContact.Email;
            bdContact.LastUpdatedAt = DateTime.Now;

            _contactRepository.UpdateContact(bdContact);

            return await _contactRepository.SaveChangesAsync();
        }
    }
}