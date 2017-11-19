using System;
using System.Media;
using System.IO;

namespace RpgSaltConsola
{
    public class Bienvenida
    {
        private static MapaAscii mapa;
        private static Cursor cursor;
        private static Bienvenida instancia;
        private static SoundPlayer errorCargar;
        public static SoundPlayer cargarExito;

        public static bool Terminado { get; set; }
        public static bool NuevaPartida { get; set; }
        public static bool CargarPartida { get; set; }

        /*-----CONSTRUCTORES-----*/
        private Bienvenida()
        {
            mapa = new MapaAscii(@"..\..\arteAscii\espada.txt");
            cursor = new Cursor(58, 20, 2, 2, 0);
            errorCargar = new SoundPlayer(@"..\..\efectos\cursorError.wav");
            cargarExito = new SoundPlayer(@"..\..\efectos\cargarExito.wav");
        }


        /*-----MÉTODOS-----*/
        public void Lanzar()
        {
            Terminado = false;
            PintarInterfaz();

            while(!Terminado)
            {
                if (cursor.GestionarEvento())
                {
                    cursor.Pintar();
                    if(cursor.Salida == true)
                    {
                        switch(cursor.OpcionActual)
                        {
                            case 0:
                                NuevaPartida = Terminado = true;
                                cargarExito.Play();
                                break;

                            case 1:
                                if (!File.Exists(@"..\..\datos\datos.dat"))
                                    errorCargar.Play();
                                else
                                {
                                    Terminado = CargarPartida = true;
                                    cargarExito.Play();
                                }
                                break;
                        }
                    }
                }

                System.Threading.Thread.Sleep(50);
            }
            System.Threading.Thread.Sleep(200);
        }


        public void PintarInterfaz()
        {
            mapa.Pintar(5, 2, ConsoleColor.Green);
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(60, 20);
            Console.WriteLine("Nueva partida");

            Console.SetCursorPosition(60, 22);
            Console.ForegroundColor = (File.Exists(@"..\..\datos\datos.dat")) ?
                ConsoleColor.DarkYellow : ConsoleColor.Red;
            Console.WriteLine("Cargar Partida");

            cursor.Pintar();
        }

        /*-----PROPIEDADES-----*/
        public static Bienvenida Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new Bienvenida();
                return instancia;
            }
        }
    }
}
