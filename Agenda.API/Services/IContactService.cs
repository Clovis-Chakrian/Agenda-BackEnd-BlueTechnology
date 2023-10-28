using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.API.Models;

namespace Agenda.API.Services
{
    public interface IContactService
    {
        public Task<IEnumerable<Contact>> GetAllContacts();
        public Task<Contact> GetContactById(int id);
        public Task<Boolean> CreateContact(Contact contact);
        public Task<Boolean> UpdateContact(int id, Contact contact);
        public Task<Boolean> DeleteContact(int id);
    }
}