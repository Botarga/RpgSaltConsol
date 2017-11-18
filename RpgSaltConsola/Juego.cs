using System;

namespace RpgSaltConsola
{
    public class Juego
    {
        public const bool NO_INTRO = true;

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
                Partida partida = new Partida(a.Run());
                partida.Run();
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
