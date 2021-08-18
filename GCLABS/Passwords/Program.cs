using System;
using System.Linq;


namespace Passwords
{
    public class Password
    {

        public static bool PasswordMaker(string pass)
        {
            if (pass == null)
            {
                return false;
            }
            if (pass.Count() <= 8)
            {
                return false;
            }

            int uppers = 0;
            int lowers = 0;
            int nums = 0;

            for (int i = 0; i < pass.Count(); i++)
            {
                if (Char.IsUpper(pass[i]))
                {
                    uppers++;
                }
                if (Char.IsLower(pass[i]))
                {
                    lowers++;
                }

                string forParse = pass.Substring(i);
                if (int.TryParse(forParse, out int result))
                {
                    nums++;
                }

            }
            if (uppers >= 1 && lowers >= 1 && nums >= 1)
            {
                return true;
            }
            return false;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
