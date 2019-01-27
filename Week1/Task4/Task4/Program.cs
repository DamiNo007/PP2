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
            int n = int.Parse(Console.ReadLine()); // Вводим размер массива
            string[,] a = new string[n, n]; // Выделяем места в памяти для двумерного массива
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j || i > j) a[i, j] = "[*]"; // Если данное условие совпадает, то элементу массива присваиваем "[*]"
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i, j]); // Выводим двумерный массив
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
