using System;

namespace DiamondLetters
{
    public class Diamond
    {
        public static int LetterIndex(string letter)
        {
            return (int)(letter[0]) - 65;
        }


        public static int CalculateDots(int letterIndex)
        {
            return 2 * letterIndex - 1;
        }


        public static string DrawLine(string letter, string current)
        {
            if (letter == "A" && current == "A")
            {
                return "A";
            }

            int total = CalculateDots(LetterIndex(letter));
            int middle = CalculateDots(LetterIndex(current));

            int padding = (total - middle) / 2;

            string result = new string('.', padding) + current + new string('.', middle) + current + new string('.', padding);

            if (current == "A")
            {
                padding++;
            }

            

            return result;
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
