using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        //A list to store the data from "input.txt"
        public static List<int> list = new List<int>();

        //A Method to check whether a number is prime or not
        public static bool Prime(int k)
        {
            if (k == 1) return false; // 1 is not prime => false
            
            //Cycle from 2 to square root of the number which is going to be checked 
            for (int j = 2; j <=Math.Sqrt(k); j++)
            {   // if this number is divided without remainder on any number from 2 to square from that number
                //then it is not a prime number
                if (k % j == 0) return false; 
            }

            //Otherwise it is prime
            return true;
        }

        //A Method to read from the file
        public static void Read()
        {
            //Using StreamReader to Read from "input.txt"
            StreamReader sr = new StreamReader(@"C:\Users\User\PP2\Week2\Task2\input.txt");

            //Creating an array of strings which stores the divided string taken from "input.txt"
            string[] str = sr.ReadLine().Split();

            for (int i = 0; i < str.Length; i++)
            {
                //each element from the array of strings is added to the list(dynamic array)
                list.Add(int.Parse(str[i]));
            }
            sr.Close();
        }

        //A Method to write to the file
        public static void Write()
        {
            //Using StreamWriter to Write to "output.txt"
            StreamWriter sw = File.AppendText(@"C:\Users\User\PP2\Week2\Task2\output.txt");

            //Cycle to run through the list
            foreach (int k in list)
            {
                if (Prime(k)) sw.Write(k + " "); //if an element is prime write it to the "output.txt" file
            }

            sw.Close();
        }

        static void Main(string[] args)
        {
            Read(); // Call the Read Method
            Write(); // Call the Write Method


            Console.ReadKey();

        }

    }
}
