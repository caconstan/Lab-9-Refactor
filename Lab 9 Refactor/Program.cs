using System;
using System.Collections.Generic;

namespace Lab_9_Refactor
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              C#.NET LAB 9: REFACTOR TO USE LISTS INSTEAD OF ARRAYS
             */
            string cont = "yes";
            List<StudentInfo> studentInfo2 = new List<StudentInfo> {
                new StudentInfo("Amanda", "Detroit", "vegan mac and cheese", "Female" ),
                new StudentInfo("Andres", "Midtown", "pizza", "Male" ),
                new StudentInfo("Anna", "Livonia", "carrot cake with goat cheese frosting", "Female" ),
                new StudentInfo("Christina", "Detroit", "spaghetti", "Female" ),
                new StudentInfo("Cody", "Madison Heights", "hamburgers", "Male" ),
                new StudentInfo("Delia", "Sterling Heights", "hot dogs", "Female" ),
                new StudentInfo("Deshawn", "Warren", "roast beef", "Male" ),
                new StudentInfo("Grace", "Eastpointe", "lobster", "Female" ),
                new StudentInfo("Jake", "Romulus", "whitefish", "Male" ),
                new StudentInfo("James", "Troy", "bbq chicken", "Male" ),
                new StudentInfo("Jesse", "Romeo", "tacos", "Male" ),
                new StudentInfo("Josh", "St. Clair Shores", "fajitas", "Male" ),
                new StudentInfo("Kendall", "Roseville", "french fries", "Male" ),
                new StudentInfo("Kyle", "Clinton Township", "lasagna", "Male" ),
                new StudentInfo("Michael", "Farmington", "pizza", "Male" ),
                new StudentInfo("Nathan", "Farmington Hills", "pizza", "Male" ),
                new StudentInfo("Peter", "Taylor", "pizza", "Male" ),
                new StudentInfo("Sierra", "Windsor", "pizza", "Female" ),
                new StudentInfo("Tommy", "Detroit", "pizza", "Male" ),
                new StudentInfo("Vibha", "Detroit", "pizza", "Female")
            };

            int studentnumber;

            Console.WriteLine("Welcome to our C# class.");

            while (cont.Equals("yes"))
            {

                Console.WriteLine("Which student would you like to learn more about? " +
                    "(enter the student number 1-20 or enter the student's name)");
                getStudentNumber(out studentnumber, studentInfo2);
                studentnumber--; // adjustment by 1 for our array indices
                getStudentInfo(studentnumber, studentInfo2);

                do
                {
                    Console.WriteLine("Would you like to know more? (enter “yes”, “no”, or “add” to add a new student)");
                    cont = Console.ReadLine();

                    if (cont.Equals("add"))
                    {
                        AddStudentInfo(studentInfo2);
                    }
                } while (cont.Equals("add"));
            }
            Console.WriteLine("Thanks!");
        }

        public static void AddStudentInfo(List<StudentInfo> studentInfo)
        {
            string name = "";
            string hometown = "";
            string favFood = "";
            string gender = "";

            while (name == "")
            {
                Console.WriteLine("Please enter the student name: ");
                name = Console.ReadLine();
            }
            while (hometown == "")
            {
                Console.WriteLine("Please enter the student's hometown: ");
                hometown = Console.ReadLine();
            }
            while (favFood == "")
            {
                Console.WriteLine("Please enter the student's favorite food: ");
                favFood = Console.ReadLine();
            }
            while (gender == "")
            {
                Console.WriteLine("Please enter the student's gender: ");
                gender = Console.ReadLine();
            }
            studentInfo.Add(new StudentInfo(name, hometown, favFood, gender));
        }

        public static void getStudentInfo(int studentnumber, List<StudentInfo> studentInfo)
        {
            Console.WriteLine("Student " + (studentnumber + 1) + " is " + studentInfo[studentnumber].name +
                ". What would you like to know about " + studentInfo[studentnumber].name + "? (enter “hometown”, “favorite food”, or “gender”): ");

            string selection = Console.ReadLine();

            while (selection != "hometown" && selection != "favorite food" && selection != "gender")
            {
                Console.WriteLine("That data does not exist. Please try again. (enter “hometown”, “favorite food”, or “gender”): ");
                selection = Console.ReadLine();
            }

            switch (selection)
            {
                case "hometown":
                    Console.Write(studentInfo[studentnumber].name + " is from " + studentInfo[studentnumber].hometown + ". ");
                    break;
                case "favorite food":
                    if (studentInfo[studentnumber].gender == "Male")
                        Console.Write(studentInfo[studentnumber].name + " says his favorite food is " + studentInfo[studentnumber].favFood + ". ");
                    else
                        Console.Write(studentInfo[studentnumber].name + " says her favorite food is " + studentInfo[studentnumber].favFood + ". ");
                    break;
                case "gender":
                    Console.Write(studentInfo[studentnumber].name + " identifies as " + studentInfo[studentnumber].gender + ". ");
                    break;
                default:
                    break;
            }
        }

        public static void getStudentNumber(out int studentnumber, List<StudentInfo> studentInfo)
        {
            string inputString = Console.ReadLine();

            try
            {
                studentnumber = int.Parse(inputString);
                string name = studentInfo[studentnumber - 1].name;
            }
            catch (FormatException)
            {
                for (int i = 0; i < studentInfo.Count; i++)
                {
                    if (inputString.Equals(studentInfo[i].name))
                    {
                        studentnumber = i + 1;// adjust again for array indices
                        return;
                    }
                }
                Console.WriteLine("I'm sorry, I didn't understand. Please enter the student number 1-20 or enter the student's name: ");
                getStudentNumber(out studentnumber, studentInfo);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("That student does not exist. Please enter the student number 1-20 or enter the student's name");
                getStudentNumber(out studentnumber, studentInfo);
            }
        }
    }

    class StudentInfo
    {
        public string name { get; set; }
        public string favFood { get; set; }
        public string hometown { get; set; }

        public string gender { get; set; }

        public StudentInfo(string sname, string scity, string sfood, string sgender)
        {
            name = sname;
            hometown = scity;
            favFood = sfood;
            gender = sgender;
        }
    }
}
