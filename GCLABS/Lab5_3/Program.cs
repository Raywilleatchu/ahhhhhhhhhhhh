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
        Toyota
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


        public override string ToString()
        {
            return base.ToString();
        }
    }



    class NewCar : Car
    {
        bool ExtendedWarranty;

        public NewCar()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }



    class UsedCar : Car
    {
        int NumberOfOwners;
        int Mileage;

        public UsedCar()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            bool cont = true;
            List <Car> myCars = new List<Car>();
            //Create Car Instances

            while (cont)
            {

            }

        }
    }
}
