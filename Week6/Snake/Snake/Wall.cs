using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Snake
{
    public class Wall:GameObject
    {
        enum GameLevel
        {
            FIRST,
            SECOND,
            THIRD
        }

        GameLevel gameLevel = GameLevel.FIRST;

        public Wall(char sign, ConsoleColor color) : base(0, 0, sign, color)
        {
            body = new List<Point>();
        }

        public void LoadLevel()
        {
            body = new List<Point>();
            string fileName = "level1.txt";
            if (gameLevel == GameLevel.SECOND)
                fileName = "level2.txt";
            if (gameLevel == GameLevel.THIRD)
                fileName = "level3.txt";

            StreamReader sr = new StreamReader(Path.Combine(@"C:\Users\User\PP2\Week6\Snake\Snake\",fileName));
            string[] rows = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    if (rows[i][j] == '*')
                        body.Add(new Point(j, i));
        }

        public void NextLevel()
        {
            if (gameLevel == GameLevel.FIRST)
                gameLevel = GameLevel.SECOND;
            else if (gameLevel == GameLevel.SECOND)
                gameLevel = GameLevel.THIRD;

            LoadLevel();
        }

    }
}
