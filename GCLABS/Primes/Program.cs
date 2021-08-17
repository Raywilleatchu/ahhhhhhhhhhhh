using System;

namespace Primes
{
    public class Program
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


        public static int GetPrime(int n)
        {
            int countOfPrime = 0;
            int num = 2;
            while (true)
            {
                if (IsPrime(num))
                {
                    countOfPrime++;
                    if (countOfPrime == n) return num;
                }
                num++;
            }
        }


            static void Main(string[] args)
            {
                GetPrime(5);
            }
    }
}

