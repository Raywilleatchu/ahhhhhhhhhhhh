using System;
using System.Collections.Generic;

namespace Lab5_3
{

    enum Make
    {
        Ford,
        Cheverolet,
        Chrysler,
        Honda,
        Toyota,
        BMW
    }

    class Car
    {
        //make sure its protected and not public after testing
        protected Make make;
        protected string model;
        protected int year;
        protected decimal price;
        

        public Car(Make _make, string _model, int _year, decimal _price)
        {
            make = _make;
            model = _model;
            year = _year;
            price = _price;
        }

        public Make Make
        {
            get
            {
                return make;
            }
            set
            {
                make = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        public override string ToString()
        {
            return $"This is a {year} {make} {model}. We are pricing it at {price}";
        }
    }



    class NewCar : Car
    {
        protected bool ExtendedWarranty;

        public NewCar(Make _nMake, string _nModel, int _nYear, decimal _nPrice, bool _nExtendedWarranty) : base(_nMake, _nModel, _nYear, _nPrice)
        {
            ExtendedWarranty = _nExtendedWarranty;
        }


        public override string ToString()
        {
            string warranty;
            if (ExtendedWarranty)
            {
                warranty = "includes a warranty";
            }
            else
            {
                warranty = "does not include a warranty";
            }
            return $"This is a {year} {make} {model}. We are pricing it at {price}. This car {warranty}";
        }
    }



    class UsedCar : Car
    {
        int NumberOfOwners;
        int Mileage;

        public UsedCar(Make _uMake, string _uModel, int _uYear, decimal _uPrice, int _uNumberOfOwners, int _uMileage) : base(_uMake, _uModel, _uYear, _uPrice)
        {
            NumberOfOwners = _uNumberOfOwners;
            Mileage = _uMileage;
        }

        public override string ToString()
        {
            return $"This is a {year} {make} {model}. We are pricing it at {price}. This car has had {NumberOfOwners} previous owners with a mileage of {Mileage}";
        }
    }



    class Program
    {
        public static Car AddCar()
        {

            Console.WriteLine("New or Used?");
            string input = Console.ReadLine();

            switch (input)
            {
                case "New":
                    Console.Write("Make: ");
                    string make = Console.ReadLine();
                    Console.Write("Model: ");
                    string model = Console.ReadLine();
                    Console.Write("Year: ");
                    int year = int.Parse(Console.ReadLine());
                    Console.Write("Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Console.Write("Warranty (Y/N): ");
                    string sWarranty = Console.ReadLine();
                    bool warranty;
                    if (sWarranty == "Y")
                    {
                        warranty = true;
                    }
                    else if (sWarranty == "N")
                    {
                        warranty = false;
                    }
                    else
                    {
                        warranty = false;
                    }
                    NewCar newCar = new NewCar((Make)Enum.Parse(typeof(Make), make), model, year, price, warranty);
                    return newCar;

                case "Used":
                    Console.Write("Make: ");
                    string make2 = Console.ReadLine();
                    Console.Write("Model: ");
                    string model2 = Console.ReadLine();
                    Console.Write("Year: ");
                    int year2 = int.Parse(Console.ReadLine());
                    Console.Write("Price: ");
                    decimal price2 = decimal.Parse(Console.ReadLine());
                    Console.Write("How many previous owners in total?: ");
                    int prevOwners = int.Parse(Console.ReadLine());
                    Console.Write("How many miles are recorded?: ");
                    int miles = int.Parse(Console.ReadLine());
                    UsedCar usedCar = new UsedCar((Make)Enum.Parse(typeof(Make), make2), model2, year2, price2, prevOwners, miles);
                    return usedCar;
            }
            return null;
        }

        static void Main(string[] args)
        {
            bool cont = true;
            List <Car> myCars = new List<Car>();
            //Create Car Instances
            NewCar nCar1 = new NewCar(Make.Cheverolet, "Camaro", 2022, 48000m, true);
            NewCar nCar2 = new NewCar(Make.Honda, "Civic", 2018, 32000m, false);
            NewCar nCar3 = new NewCar(Make.BMW, "i8", 2020, 58000m, true);
            UsedCar uCar1 = new UsedCar(Make.Chrysler, "300", 2012, 23000m, 3, 80000);
            UsedCar uCar2 = new UsedCar(Make.Toyota, "Camry", 2020, 38000m, 1, 30000);
            UsedCar uCar3 = new UsedCar(Make.Ford, "Focus", 2020, 30000m, 2, 35000);
            myCars.Add(nCar1);
            myCars.Add(nCar2);
            myCars.Add(nCar3);
            myCars.Add(uCar1);
            myCars.Add(uCar2);
            myCars.Add(uCar3);

            Console.WriteLine("Welcome to Ray's Cars & Such!");
            while (cont)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[P] : Purchase");
                Console.WriteLine("[A] : Add");
                Console.WriteLine("[Q] : Quit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "P":
                        Console.WriteLine("Cars in Stock"); 
                        int index = 1;
                        foreach (var car in myCars)
                        {
                            Console.WriteLine($"[{index}] {car}");
                            index++;
                        }
                        Console.WriteLine("\nPick a car to purchase or press Q to quit");
                        string choice = Console.ReadLine();
                        int nChoice; 
                        bool numOrString = int.TryParse(choice, out nChoice);
                        for (int i = 0; i < myCars.Count; i++)
                        {
                            if (nChoice - 1 == i)
                            {
                                Console.WriteLine($"Purchased {myCars[i].Make} {myCars[i].Model}!");
                                myCars.Remove(myCars[i]);
                                break;
                            }
                            else if (choice == "Q")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect Choice! Returning to Main Menu");
                                break;
                            }
                        }
                        break;

                    case "A":
                        myCars.Add(AddCar());
                        break;

                    case "Q":
                        Console.WriteLine("Farewell!");
                        cont = false;
                        break;

                    default:
                        break;
                }


            }

        }
    }
}
