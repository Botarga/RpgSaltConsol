using System;
                                                                               
namespace RpgSaltConsola
{
    public class Partida
    {
        /*-----ATRIBUTOS-----*/
        private ClaseAGuardar c;
        private bool[] posibilidadMovimiento = new bool[4];
        private bool exitGame = false;

        //Mapa del mundo
        private string[] mapa =
        {
            "mmMddddhhh",
            "m3mddddh2h",
            "MMMddddhhh",
            "cccccccc--",
            "cccccccc--",
            "-----cccc1",
            "cccc-l--cc",
            "PPPcccc-l-",
            "pppcccbbbb",
            "ppPzzbbbbb"
        };

        /*-----CONSTRUCTORES-----*/
        public Partida(Personaje p)
        {
            c = new ClaseAGuardar();
            c.Protagonista = p;
            c.X = 1;
            c.Y = 8;
        }

        /*-----MÉTODOS----*/
        public void MostrarInformacion()
        {
            Console.Clear();
            Console.WriteLine("Te encuentras en la casilla: {0} {1}", Convert.ToChar('A'+c.X)
                , c.Y + 1);

            Console.Write("Zona de: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            switch(mapa[c.Y][c.X])
            {
                case 'p':
                case 'P':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("EL PUEBLO");
                    break;

                case 'c':
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("EL CAMPO");
                    break;

                case 'z':
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("CEMENTERIO");
                    break;

                case 'b':
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("BOSQUE ENCANTADO");
                    break;

                case 'l':
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("PUENTE DEL RIO");
                    break;

                case 'd':
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("DESIERTO");
                    break;

                case 'h':
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("PICOS HELADOS");
                    break;

                case 'm':
                case 'M':
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("MONTAÑA DEL CAOS");
                    break;

                case '1':
                    Console.WriteLine("MAZMORRA DEL PESCADOR");
                    break;

                case '2':
                    Console.WriteLine("GUARIDA DEL HIELO");
                    break;

                case '3':
                    Console.WriteLine("TORRE DEL MARVAO");
                    break;

                default:
                    Console.WriteLine("ZONA DESCONOCIDA");
                    break;
            }

            Console.ResetColor();

            Console.WriteLine("Pudes mover hacia:");
            //Direcciones posibles para mover
            posibilidadMovimiento[0] = PosibleMoverCasilla(c.X, c.Y, c.X
                , c.Y - 1);
            posibilidadMovimiento[1] = PosibleMoverCasilla(c.X, c.Y, c.X + 1
                , c.Y);
            posibilidadMovimiento[2] = PosibleMoverCasilla(c.X, c.Y, c.X
                , c.Y + 1);
            posibilidadMovimiento[3] = PosibleMoverCasilla(c.X, c.Y, c.X - 1
                , c.Y);

            //Imprimir opciones
            if(posibilidadMovimiento[0])
                Console.Write("Norte = N\t");
            if (posibilidadMovimiento[1])
                Console.Write("Este = E\t");
            if (posibilidadMovimiento[2])
                Console.Write("Sur = S\t");
            if (posibilidadMovimiento[3])
                Console.Write("Oeste = O\t");

            Console.WriteLine("\nPulsa \"P\" para acceder al inventario");
            Console.WriteLine("Introduce una opcion...");
        }


        public bool PosibleMoverCasilla(int x, int y, int x2, int y2)
        {
            bool posible = true;

            //Comprobar distancia de mas de una casilla o en su diagonal
            if (Math.Abs(x - x2) + Math.Abs(y - y2) > 1)
                posible = false;
            //Comprobar casilla fuera de los límites del mapa
            else if (x2 < 0 || x2 >= mapa[y2].Length || y2 < 0 
                || y2 >= mapa.Length)
                posible = false;
            //Comprobar muros de letras mayusculas distintas a actual
            else if (Char.IsUpper(mapa[y2][x2]) && mapa[y2][x2] 
                    != Char.ToUpper(mapa[y][x]))
                posible = false;

            return posible;
        }

        
        private void ManageOption(string option)
        {
            switch(option.ToLower())
            {
                case "n":
                    break;
                case "s":
                    break;
                case "o":
                    break;
                case "e":
                    break;
                case "p":
                    Inventory inv = new Inventory();
                    inv.Run();

                    break;
                default:
                    break;

            }
        }

        public void Run()
        {
            while (!exitGame)
            {
                MostrarInformacion();
                ManageOption(Console.ReadLine());
            }
            
        }
    }
}
