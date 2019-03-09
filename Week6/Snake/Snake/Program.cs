using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        //public const int height = 30;
        //public const int width = 20;

        static void Main(string[] args)
        {
            //Console.SetWindowSize(width, height + 6);
            Console.Clear();
            Game game = new Game();
            game.Start();
            Console.ReadKey();
        }
    }
}
