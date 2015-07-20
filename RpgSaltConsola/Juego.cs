using System;

namespace RpgSaltConsola
{
    public class Juego
    {
        public Juego()
        {
            Console.Clear();
            Console.CursorVisible = false;
        }

        public void Run()
        {
            Bienvenida.Instancia.Lanzar();
            
            if(Bienvenida.NuevaPartida)
            {
                Introduccion a = new Introduccion();
                a.Run();
            }
            else
            {

            }
        }

        public static void Main(string[] args)
        {         
            Juego juego = new Juego();
            juego.Run();

            Console.ResetColor();
        }
    }
}
