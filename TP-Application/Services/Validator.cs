using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TP_Application.Services
{
    public class Validator
    {

        public static bool EmailValid(string email)
        {
            string patternEmail = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            return Regex.IsMatch(email, patternEmail);
        }

        public static bool StringEmpty(string s)
        {
            return s.Length == 0;
        }

        public static bool StringEmpty(List<string> listString)
        {
            foreach (string s in listString)
                if (StringEmpty(s)) return true;
            return false;
        }

        public static bool IntNegativeOrZero(int s)
        {
            return s <= 0;
        }

        public static bool DNIValid (string dni)
        {
            string patternDNI = @"\d{7,11}";
            return Regex.IsMatch(dni, patternDNI);
        }
    }
}
