using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake:GameObject
    {
        public string dir, pre_dir;
        public Snake(int x, int y, char sign, ConsoleColor color) : base(x, y, sign, color) { }

        public void SetUp(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow)
            {
                pre_dir = dir;
                dir = "UP";
                Move(dir);
            }

            if (key.Key == ConsoleKey.DownArrow)
            {
                pre_dir = dir;
                dir = "DOWN";
                Move(dir);
            }
            if (key.Key == ConsoleKey.RightArrow)
            {
                pre_dir = dir;
                dir = "RIGHT";
                Move(dir);
            }
                
            if (key.Key == ConsoleKey.LeftArrow)
            {
                pre_dir = dir;
                dir = "LEFT";
                Move(dir);
            }
                
        }

        public void Move(string dir)
        {
            for(int i = body.Count -1; i>0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            if(dir=="UP")
                body[0].y--;
            if (dir == "DOWN")
                body[0].y++;
            if (dir == "RIGHT")
                body[0].x++;
            if (dir == "LEFT")
                body[0].x--;

            }
         }
            
 }

 
