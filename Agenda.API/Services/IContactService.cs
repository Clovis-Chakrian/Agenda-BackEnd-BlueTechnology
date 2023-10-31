using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.API.Dtos;
using Agenda.API.Models;

namespace Agenda.API.Services
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> GetAllContacts();
        Task<ContactDto> GetContactById(int id);
        Task<IEnumerable<ContactDto>> SearchContactByName(string name, string LastName);
        Task<Boolean> CreateContact(ContactDto contact);
        Task<Boolean> UpdateContact(int id, ContactDto contact);
        Task<Boolean> DeleteContact(int id);
    }
}