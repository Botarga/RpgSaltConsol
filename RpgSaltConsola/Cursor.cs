using System;
using System.Media;

namespace RpgSaltConsola
{
    public class Cursor
    {
        private static SoundPlayer cursorMover;
        private int numOpciones;
        private int distancia;
        private int opcionActual;
        private int x, y;
        private int antY;
        public bool Salida { get; set; }


        /*-----CONSTRUCTORES-----*/
        public Cursor(int x, int y, int numOpciones, int distancia = 1
            , int opcionActual = 0)
        {
            cursorMover = new SoundPlayer(Hardware.EFFECTS_PATH + "cursorMover.wav");
            this.x = x;
            this.y = y;
            this.numOpciones = numOpciones;
            this.distancia = distancia;
            this.opcionActual = opcionActual;
        }


        /*-----MÉTODOS-----*/
        public void Pintar()
        {
            //Borrar posición anterior
            Console.SetCursorPosition(x, antY);
            Console.Write(" ");

            //Pintar nueva
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x, y);
            Console.Write(">");
            Console.ResetColor();
        }


        public void MoverArriba()
        {
            if(opcionActual > 0)
            {
                antY = y;
                y -= distancia;
                opcionActual--;
                cursorMover.Play();
            }
        }


        public void MoverAbajo()
        {
            if (opcionActual < numOpciones - 1)
            {
                antY = y;
                y += distancia;
                opcionActual++;
                cursorMover.Play();
            }
        }


        public bool GestionarEvento()
        {
            bool eventoSucedido = Salida = false;

            if (Console.KeyAvailable)
            {
                eventoSucedido = true;
                ConsoleKeyInfo tecla = Console.ReadKey(true);

                if (tecla.Key == ConsoleKey.UpArrow)
                    MoverArriba();
                else if (tecla.Key == ConsoleKey.DownArrow)
                    MoverAbajo();
                else if (tecla.Key == ConsoleKey.Enter 
                        || tecla.Key == ConsoleKey.Spacebar)
                    Salida = true;
            }

            return eventoSucedido;
        }
    
        /*------PROPIEDADES-----*/
        public int OpcionActual { get { return opcionActual; } }
    }
}
