using System;
using System.Collections.Generic;

namespace Practice_Assessment_4
{
    class Program
    {

        enum Status
        {
            Student = 1,
            GradStudent = 2
        }

        class Student
        {
            protected string name;
            protected Status status;
            protected List<int> scores { get; set; }
            protected char grade;

            public Student(string _name, Status _status)
            {
                Name = _name;
                Status = _status;
                Scores = new List<int>();
                
            }

            public Student()
            {

            }

            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }

            public Status Status
            {
                get
                {
                    return status;
                }
                set
                {
                    status = value;
                }
            }

            public List<int> Scores
            {
                get
                {
                    return scores;
                }

                set
                {
                    scores = value;
                }
            }

            public virtual char Grade
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < scores.Count; i++)
                    {
                        sum = sum + scores[i];
                    }

                    int average = sum / scores.Count;

                    if (average >= 90)
                    {
                        return 'a';
                    }
                    else if (average >= 80)
                    {
                        return 'b';
                    }
                    else if (average >= 70)
                    {
                        return 'c';
                    }
                    else if (average >= 60)
                    {
                        return 'd';
                    }
                    else
                    {
                        return 'e';
                    }
                }

                set
                {
                    grade = value;
                }
            }
        }


        class GradStudent : Student
        {
            public List<Student> students { get; set; }
            public GradStudent(string _name, Status _status) : base(_name, _status)
            {
                students = new List<Student>();
            }

            public override char Grade
            {
                get
                {
                    char currentGrade;
                    int sum = 0;
                    for (int i = 0; i < scores.Count; i++)
                    {
                        sum = sum + scores[i];
                    }

                    int average = sum / scores.Count;

                    if (average >= 90)
                    {
                        currentGrade = 'a';
                    }
                    else if (average >= 80)
                    {
                        currentGrade = 'b';
                    }
                    else if (average >= 70)
                    {
                        currentGrade = 'c';
                    }
                    else if (average >= 60)
                    {
                        currentGrade =  'd';
                    }
                    else
                    {
                        currentGrade = 'e';
                    }

                    int tally = 0;
                    foreach (var student in students)
                    {
                        if (student.Grade == 'a')
                        {
                            tally += 10;
                        }
                        else if (student.Grade == 'b')
                        {
                            tally += 9;
                        }
                        else if (student.Grade == 'c')
                        {
                            tally += 7;
                        }
                        else if (student.Grade == 'd')
                        {
                            tally += 6;
                        }
                    }

                    if (currentGrade == 'a' && tally >= 7 || currentGrade == 'b' && tally >= 7 || currentGrade == 'c' && tally >= 7)
                    {
                        return 'a';
                    }
                    else
                    {
                        return 'e';
                    }
                }
                set
                {
                    grade = value;
                }
            }

            public void ScoreAStudent()
            {

                Student studentToGrade = new Student();
                Console.Write("Enter Student's Name: ");
                string studentName = Console.ReadLine();
                foreach (var student in students)
                {
                    if (student.Name == studentName)
                    {
                        studentToGrade = student;
                        break;
                    }
                }
                Console.WriteLine($"What did {studentToGrade.Name} score?");
                int recentScore = int.Parse(Console.ReadLine());
                studentToGrade.Scores.Add(recentScore);
            }
        }




        static void Main(string[] args)
        {
            GradStudent knob = new GradStudent("Knob Knoknert", Status.GradStudent);
            Student bob = new Student("Bob Bobbert", Status.Student);
            Student rob = new Student("Rob Rorrert", Status.Student);
            List<Student> allStudents = new List<Student>() {knob, bob, rob };
            bob.Scores.Add(90);
            bob.Scores.Add(82);
            rob.Scores.Add(77);
            rob.Scores.Add(97);
            knob.Scores.Add(90);
            knob.Scores.Add(100);
            knob.students.Add(rob);
            knob.students.Add(bob);
            bool cont = true;

            while (cont)
            {
                GradStudent temp;
                Console.Write("Please enter a student's Full or First name: ");
                string nameInput = Console.ReadLine();
                foreach (var student in allStudents)
                {
                    cont = true;
                    if (student.Name.StartsWith(nameInput) || student.Name == nameInput)
                    {
                        if (student.Status == Status.Student)
                        {
                            Console.Write($"Scores: ");
                            foreach (var score in student.Scores)
                            {
                                Console.Write($" {score} ");
                            }
                            Console.WriteLine();
                            Console.WriteLine($"Current Final Grade: {student.Grade}");
                            //Console.Write("\nReturn to login? (Y/N): ");
                            //string back = Console.ReadLine().ToLower();
                            //if (back == "y")
                            //{
                            //    break;
                            //}
                            //else if (back == "n")
                            //{
                            //    cont = false;
                            //    break;
                            //}
                        }
                        else if (student.Status == Status.GradStudent)
                        {
                            temp = (GradStudent)student;
                            Console.WriteLine("Would you like to view a report card(1), or grade a student(2)?");
                            int choice = int.Parse(Console.ReadLine());
                            if (choice == 1)
                            {
                                Console.WriteLine("Provide a students name or type \"All\" to view all");
                                string input = Console.ReadLine().ToLower();
                                if (input == "all")
                                {
                                    foreach(var s in temp.students)
                                    {
                                        Console.Write($"{s.Name}: ");
                                        foreach (var score in s.Scores)
                                        {
                                            Console.Write($" {score} ");
                                        }
                                        Console.WriteLine();
                                        Console.WriteLine($"Current Final Grade: {s.Grade}");
                                    }
                                }
                                else if (input != "all")
                                {
                                    foreach (var s in temp.students)
                                    {
                                        //Console.WriteLine($"Student: {s.Name}");
                                        if (s.Name.ToLower().StartsWith(input) || s.Name.ToLower() == input)
                                        {
                                            Console.WriteLine(s.Name);
                                            Console.Write($"Scores: ");
                                            foreach (var score in student.Scores)
                                            {
                                                Console.Write($" {score} ");
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine($"Current Final Grade: {student.Grade}");
                                        }
                                    }
                                }
                            }
                            else if (choice == 2)
                            {
                                bool menuStay = true;
                                while (menuStay)
                                {
                                    Console.Write("What student would you like to grade?: ");
                                    string input = Console.ReadLine();
                                    foreach (var s in temp.students)
                                    {
                                        if (s.Name.StartsWith(input) || s.Name == input)
                                        {
                                            Console.WriteLine($"What score did {s.Name} recieve?");
                                            int score = int.Parse(Console.ReadLine());
                                            s.Scores.Add(score);
                                            Console.WriteLine($"Score sumbitted to grade book for {s.Name}");
                                            break;
                                        }
                                    }
                                    Console.Write("Grade Another? (Y/N): ");
                                    string yn = Console.ReadLine().ToLower();
                                    if (yn == "y")
                                    {
                                        menuStay = true;
                                    }
                                    else if (yn == "n")
                                    {
                                        menuStay = false;
                                    }
                                }
                            }   
                        }
                    }
                }
                Console.Write("Return to Login? (Y/N): ");
                string yn2 = Console.ReadLine().ToLower();
                if (yn2 == "y")
                {
                    cont = true;
                }
                else if (yn2 == "n")
                {
                    cont = false;
                }
            }
        }
    }
}
