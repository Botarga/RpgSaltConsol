using System;
using System.IO;
using System.Collections.Generic;

namespace RpgSaltConsola
{
    public class MapaAscii
    {
        List<string> contenido;
    

        public MapaAscii(string ruta)
        {
            contenido = new List<string>();
            CargarContenido(ruta);
        }


        public void CargarContenido(string ruta)
        {
            StreamReader reader = new StreamReader(ruta);
            string linea;

            do
            {
                linea = reader.ReadLine();
                if (linea != null)
                    contenido.Add(linea);
            } while (linea != null);

            reader.Close();
        }


        public void Pintar (int x, int y
                , ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;

            for (int i = 0; i < contenido.Count; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(contenido[i]);
            }
            Console.ResetColor();
        }
        
    }
}