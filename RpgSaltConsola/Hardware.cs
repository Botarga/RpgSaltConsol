﻿using System;
using System.Media;

namespace RpgSaltConsola
{
    public class Hardware
    {
        public static string SEPARATOR = "" + System.IO.Path.DirectorySeparatorChar;
        public static string ROOT_PATH = ".." + SEPARATOR + ".." + SEPARATOR;
        public static string DATA_PATH = ROOT_PATH + "datos" + SEPARATOR;
        public static string EFFECTS_PATH = ROOT_PATH + "efectos" + SEPARATOR;
        public static string ASCII_ART_PATH = ROOT_PATH + "arteAscii" + SEPARATOR;
        public static string BEEP_PATH = ROOT_PATH + "cancionBeep" + SEPARATOR;
        public static string MAZE_DATA_PATH = DATA_PATH + "mazes.dat";
        public static string NL = Environment.NewLine;

        public static SoundPlayer cursorAtras = new SoundPlayer(EFFECTS_PATH + "cursorAtras.wav");
        private static Random gen = new Random();

        public static int GetRandom(int min, int max)
        {
            int difference = max - min;
            int n = gen.Next() % (difference + 1);
            return n + min;
        }

        public static void BorrarLinea (int linea)
        {
            Console.SetCursorPosition(0, linea);
            for (int i = 0; i < 80; i++)
                Console.Write(" ");
        }
    

        public static void SalvarLinea (int x)
        {
            for(int i = 0; i < Console.BufferHeight; i++)
            {
                if (i == x)
                    continue;
                for(int j = 0; j < Console.BufferWidth; j++)
                    Console.Write(" ");
            }
        }


        public static string LeerString()
        {
            string linea = null;

            try
            {
                do
                {
                    linea = Console.ReadLine();
                } while (linea == "");
            }
            catch(Exception)
            {
            }

            return linea;
        }


        public static int LeerEntero()
        {
            int n;
            
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception)
            {
                n = -1;
            }

            return n;
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
