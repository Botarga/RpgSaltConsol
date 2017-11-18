using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgSaltConsola
{
    class Inventory
    {
        Personaje character;
        Cursor c;
        public Inventory(Personaje p)
        {
            character = p;
            c = new Cursor(Console.BufferWidth / 2 , 4, 4, 3, 0);
            
        }

        public void Run()
        {
            bool exit = false;
            printMenu();
            c.Pintar();

            while (!exit)
            {
                if (c.GestionarEvento())
                {
                    c.Pintar();
                    switch (c.OpcionActual)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            exit = true;
                            break;
                    }
                }

            }
        }

        private void printMenu()
        {
            Console.ResetColor();
            Console.Clear();

            Console.SetCursorPosition(Console.BufferWidth / 2 - 5, 2);
            Console.WriteLine("INVENTARIO");
            int cont = 4;
            foreach (String opt in new string[] { "Items", "Armas", "Guardar partida", "Salir" })
            {
                Console.SetCursorPosition(Console.BufferWidth / 2 - 2, cont);
                Console.Write(opt);
                cont += 3;
            }
        }
    }
}
