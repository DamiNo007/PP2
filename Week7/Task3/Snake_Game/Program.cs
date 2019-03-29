using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Snake_Game
{
    public class Program
    {
        public const int height = 23;
        public const int width = 65;
 
        static void Main(string[] args)
        {
            Console.SetWindowSize(width, height+6);
            Console.Clear();

            Game game = new Game();
            game.Start();
            

            Console.ReadKey();
        }
    }
}
