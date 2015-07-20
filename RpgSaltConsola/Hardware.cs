using System;

namespace RpgSaltConsola
{
    public class Hardware
    {
        private static Random generador = new Random(DateTime.Now.Millisecond);
        
        
        struct Estrella
        {
            public int x;
            public int y;
            public int incX;
            public int incY;
        }


        public static void TextoDecorado (string[] texto, int numEstrellas)
        {
            Estrella[] estrellas = new Estrella[numEstrellas];
            bool terminado = false;

            //Generar datos
            for (int i = 0; i < estrellas.Length; i++)
            {
                estrellas[i].x = generador.Next(0, 80);
                estrellas[i].y = generador.Next(0, 20);
                estrellas[i].incX = (generador.Next(0, 2) == 0) ? 1 : -1;
                estrellas[i].incY = (generador.Next(0, 2) == 0) ? 1 : -1;
            }

            //Bucle bolas con texto
            while(!terminado)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                for (int i = 0; i < estrellas.Length; i++)
                {
                    //Borrar e Incremento posición
                    Console.SetCursorPosition(estrellas[i].x, estrellas[i].y);
                    Console.Write(" ");
                    estrellas[i].x += estrellas[i].incX;
                    estrellas[i].y += estrellas[i].incY;
                    //Detectar colisión y rebote
                    if (estrellas[i].x < 0 || estrellas[i].x > 79)
                    {
                        estrellas[i].incX *= -1;
                        estrellas[i].x += estrellas[i].incX;
                    }
                    if (estrellas[i].y < 0 || estrellas[i].y > 22)
                    {
                        estrellas[i].incY *= -1;
                        estrellas[i].y += estrellas[i].incY;
                    }
                    //Pintar
                    Console.SetCursorPosition(estrellas[i].x, estrellas[i].y);
                    Console.Write("*");
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int i = 0; i < texto.Length; i++)
                {
                    Console.SetCursorPosition(20, 12 - (texto.Length / 2)+i);
                    Console.Write(texto[i]);
                }

                Console.SetCursorPosition(0, 23);
                Console.Write("Pulsa una tecla para continuar...");
                if (Console.KeyAvailable)
                {
                    Console.ReadKey();
                    terminado = true;
                }
                System.Threading.Thread.Sleep(20);
            }

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
    }
}
