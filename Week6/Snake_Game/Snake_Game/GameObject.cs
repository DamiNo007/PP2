using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    public class GameObject
    {
        public const int height = 23;
        public const int width = 65;
        public List<Point> body;
        public char sign;
        public ConsoleColor color;
        
        public GameObject(int x, int y, char sign, ConsoleColor color)
        {
            body = new List<Point>();
            Point p = new Point(x, y);
            body.Add(p);

            this.sign = sign;
            this.color = color;
        }

        int temp_x;
        int temp_y;

        public void Draw_Snake(string username, int level, int score)
        {
            Console.ForegroundColor = color;
            for (int i =0; i<height; i++)
            {
                for(int j=0; j<width; j++)
                {
                    if(j==temp_x && i == temp_y)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(" ");
                    }
                   
                    for(int k=0; k<body.Count; k++)
                    {
                        if(j==body[0].x && i == body[0].y)
                        {
                            Console.SetCursorPosition(j, i);
                            Console.Write('O');
                        }

                        else if(j==body[k].x && i == body[k].y)
                        {
                                Console.SetCursorPosition(j, i);
                                Console.Write(sign);
                        }
                    }
                    
                }
            }
            temp_x = body[body.Count - 1].x;
            temp_y = body[body.Count - 1].y;

            Console.SetCursorPosition(16, 25);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("LEVEL: " + level + "   |  " + username + "  |   SCORE: " + score); 
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
 
                    foreach(Point p in body)
                    {
                        Console.CursorVisible = false;
                        Console.SetCursorPosition(p.x, p.y);
                        Console.Write(sign);
                    }
            
        }

        public bool isCollisionWithItself()
        {
            for (int i = 1; i < body.Count; i++)
            {
                if (body[0].x == body[i].x && body[0].y ==body[i].y)
                {
                        return true;
                }
            }

            return false;
        }

        public bool isCollision(GameObject obj)
        {
                foreach (Point p in obj.body)
                {
                    if (body[0].x == p.x && body[0].y == p.y)
                    {
                        return true;
                    }
                }

            return false;
        }
    }
}
