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
            List<int> list = new List<int>(); // Создаем динамический массив в который будем закидывать дублированные элементы массива a

            for (int i = 0; i < a.Length; i++)
            {
                list.Add(a[i]); // Добавляем в новый массив элементы массива а по два раза
                list.Add(a[i]);
            }

            foreach(int k in list)
            {
                Console.Write(k+" "); //Выводим элементы динамического массива
            }
        }

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

            NewArr(a, n); //Вызываем функцию, которая выведет элементы динамического массива

            Console.ReadKey();
        }
    }
 } 

