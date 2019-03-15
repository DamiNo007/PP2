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
        public ConsoleKeyInfo keypress = new ConsoleKeyInfo();
        //public const int height = 30;
        //public const int width = 20;
        public void ShowBanner()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.CursorVisible = false;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                  WELCOME THE SNAKE GAME!!!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                      PRESS ANY KEY...");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                 - Use Arrows to move the snake ");
            Console.WriteLine("                                                 - Press S to pause");
            Console.WriteLine("                                                 - Press R to reset game ");
            Console.WriteLine("                                                 - Press ESC to quit game");
            Console.WriteLine();

            keypress = Console.ReadKey(true);
            if (keypress.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }

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

            Thread thread = new Thread(MoveSnake);
            thread.Start();

            while (isAlive && key.Key!= ConsoleKey.Escape)
            {
                key = Console.ReadKey();
                snake.SetUp(key);
            }
            Console.Clear();
            Console.SetCursorPosition(30, 30);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Game Over!!!");
            Console.SetCursorPosition(10, 12);
            Console.WriteLine("Your score is: " + score);
            Console.ReadKey();
        }

        public void MoveSnake()
        {
            while (isAlive)
            {
                snake.Move();
                if (snake.IsCollision(food))
                {
                    score += 10;
                    snake.body.Add(new Point(0, 0));
                    while (food.IsCollision(snake) || food.IsCollision(wall))
                        food.Generate();

                    if (snake.body.Count % 5 == 0)
                        wall.NextLevel();
                }

                if (snake.IsCollision(wall))
                {
                    isAlive = false;
                }
                        Draw();

                Thread.Sleep(50);
            }

        }
    }
}
