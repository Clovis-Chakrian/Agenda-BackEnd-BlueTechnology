using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.API.Models;

namespace Agenda.API.Libs
{
    public class ContactValidation
    {
        public static void Validate(Contact contact) 
        {
            if (contact == null) throw new ArgumentException("");
            if (contact.Name == null || contact.Name == "") throw new ArgumentException("O campo nome é obrigatório e não pode ser uma string vazia.");
            if (!PhoneValidation.IsValid(contact.Phone) || contact.Phone == "") throw new ArgumentException("O telefone recebido não é válido! Os telefones cadastrados devem seguir o padrão (81) 90000-0000 de telefones do Brasil.");
            if ((contact.Email == "" || contact.Email != null) && !EmailValidation.IsValid(contact.Email)) throw new ArgumentException("O email não é um campo obrigatório, mas ao ser inserido deve ser um email válido!");
        }
    }
}