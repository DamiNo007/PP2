using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Implement a class Student. Student has a name, id and a year of study. Provide a constructor
with two parameters and create methods to access name, id and increment the year of study.*/

namespace Task2
{
    class Student         // Creating a class Student
    {
        public string name; // Creating global variables, i.e. name, id and year
        public string id;
        public int year; // "year" variable will not be sent to constructor as constructor has only two parameters
        // So year will be just outputed after name and id and each time it is outputed its value will increment by 1
        // By default "year" variable equals 1. It will be outputed 4 times as Bachelor includes only 4 years of study

        public Student(string name, string id) // Creating a constructor with two parameters, which will initialize an object
        {
            this.name = name; // Initialize variables. Use pointer "this" in order to make a compiler understand what to copy and where to copy
            this.id = id;
        }

        // Method 1 to access the name of the object
        public string getName()
        {
            return name;
        }

        // Method 2 to access the id 
        public string getID()
        {
            return id;
        }

        // Method 3 to access the year and increment it by 1
        public int getYear()
        {
            year++;  // year++ to increment year by 1 each time when it is outputed
            return year;
        }

        // Method for accessing the full info of the student
        public string getInfo()
        {
            return ("Name: " + getName() + "\nID: " + getID() + "\nYear: " + getYear());
        }

    }


    class Program
    {
        //Main Method
        static void Main(string[] args)
        {
            string name = Console.ReadLine(); // Input data
            string id = Console.ReadLine();
            Student st = new Student(name, id); // Creating an object and sending it to constructor
            // Creating a cycle to make an object be outputed 4 times and each time year to increase by 1
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
                Console.WriteLine(st.getInfo()); // Outputing the whole info about the student
                Console.WriteLine();
            }

            Console.ReadKey();

        }
    }
}
