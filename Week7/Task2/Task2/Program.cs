using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task2
{
    public class myThread
    {
        Thread thr;
        public myThread(string name)
        {
            thr = new Thread(threadField);
            thr.Name = name;
        }

        public void Start()
        {
            thr.Start();
        }

        public void threadField()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + ": "+ (i+1));
                Thread.Sleep(0);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            myThread t1 = new myThread("Thread1");
            myThread t2 = new myThread("Thread2");
            myThread t3 = new myThread("Thread3");

            t1.Start();
            t2.Start();
            t3.Start();

            Console.ReadKey();
        }
    }
}
