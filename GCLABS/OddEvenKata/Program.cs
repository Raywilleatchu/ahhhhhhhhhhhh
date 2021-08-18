using System;

namespace OddEvenKata
{

    public class OddEven
    {

        public static bool IsPrime(int num)
        {
            if (num <= 1)
            {
                return false;
            }
            if (num == 2)
            {
                return true;
            }
            if (num % 2 == 0)
            {
                return false;
            }
            for (int i = 3; i <= Math.Sqrt(num); i += 2)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }


        public static string IsEven(int num)
        {
            string even = "Even";
            string odd = "Odd";
            string prime = "Prime";
            string evenOdd = " ";
            string result;
            if (num % 2 == 0)
            {
                evenOdd = even;
            }
            else if (num % 2 != 0)
            {
                evenOdd = odd;
                if (evenOdd == odd)
                {
                    if (IsPrime(num))
                    {
                        evenOdd = prime;
                    }
                }
            }

            if (evenOdd == even)
            {
                result = even;
            }
            else if (evenOdd == odd)
            {
                result = odd;
            }
            else if (evenOdd == prime)
            {
                result = prime;
            }
            else 
            {
                result = "Error";
            }

            if (num == 2)
            {
                result = "Prime";
            }
            return result;

        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            //
        }
    }
}
