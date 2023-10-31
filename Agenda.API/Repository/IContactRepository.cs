using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.API.Models;

namespace Agenda.API.Repository
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> SearchContact(int id);
        Task<IEnumerable<Contact>> SearchByName(string name, string lastName);

        void CreateContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
        Task<bool> SaveChangesAsync();
    }
}