using System;
using System.Globalization;
using System.Security;

namespace RandomPasswordGenerator
{
    public static class GetPassword
    {
        public static SecureString WeakPassword()
        {
            return WeakPasswordGenerator.ReturnWeakPassword();
        }

        public static SecureString StrongPassword()
        {
            Console.Write("\nEnter password length: ");

            var keyValue = Console.ReadLine();

            int.TryParse(keyValue, NumberStyles.Integer, CultureInfo.CurrentCulture, out var pwLength);

            if (pwLength <= 0) return null;

            var strongPassword = StrongPasswordGenerator.ReturnGoodPassword(pwLength);

            if (strongPassword == null)
                Console.WriteLine("\nPassword length does not meet minimum requirement of 8 characters.");

            return strongPassword;
        }
    }
}
