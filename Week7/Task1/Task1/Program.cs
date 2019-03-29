using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task1
{

    class Program
    {

        static void Main(string[] args)
        {
            /*Thread t = Thread.CurrentThread;

            Console.WriteLine(t.Name);
            t.Name = "Main";
            Console.WriteLine(t.Name);
            Console.WriteLine(t.IsAlive);
            Console.WriteLine(t.Priority);
            Console.WriteLine(t.ThreadState);
            Console.WriteLine(Thread.GetDomain().FriendlyName); // Имя домена, т.е. файла в котором запущен тред
            Console.ReadKey();*/



            /* Thread t1 = new Thread(func);
             t1.Priority = ThreadPriority.Lowest;
             t1.Start();

             for (int i = 0; i < 10; i++)
             {
                 Console.WriteLine("Поток 1 выводит " + i);
                 Thread.Sleep(0);
             }
             Console.ReadKey();

         }

         static void func()
         {
             for (int i = 0; i < 10; i++)
             {
                 Console.WriteLine("Поток 2 выводит " + i);
                 Thread.Sleep(0);
             }
         }*/

            /*Thread t1 = new Thread(func);
            t1.Name = "T1";
            t1.Start();
            Thread t2 = new Thread(func);
            t2.Name = "T2";
            t2.Start();*/

            Thread[] threads = new Thread[3];
            for(int i =0; i<3; i++)
            {
                threads[i] = new Thread(func);
                threads[i].Name = "Thread" + i;
                threads[i].Start();
            }
            Console.ReadKey();
        }

        static void func()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Thread.Sleep(0);
            }
        }
    }
}
