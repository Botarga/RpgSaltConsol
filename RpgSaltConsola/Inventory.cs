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

        public Inventory(Personaje p)
        {
            character = p;

        }

        public void Run()
        {
            Console.ResetColor();
            Console.Clear();

            Console.SetCursorPosition(Console.BufferWidth / 2 - 5, 2);
            Console.WriteLine("INVENTARIO");
            int cont = 4;
            foreach (String opt in new string[]{ "1. Items", "2. Armas", "3. Guardar partida", "4. Salir"}){
                Console.SetCursorPosition(Console.BufferWidth / 2 - 10, cont);
                Console.Write(opt);
                cont += 3;
            }

            Console.ReadKey();
        }
    }
}
