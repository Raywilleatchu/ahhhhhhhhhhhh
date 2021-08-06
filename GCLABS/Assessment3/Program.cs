using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment3
{
    class SiftMember
    {
        private string pName;
        private DateTime AnniversaryDate = new DateTime(); //Change to DateTime instead of string
        private string JobTitle;
        private string Email;
        public List<string> Skills = new List<string>();


        public SiftMember(string _Name, string _JobTitle, string _Email, DateTime _AnniversaryDate)
        {
            Name = _Name;
            AnniversaryDate = _AnniversaryDate;
            JobTitle = _JobTitle;
            Email = _Email;
        }

        public string Name
        {
            get
            {
                return pName;
            }
            set
            {
                pName = value;
            }
        }

        public List<string> GetSkills(List<string> _Skills)
        {
            return _Skills;
        }


        public void PrintSkills()
        {
            Console.WriteLine(string.Join(", ", Skills.ToArray()));
        }

        public bool AddSkill(string newSkill)
        {
            bool isEmpty = !Skills.Any();
            if (isEmpty)
            {
                Skills.Add(newSkill);
            }
            else 
            { 
                foreach(var Skill in Skills)
                {
                    if (Skill == newSkill)
                    {
                        Console.WriteLine("Skill already exists!");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Skill Added");
                        Skills.Add(newSkill);
                        return true;
                    }
                }
            }
            
            return true;
        }




        public override string ToString()
        {
            
            return $"{Name}" +
                    $"\nAnniversary: {AnniversaryDate}" +
                    $"\nJob Title: {JobTitle}" +
                    $"\nEmail: {Email}" +
                    $"\nSkills: {string.Join(",", Skills.ToArray())}";
        }
    }

    class Program
    {

        public static void AddMember(List<SiftMember> _members)
        {
            Console.WriteLine("===New Sift Member===");
            Console.Write("Name: ");
            string Name = Console.ReadLine();
            Console.Write("Job Title: ");
            string JobTitle = Console.ReadLine();
            Console.Write("Anniversary: ");
            DateTime Anniversary = DateTime.Parse(Console.ReadLine());
            Console.Write("Email: ");
            string Email = Console.ReadLine();
            SiftMember newMem = new SiftMember(Name, JobTitle, Email, Anniversary);
            Console.WriteLine("How many Skills would you like to add?");
            int skillNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < skillNum; i++)
            {
                Console.WriteLine($"Skill [{i+1}]: ");
                string skill = Console.ReadLine();
                newMem.AddSkill(skill);
            }
            _members.Add(newMem);

        }
        public static void SearchMember(List<SiftMember> members)
        {
            Console.Write("Name of Member: ");
            string name = Console.ReadLine();
            foreach (var member in members)
            {
                if (name == member.Name)
                {
                    Console.WriteLine($"Match found for {member.Name}");
                    Console.WriteLine("Would you like to add a skill?(Y/N)");
                    string yn = Console.ReadLine().ToLower();
                    if (yn == "y")
                    {
                        Console.WriteLine("How Many?");
                        int howMany = int.Parse(Console.ReadLine());
                        for (int i = 0; i < howMany; i++)
                        {
                            Console.WriteLine("Name of Skill(s)?");
                            string skill = Console.ReadLine();
                            if (!member.AddSkill(skill))
                            {
                                i--;
                            }

                        }
                    }
                    else if (yn == "n")
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Member not found..");
                }
            }
        }

        public static void ViewAll(List<SiftMember> members)
        {
            foreach (var member in members)
            {
                Console.WriteLine(member);
            }
        }


        static void Main(string[] args)
        {
            List<SiftMember> members = new List<SiftMember>();
            DateTime anni = new DateTime(2019, 10, 14);
            SiftMember m1 = new SiftMember("Ray", "Groomer", "null@null.null", anni);
            m1.AddSkill("Golfing");
            members.Add(m1);
            Console.WriteLine("Welcome to Console Sift!");
            Console.WriteLine("Enter one of the corresponding numbers to continue");
            //Console.WriteLine();
            //if ()
            //{

            //}


            //ViewAll(members);
            //AddMember(members);
            //SearchMember(members);
        }
    }
}
