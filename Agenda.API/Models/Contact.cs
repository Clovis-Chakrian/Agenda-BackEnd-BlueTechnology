using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.API.Models
{
    public class Contact
    {
        public int Id;
        public string Name;
        public string LastName;
        public string Email;
        public string Phone;
    }
}