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
            int n = int.Parse(Console.ReadLine()); // Задаем размерность массива
            List<int> list = new List<int>(); // Создаем лист, в который будем закидывать праймы
            int[] a = new int[n]; // создаем массив 

            string s = Console.ReadLine(); // вводим строку
            string[] arr = s.Split(); // разделяем элементы строки по пунктам
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(arr[i]); // Вводим элементы массива
            }

            foreach (int k in a)
            {
                bool flag = true; // Создаем булинговую переменную для определения прайм или нет
                if (k == 1) flag = false; // если элемент массива = 1 то flag равен false
                for (int j = 2; j <= Math.Sqrt(k); j++)
                {
                    if (k % j == 0) flag = false; // если число делится на какое-то другое число кроме 1 и самого себя, то flag = false, т.е. это не прайм

                }

                if (flag == true) list.Add(k); // если элемент массива это прайм, то добавляем его в лист
            }

            Console.WriteLine(list.Count()); // Выводим размер листа, т.е. количество праймов
            foreach (int m in list)
            {
                Console.Write(m + " "); // Выводим элементы листа, т.е. сами праймы
            }

            Console.ReadKey();
        }
    }
}
