using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.API.Data;
using Agenda.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.API.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _contactContext;
        public ContactRepository(ContactContext contactContext)
        {
            _contactContext = contactContext;
        }
        public void CreateContact(Contact contact)
        {
            _contactContext.Add(contact);
        }

        public void DeleteContact(Contact contact)
        {
            _contactContext.Remove(contact);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _contactContext.Contacts.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _contactContext.SaveChangesAsync() > 0;
        }

        public async Task<Contact> SearchContact(int id)
        {
            return await _contactContext.Contacts.Where(attribute => attribute.Id == id).FirstOrDefaultAsync();
        }

        public void UpdateContact(Contact contact)
        {
            _contactContext.Update(contact);
        }
    }
}