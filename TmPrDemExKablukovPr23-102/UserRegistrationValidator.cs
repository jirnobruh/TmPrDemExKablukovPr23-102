using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TmPrDemExKablukovPr23_102
{
    public class UserRegistrationValidator
    {
        private static readonly Regex EmailPattern = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public bool ValidateRegistration(string userName, string password, string email)
        {
            return IsUserNameValid(userName)
                   && IsPasswordValid(password)
                   && IsEmailValid(email);
        }

        private static bool IsUserNameValid(string userName)
        {
            return !string.IsNullOrWhiteSpace(userName) && userName.Length <= 30;
        }

        private static bool IsPasswordValid(string password)
        {
            return !string.IsNullOrEmpty(password)
                   && password.Length >= 8
                   && password.Any(char.IsUpper)
                   && password.Any(char.IsLower)
                   && password.Any(char.IsDigit)
                   && password.Any(ch => !char.IsLetterOrDigit(ch));
        }

        private static bool IsEmailValid(string email)
        {
            return !string.IsNullOrWhiteSpace(email)
                   && EmailPattern.IsMatch(email);
        }
    }
}
