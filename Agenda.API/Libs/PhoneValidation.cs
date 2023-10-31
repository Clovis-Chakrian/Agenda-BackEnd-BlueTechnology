using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Agenda.API.Libs
{
    public static class PhoneValidation
    {
        public static bool IsValid(string phone)
        {
            string regexPhonePatter = "^((\\+\\d{2}\\s)?\\(\\d{2}\\)\\s?\\d{4}\\d?\\-\\d{4})?$";

            return Regex.IsMatch(phone, regexPhonePatter, RegexOptions.IgnoreCase);
        }
    }
}