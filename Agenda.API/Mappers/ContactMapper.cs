using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.API.Dtos;
using Agenda.API.Models;
using AutoMapper;

namespace Agenda.API.Mappers
{
    public class ContactMapper : Profile
    {
        public ContactMapper() 
        {
            CreateMap<Contact, ContactDto>();
            CreateMap<ContactDto, Contact>();
        }
    }
}