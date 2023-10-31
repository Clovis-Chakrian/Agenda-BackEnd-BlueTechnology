using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.API.Dtos;
using Agenda.API.Models;

namespace Agenda.UnitTests.Fixtures
{
    public static class ContactFixture
    {
        private static readonly DateTime _date = DateTime.UtcNow;
        public static List<ContactDto> GetListOfTestContacts()
        {
            return new()
            {
                new ContactDto {
                    Id = 1,
                    Name = "Clóvis",
                    LastName = "Chakrian",
                    Phone = "(81) 90000-0000",
                    Email = "clovischakrian@gmail.com",
                },
                new ContactDto {
                    Id = 2,
                    Name = "João",
                    LastName = "Chakrian",
                    Phone = "(81) 91111-1111",
                    Email = "",
                },
                new ContactDto {
                    Id = 3,
                    Name = "Hilária",
                    LastName = "Chakrian",
                    Phone = "(81) 92222-2222",
                    Email = "hilariachakrian@gmail.com",
                },
            };
        }

        public static List<Contact> GetListOfPureModelTestContacts()
        {
            return new()
            {
                new Contact {
                    Id = 1,
                    Name = "Clóvis",
                    LastName = "Chakrian",
                    Phone = "(81) 90000-0000",
                    Email = "clovischakrian@gmail.com",
                    CreatedAt = _date,
                    LastUpdatedAt = _date
                },
                new Contact {
                    Id = 2,
                    Name = "João",
                    LastName = "Chakrian",
                    Phone = "(81) 91111-1111",
                    Email = "",
                    CreatedAt = _date,
                    LastUpdatedAt = _date
                },
                new Contact {
                    Id = 3,
                    Name = "Hilária",
                    LastName = "Chakrian",
                    Phone = "(81) 92222-2222",
                    Email = "hilariachakrian@gmail.com",
                    CreatedAt = _date,
                    LastUpdatedAt = _date
                },
            };
        }

        public static Contact GetTestContact() =>
        new()
        {
            Id = 1,
            Name = "Clóvis",
            LastName = "Chakrian",
            Phone = "(81) 90000-0000",
            Email = "clovischakrian@gmail.com",
            CreatedAt = _date,
            LastUpdatedAt = _date
        };

        public static ContactDto GetTestContactDto() =>
        new()
        {
            Id = 1,
            Name = "Clóvis",
            LastName = "Chakrian",
            Phone = "(81) 90000-0000",
            Email = "clovischakrian@gmail.com",
        };
    }
}