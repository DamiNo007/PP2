using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
    public class Snake:GameObject
    {
        enum Direction
        {
            NONE,
            RIGHT,
            LEFT,
            UP,
            DOWN
        }

        Direction dir = Direction.NONE;

        public Snake(int x, int y, char sign, ConsoleColor color) : base(x, y, sign, color) { }
        
        public void SetUp(ConsoleKeyInfo key)
        {
            if(key.Key == ConsoleKey.UpArrow)
                dir = Direction.UP;

            if(key.Key == ConsoleKey.DownArrow)
                dir = Direction.DOWN;

            if (key.Key == ConsoleKey.RightArrow)
                dir = Direction.RIGHT;

            if (key.Key == ConsoleKey.LeftArrow)
                dir = Direction.LEFT;
        }

        public void Move()
        {
            if (dir == Direction.NONE)
                return;
            for(int i = body.Count-1; i>0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            if (dir == Direction.UP)
                body[0].y--;
            if (dir == Direction.DOWN)
                body[0].y++;
            if (dir == Direction.RIGHT)
                body[0].x++;
            if (dir == Direction.LEFT)
                body[0].x--;
        }

    }
}
