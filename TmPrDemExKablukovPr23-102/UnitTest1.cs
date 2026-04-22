using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text.RegularExpressions;

namespace TmPrDemExKablukovPr23_102
{
    [TestClass]
    public class UserRegistrationValidatorTests
    {
        private const string ValidUserName = "ValidUser";
        private const string ValidPassword = "Aa1!aaaa";
        private const string ValidEmail = "user@example.com";

        private readonly UserRegistrationValidator _validator = new UserRegistrationValidator();

        [DataTestMethod]
        [DataRow("A", true)]
        [DataRow("123456789012345678901234567890", true)]
        [DataRow("1234567890123456789012345678901", false)]
        [DataRow("", false)]
        [DataRow("   ", false)]
        public void Test_UserNameValidation(string userName, bool expected)
        {
            var actual = _validator.ValidateRegistration(userName, ValidPassword, ValidEmail);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("Aa1!aaaa", true)]
        [DataRow("aa1!aaaa", false)]
        [DataRow("AA1!AAAA", false)]
        [DataRow("Aa!!aaaa", false)]
        [DataRow("Aa11aaaa", false)]
        [DataRow("Aa1!aaa", false)]
        public void Test_PasswordValidation(string password, bool expected)
        {
            var actual = _validator.ValidateRegistration(ValidUserName, password, ValidEmail);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("user@example.com", true)]
        [DataRow("user.name+tag@mail-domain.com", true)]
        [DataRow("invalid-email", false)]
        [DataRow("", false)]
        [DataRow("   ", false)]
        public void Test_EmailValidation(string email, bool expected)
        {
            var actual = _validator.ValidateRegistration(ValidUserName, ValidPassword, email);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("A", "Aa1!aaaa", "user@example.com", true)]
        [DataRow("ValidUser", "Aa1!aaaa", "user.name+tag@mail-domain.com", true)]
        [DataRow("   ", "Aa1!aaaa", "user@example.com", false)]
        [DataRow("ValidUser", "Aa1!aaa", "user@example.com", false)]
        [DataRow("ValidUser", "Aa1!aaaa", "   ", false)]
        public void Test_CompleteRegistration(string userName, string password, string email, bool expected)
        {
            var actual = _validator.ValidateRegistration(userName, password, email);

            Assert.AreEqual(expected, actual);
        }
    }
}
