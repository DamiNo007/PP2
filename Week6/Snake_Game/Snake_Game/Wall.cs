using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake_Game
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
            Console.Clear();

            body = new List<Point>();
            string fileName = "Level1.txt";

            if (gameLevel == GameLevel.SECOND)
                fileName = "Level2.txt";
            if (gameLevel == GameLevel.THIRD)
                fileName = "Level3.txt";

            StreamReader sr = new StreamReader(Path.Combine(@"C: \Users\User\PP2\Week6\Snake_Game\Snake_Game",fileName));
            string[] rows = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    if (rows[i][j] == '#')
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
