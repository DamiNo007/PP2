using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.Clear();
            
            Game game = new Game();
            game.ShowBanner();
            game.Start();
            Console.ReadKey();
        }
    }
}
