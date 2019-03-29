using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Xml.Serialization;

namespace Snake_Game
{
    public class User
    {
        public string username;
        public int level;
        public int score;
        public User() { }
        public User(string username, int level, int score)
        {
            this.username = username;
            this.level = level;
            this.score = score;
        }
    }

    public class Game
    {
        public User user;
        List<GameObject> g_objects;
        public bool isAlive;
        public Wall wall;
        public Snake snake;
        public Food food;
        public bool GameOver = false;
        public bool NextLevel = false;
        public ConsoleKeyInfo key = new ConsoleKeyInfo();

        public void ShowMenu()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(20, 4);
            Console.WriteLine("WELCOME THE SNAKE GAME!!!");
            Console.SetCursorPosition(27, 6);
            Console.WriteLine("CONTROLS");
            Console.SetCursorPosition(19, 8);
            Console.WriteLine("- Use Arrows to move the snake ");
            Console.SetCursorPosition(19, 10);
            Console.WriteLine("- Press P to pause");
            Console.SetCursorPosition(19, 12);
            Console.WriteLine("- Press S to save");
            Console.SetCursorPosition(19, 14);
            Console.WriteLine("- Press R to reset game ");
            Console.SetCursorPosition(19, 16);
            Console.WriteLine("- Press ESC to quit game");
            Console.SetCursorPosition(20, 20);
            Console.WriteLine("PRESS ANY KEY AND ENJOY");
            Console.ReadKey();
        }

        public void DrawObj()
        {   
            foreach(GameObject g in g_objects)
            {
                if (g== wall || g==food)
                    g.Draw();
                else
                    g.Draw_Snake(user.username, user.level, user.score);

            }
        }

        public Game()
        {
            g_objects = new List<GameObject>();
            wall = new Wall('#', ConsoleColor.DarkYellow);
            snake = new Snake(10, 10, 'o', ConsoleColor.DarkGreen);
            food = new Food(10, 20, '@', ConsoleColor.Magenta);
            g_objects.Add(wall);
            g_objects.Add(snake);
            g_objects.Add(food);
            isAlive = true;
        }

        public void Start()
        {
            ShowMenu();
            Console.Clear();
            Console.Write("Enter username: ");
            user = new User(Console.ReadLine(), 1, 0);
            SetUp();
              
        }

        public void Save()
        {
            FileStream fs = new FileStream("Storage.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer ser = new XmlSerializer(typeof(User));
            ser.Serialize(fs, user);
            fs.Close();
            Console.SetCursorPosition(20, 16);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("(Your result is recorded!)");
            Console.ReadKey();
        }

        public void Pause()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(25, 8);
                Console.WriteLine("GAME PAUSED!!!");
                Console.SetCursorPosition(19, 10);
                Console.WriteLine("- Press C to continue");
                Console.SetCursorPosition(19, 12);
                Console.WriteLine("- Press S to save");
                Console.SetCursorPosition(19, 14);
                Console.WriteLine("- Press R to reset game ");
                Console.SetCursorPosition(19, 16);
                Console.WriteLine("- Press ESC to quit game");
                Console.ForegroundColor = ConsoleColor.Black;
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }

                if (key.Key == ConsoleKey.C)
                {
                    Console.Clear();
                    break;
                }

                if(key.Key == ConsoleKey.S)
                {
                    Console.Clear();
                    Save();
                    Console.Clear();
                    break;
                }
            }   
        }

        public void Reset()
        {

        }

        public void SetUp()
        {
            snake.body[0].x = 10;
            snake.body[0].y = 10;
            wall.LoadLevel();
            Console.Clear();           
            Thread thread = new Thread(MoveSnake);
            thread.Start();
           
            while (isAlive && key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey();
                snake.SetUp(key);
            }

            Console.Clear();
            
            Console.SetCursorPosition(28, 10);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("GAME OVER!!!");
            Console.SetCursorPosition(16, 13);
            Console.WriteLine("YOUR LEVEL IS: " + user.level + " | YOUR SCORE IS: "+user.score);
            Save();
            Console.ReadKey(); 
        }

        public void MoveSnake()
        {
            int k = 0;
            while (isAlive && key.Key != ConsoleKey.Escape)
            {
                if(key.Key == ConsoleKey.P)
                {
                    Pause();
                }
                
                if (snake.isCollision(food))
                {
                    NextLevel = false;
                    snake.body.Add(new Point(10,10));
                    user.score +=2;
                    while (food.isCollision(snake) || food.isCollision(wall))
                        food.Generate();
                }

                if (snake.isCollision(wall) || snake.isCollisionWithItself())
                {
                    GameOver = true;
                    isAlive = false;
                    break;
                }
                    
                if (snake.body.Count % 5 == 0 && !NextLevel)
                {
                    user.level++;              
                    wall.NextLevel();
                    NextLevel = true;
                }

                snake.Move();
                DrawObj();
                k++;
                Thread.Sleep(50);
            }

        }
            

    }
}
