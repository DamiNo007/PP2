using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // Size of array
            string[,] a = new string[n, n]; // Allocate memory locations for two-dimentional array
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j || i > j) a[i, j] = "[*]"; //If this condition holds we assign to array this "[*]"
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i, j]); // Outputing the two-dimentional array
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
