using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgSaltConsola
{
    public class Maze
    {
        private static string[] MAZE_PATHS = {
            Hardware.DATA_PATH + "maze1.dat",
            Hardware.DATA_PATH + "maze2.dat",
            Hardware.DATA_PATH + "maze3.dat"
        };

        private string[][] mazeContent;

        public string[][] LoadMazeContent(string path)
        {
            string[][] r = new string[10][];


            return r;
        }

        public Maze(int index)
        {
            mazeContent = LoadMazeContent(MAZE_PATHS[index]);   
        }
    }
}
