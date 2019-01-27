using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n]; // Создаем массив
            string s = Console.ReadLine(); // Вводим строку
            string[] arr = s.Split(); // Делим строку на пункты

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(arr[i]); // Присваиваем элементам массива введенные значения строки
            }

            foreach (int k in a)
            {
                Console.Write(k + " " + k + " "); // Выводим дублируя каждый элемент массива

            }
            Console.ReadKey();
        }
    }
}
