using System;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace RandomPasswordGenerator
{
    public static class WeakPasswordGenerator
    {
        private static readonly StringBuilder _password = new StringBuilder();
        private static readonly RNGCryptoServiceProvider _rngSeed = new RNGCryptoServiceProvider();
        private static readonly PasswordDictionaries _passwordDictionaries = new PasswordDictionaries();
        private static readonly Random _randomDigit = new Random();

        public static SecureString ReturnWeakPassword()
        {
            GetWord();
            GetDigits();
            GetSpecialCharacter();

            return _password.ToString().ToSecureString();
        }

        private static void GetWord()
        {
            var randomNumber = new byte[1];
            _rngSeed.GetBytes(randomNumber);

            var passwordWord =
                _passwordDictionaries.PasswordList[randomNumber[0] % _passwordDictionaries.PasswordList.Count];

            passwordWord = char.ToUpper(passwordWord[0]) + passwordWord.Substring(1);

            _password.Append(passwordWord);
        }

        private static void GetDigits()
        {
            var passwordDigits = new int[3];

            for (var i = 0; i <= 2; i++)
            {
                passwordDigits[i] = _randomDigit.Next(0, 9);
            }

            _password.Append(passwordDigits.Aggregate(string.Empty, (s, i) => s + i.ToString()));
        }

        private static void GetSpecialCharacter()
        {
            const string symbols = "#@%&*$";
            var randomDigit = _randomDigit.Next(0, 5);
            _password.Append(symbols[randomDigit]);
        }
    }
}
