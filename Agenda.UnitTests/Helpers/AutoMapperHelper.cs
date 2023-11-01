using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.API.Mappers;
using AutoMapper;

namespace Agenda.UnitTests.Helpers
{
    public static class AutoMapperHelper
    {
        public static IMapper AutoMapper()
        {
            var mockMapp = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new ContactMapper());
            });

            IMapper mapper = mockMapp.CreateMapper();

            return mapper;
        }
    }
}