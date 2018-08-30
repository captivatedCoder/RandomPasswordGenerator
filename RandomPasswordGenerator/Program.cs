using System;
using System.Security;
using System.Windows.Forms;

namespace RandomPasswordGenerator
{
    public static class Program
    {

        private static SecureString _password;

        [STAThread]
        public static void Main(string[] args)
        {
            Console.WriteLine("What type of password do you need?");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("1. Weak passphrase");
            Console.WriteLine("2. Strong password");
            Console.WriteLine("----------------------------------");


            var input = Console.ReadKey(true).KeyChar;

            switch (input)
            {
                case '1':
                    _password = GetPassword.WeakPassword();
                    break;
                case '2':
                    _password = GetPassword.StrongPassword();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }

            if (string.IsNullOrEmpty(_password.ToInsecureString()))
            {
                Console.WriteLine("\nError creating password.\n\n");
            }
            else
            {
                Console.WriteLine($"\nYour password is: {_password.ToInsecureString()}");
                Clipboard.SetText(_password.ToInsecureString());
                Console.WriteLine("Password saved to clipboard\n\n");
            }

            Console.WriteLine("Press enter to close");
            Console.ReadKey();
        }


    }
}
