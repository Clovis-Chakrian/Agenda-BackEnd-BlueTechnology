using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.API.Models;

namespace Agenda.API.Services
{
    public class ContactService : IContactService
    {
        public Task<bool> CreateUser(Contact contact)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetContactById(int id)
        {
            throw new NotImplementedException();
        }
    }
}