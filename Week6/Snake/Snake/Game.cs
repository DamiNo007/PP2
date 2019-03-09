using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; 

namespace Snake
{
   public class Game
    {
        List<GameObject> g_objects;
        public bool isAlive;
        public Snake snake;
        public Food food;
        public Wall wall;
        public int score=0;
        
        public void Draw()
        {
            Console.Clear();
            foreach (GameObject g in g_objects)
            {
                if (g == snake)
                {
                    g.Draw_Snake();
                }
                else
                    g.Draw();
            }
               
        }

        public Game()
        {
            g_objects = new List<GameObject>();
            snake = new Snake(0, 0, 'o',ConsoleColor.DarkGreen);
            food = new Food(10, 20, '@', ConsoleColor.Blue);
            wall = new Wall('#', ConsoleColor.White);
            wall.LoadLevel();
            g_objects.Add(snake);
            g_objects.Add(food);
            g_objects.Add(wall);
            isAlive = true;
            food.Generate();
        }

        public void Start()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            while(isAlive && key.Key!= ConsoleKey.Backspace)
            {
                Draw();
                key = Console.ReadKey();
                if (snake.IsCollision(food))
                { 
                    score+=10;
                    snake.body.Add(new Point(0, 0));
                    while (food.IsCollision(snake) || food.IsCollision(wall))  
                      food.Generate();

                    if (snake.body.Count % 10 == 0)
                        wall.NextLevel();
                }

                else if (snake.IsCollision(wall))
                {
                    isAlive = false;
                }
                
                snake.SetUp(key);
                
            }
            Console.Clear();
            Console.SetCursorPosition(10, 10);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Game Over!!!");
            Console.SetCursorPosition(10, 12);
            Console.WriteLine("Your score is: " + score);
            Console.ReadKey();
        }
    }
}
