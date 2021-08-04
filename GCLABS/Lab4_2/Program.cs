using System;
using System.Collections.Generic;

namespace Lab4_3
{
    class Customer
    {
        private string pCompany;
        private string pContactName;
        private string pContactEmail;
        private string pPhone;

        public Customer(string _Company, string _ContactName, string _ContactEmail, string _Phone)
        {
            Company = _Company;
            ContactName = _ContactName;
            ContactEmail = _ContactEmail;
            Phone = _Phone;
        }

        public string Company
        {
            get
            {
                return pCompany;
            }
            set
            {
                pCompany = value;
            }
        }

        public string ContactEmail
        {
            get
            {
                return pContactEmail;
            }
            set
            {
                pContactEmail = value;
            }
        }

        public string Phone
        {
            get
            {

                return pPhone;

            }
            set
            {
                pPhone = value;
            }
        }

        public string ContactName
        {
            get
            {
                return pContactName;
            }
            set
            {
                pContactName = value;
            }
        }

        public override string ToString()
        {
            return $"Company Name: {pCompany}\nContact:\n{pContactName}\n{pContactEmail}\n{pPhone}";
        }

    }
    class Program
    {

        public static void ListCustomers(List<Customer> _List)
        {
            foreach (Customer next in _List)
            {
                Console.WriteLine("======================");
                Console.WriteLine($"{next.ContactName}\t{next.Company}");
                Console.WriteLine("======================");
            }
        }

        public static Customer SearchCustomers(List<Customer> _List, string _Company)
        {
            foreach (Customer next in _List)
            {
                if (next.Company == _Company)
                {
                    return next;
                }
            }
            Console.WriteLine("No Customers Found");
            return null;
        }

        public static Customer BetterSearching(List<Customer> customers)
        {
            Console.WriteLine("Enter the Customer's Full Name, Email, Phone Number or Company Name:");
            string input = Console.ReadLine();
            foreach (Customer customer in customers)
            {
                if (customer.Company == input || customer.Phone == input || customer.ContactName == input || customer.ContactEmail == input)
                {
                    Console.WriteLine($"Found {customer.ContactName}\t{customer.Company}");
                    return customer;
                }

            }
            Console.WriteLine("No Matches");
            return null;
        }

        public static bool Continue()
        {
            bool val = true;
            Console.WriteLine("Would you like to go again?(y/n)");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                val = true;
            }
            else if (input == "n")
            {
                val = false;
            }
            return val;
        }

        static void Main(string[] args)
        {
            Customer c1 = new Customer("Rocket Financial", "Ray M", "RayM@rocketfinancial.com", "+1(313)724-9071");
            List<Customer> customers = new List<Customer>();
            customers.Add(c1);
            c1 = new Customer("Wells Embargo", "Jimmy TheKyd", "JimmyK@wembargo.com", "2342845278");
            customers.Add(c1);


            Console.WriteLine("\nSearchCustomers() Function");
            Customer readBack;
            Console.WriteLine("Please Enter Company Name: ");
            string input = Console.ReadLine();
            readBack = SearchCustomers(customers, input);
            if (readBack != null)
            {
                Console.WriteLine(readBack);
            }
            else
            {
                Console.WriteLine("Customer Does Not Exist In The System");
            }

            do
            {
                Console.WriteLine("\nBetterSearching() Function");
                BetterSearching(customers);
            }
            while (Continue());
        }
    }
}
