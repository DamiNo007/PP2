using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        // Function which will make out from an array of integers another array of integers where each element is repeated 2 times
        public static void NewArr(int[] a, int n) 
        {
            List<int> list = new List<int>(); // Creating a list (dynamic array) to which dublicated elements of array "a" will be added

            for (int i = 0; i < a.Length; i++)
            {
                list.Add(a[i]); // Adding each element of array "a" to the list two times (so that they are dublicated)
                list.Add(a[i]);
            }

            foreach(int k in list)
            {
                Console.Write(k+" "); //Outputing the elements of the list
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n]; // Сreating an array
            string s = Console.ReadLine(); // Entering the string
            string[] arr = s.Split(); // Deviding the string into subelements and adding them to array of strings

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(arr[i]); // Assigning each element of array of strings to an ordinary array "a"
            }

            NewArr(a, n); //Calling the functions which will output the elements of the list

            Console.ReadKey();
        }
    }
 } 

