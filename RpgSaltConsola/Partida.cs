using System;

namespace RpgSaltConsola
{
    public class Partida
    {
        /*-----ATRIBUTOS-----*/
        Personaje personaje;


        /*-----CONSTRUCTORES-----*/
        public Partida(Personaje p)
        {
            personaje = p;
        }

        /*-----MÉTODOS----*/

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Aqui comienza el juego");
            Console.ReadLine();
        }
    }
}
