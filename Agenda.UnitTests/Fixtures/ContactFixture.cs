using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.API.Models;

namespace Agenda.UnitTests.Fixtures
{
    public static class ContactFixture
    {
        public static List<Contact> GetListOfTestContacts() =>
        new()
        {
            new Contact {
                Id = 1,
                Name = "Clóvis",
                LastName = "Chakrian",
                Phone = "(81) 90000-0000",
                Email = "clovischakrian@gmail.com"
            },
            new Contact {
                Id = 2,
                Name = "João",
                LastName = "Chakrian",
                Phone = "(81) 91111-1111",
                Email = ""
            },
            new Contact {
                Id = 3,
                Name = "Hilária",
                LastName = "Chakrian",
                Phone = "(81) 92222-2222",
                Email = "hilariachakrian@gmail.com"
            },
        };

        public static Contact GetTestContact() =>
        new()
        {
            Id = 1,
            Name = "Clóvis",
            LastName = "Chakrian",
            Phone = "(81) 90000-0000",
            Email = "clovischakrian@gmail.com"
        };
    }
}