using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgSaltConsola
{

    public class Maze
    {
        private struct MazeIdentity
        {
            public char type;
            public int x;
            public int y;
            public bool activated;
        }

        private string[][] mazeContent;
        private MazeIdentity[][] staticIdentities;
        private MazeIdentity[][] enemies;
        private int currentFloor;
        private const int MARGIN_LEFT = 30;
        private const int MARGIN_TOP = 2;

        private MazeIdentity user;
        private int lastX, lastY;

        public Maze(int index)
        {
            mazeContent = LoadMazeContent(index);
            staticIdentities = new MazeIdentity[mazeContent.Length][];
            enemies = new MazeIdentity[mazeContent.Length][];
            currentFloor = 0;
            LoadUser();
        }

        private string[][] LoadMazeContent(int index)
        {
            string[][] r;

            StreamReader reader = new StreamReader(Hardware.MAZE_DATA_PATH);
            string line;
            while ((line = reader.ReadLine()) != null)
                if (line.StartsWith("" + index + ";"))
                    break;
            int nFloors = Convert.ToInt32(line.Split(';')[1]);
            r = new string[nFloors][];
            List<string> auxFloor = new List<string>();
            for (int i = 0; i < nFloors; ++i)
            {
                auxFloor.Clear();
                while ((line = reader.ReadLine()) != "")
                    auxFloor.Add(line.Replace("\"", ""));
                r[i] = auxFloor.ToArray();
            }

            reader.Close();

            return r;
        }


        public void Run()
        {
            bool exit = false;
            
            while (!exit)
            {
                LoadFloor(currentFloor);
    
            }
            
        }

        private void PrintMap()
        {
            for (int i = 0; i < mazeContent[currentFloor].Length; i++) {
                for (int j = 0; j < mazeContent[currentFloor][i].Length; j++){
                    ConsoleColor color;
                    switch (mazeContent[currentFloor][i][j])
                    {
                        case 'x':
                            color = ConsoleColor.Gray;
                            break;
                        case 'p':
                            color = ConsoleColor.Cyan;
                            break;
                        case 'l':
                            color = ConsoleColor.DarkYellow;
                            break;
                        case 'c':
                            color = ConsoleColor.Green;
                            break;
                        case 'L':
                            color = ConsoleColor.Yellow;
                            break;
                        
                        default:
                            color = ConsoleColor.White;
                            break;
                    }

                    Console.SetCursorPosition(MARGIN_LEFT + j, MARGIN_TOP + i);
                    Console.ForegroundColor = color;
                    Console.Write(mazeContent[currentFloor][i][j]);
                }
            }

            Console.ResetColor();
        }
        private void LoadUser()
        {
            for (int i = 0; i < mazeContent[currentFloor].Length; ++i) { 
                int index = mazeContent[currentFloor][i].IndexOf("7");
                if (index != -1){
                    user.x = index;
                    user.y = i;
                    user.type = 'o';
                    user.activated = true;
                    break;
                }
            }
        }

        private void LoadEntities()
        {
            List<MazeIdentity> lIdentities = new List<MazeIdentity>();
            List<MazeIdentity> lEnemies = new List<MazeIdentity>();
            Console.ResetColor();

            for (int i = 0; i < mazeContent[currentFloor].Length; i++)
            {
                for (int j = 0; j < mazeContent[currentFloor][i].Length; j++)
                {
                    MazeIdentity auxIdentity;

                    char mapCharacter = mazeContent[currentFloor][i][j];
                    if (mapCharacter == 'M' || mapCharacter == 'P' || mapCharacter == 'L')
                    {
                        auxIdentity.x = j;
                        auxIdentity.y = i;
                        auxIdentity.activated = false;
                        auxIdentity.type = mapCharacter;

                        if (mapCharacter == 'M')
                        {
                            lEnemies.Add(auxIdentity);
                            Console.SetCursorPosition(MARGIN_LEFT + j, MARGIN_TOP + i);
                            Console.Write(" ");
                        }
                        else
                            lIdentities.Add(auxIdentity);
                    }
                    else
                    {
                        mapCharacter = Char.ToLower(mapCharacter);

                        if (mapCharacter != 'x' && mapCharacter != ' ')
                        {
                            auxIdentity.x = j;
                            auxIdentity.y = i;
                            auxIdentity.activated = false;
                            auxIdentity.type = mapCharacter;

                            if (mapCharacter == 'm')
                            {
                                lEnemies.Add(auxIdentity);
                                Console.SetCursorPosition(MARGIN_LEFT + j, MARGIN_TOP + i);
                                Console.Write(" ");
                            }
                            else
                                lIdentities.Add(auxIdentity);
                        }
                    }
                }
            }

            staticIdentities[currentFloor] = lIdentities.ToArray();
            enemies[currentFloor] = lEnemies.ToArray();
        }

        private void PrintUser()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(MARGIN_LEFT + user.x, MARGIN_TOP + user.y);
            Console.Write("@");
        }

        private void ClearUser()
        {
            Console.SetCursorPosition(MARGIN_LEFT + user.x, MARGIN_TOP + user.y);
            Console.Write(" ");
        }

        private void LoadFloor(int n)
        {
            bool exit = false;

            Console.ResetColor();
            Console.Clear();

            PrintMap();
            LoadEntities();

            PrintUser();
            lastX = user.x;
            lastY = user.y;
            while (!exit)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    lastX = user.x;
                    lastY = user.y;
                    ClearUser();

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.W:
                            user.y--;
                            break;

                        case ConsoleKey.DownArrow:
                        case ConsoleKey.S:
                            user.y++;
                            break;

                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.A:
                            user.x--;
                            break;

                        case ConsoleKey.RightArrow:
                        case ConsoleKey.R:
                            user.x++;
                            break;
                    }
                }

                // Check collisions
                if (user.y >= mazeContent[currentFloor].Length ||
                    mazeContent[currentFloor][user.y][user.x] == 'x')
                {
                    user.y = lastY;
                    user.x = lastX;
                }

                // Draw
                PrintUser();
            }
        }
    }
}
