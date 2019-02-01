using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // Size of array
            List<int> list = new List<int>(); // Creating a list (dynamic array) to which prime numbers will be added
            int[] a = new int[n]; // Creating an array

            string s = Console.ReadLine(); // entering the string
            string[] arr = s.Split(); // Deviding elements of the string to subelements and adding each subelement to array of strings
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(arr[i]); // Entering the elements of the array
            }

            foreach (int k in a)
            {
                bool flag = true; //Creating a bool variable for returning "true" if the number is prime and "false" if it is not prime
                if (k == 1) flag = false; // flag "false" because 1 is not a prime number
                for (int j = 2; j <= Math.Sqrt(k); j++)
                {
                    if (k % j == 0) flag = false; // if the number is divided by any other number(except 1 and itself) without remainder, hence it is not a prime 

                }

                if (flag == true) list.Add(k); // if an element of an array is prime, add it to the list 
            }

            Console.WriteLine(list.Count()); // Output the size of the list , i.e. the number of primes
            foreach (int m in list)
            {
                Console.Write(m + " "); // Outputing the elements of the list, i.e. primes
            }

            Console.ReadKey();
        }
    }
}
