using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgSaltConsola
{
    class Inventory
    {
        ClaseAGuardar classRef;
        Cursor c;
        public Inventory(ClaseAGuardar classRef)
        {
            this.classRef = classRef;
            c = new Cursor(Console.BufferWidth / 2 -4, 4, 5, 3, 0);
            
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
                    if(c.Salida)
                    {
                        switch (c.OpcionActual)
                        {
                            case 0:
                                ShowStatus();
                                Console.ResetColor();
                                Console.Clear();
                                printMenu();
                                c.Pintar();
                                break;

                            case 1:
                                ShowItems();
                                Console.ResetColor();
                                Console.Clear();
                                printMenu();
                                c.Pintar();
                                break;

                            case 2:
                                ShowWeapons();
                                Console.ResetColor();
                                Console.Clear();
                                printMenu();
                                c.Pintar();
                                break;

                            case 3:
                                Serializador.Guardar(classRef);
                                Bienvenida.cargarExito.Play();
                                break;

                            case 4:
                                exit = true;
                                Hardware.cursorAtras.Play();
                                break;
                        }
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
            foreach (String opt in new string[] { "Estado", "Items", "Armas", "Guardar partida", "Salir" })
            {
                Console.SetCursorPosition(Console.BufferWidth / 2 - 2, cont);
                Console.Write(opt);
                cont += 3;
            }
        }

        private void ShowStatus()
        {
            Console.ResetColor();
            Console.Clear();

            var p = classRef.Protagonista;

            Console.WriteLine("ESTADO");
            Console.WriteLine("Arquetipo: {0}", p.arquetipo);
            Console.WriteLine("Nivel: {0}", p.nivel);
            Console.WriteLine("Vida: {0}/{1}", p.vida, p.vidaMax);
            Console.WriteLine("Ataque: {0}", p.ataque);
            Console.WriteLine("Defensa: {0}", p.defensa);

            Console.WriteLine(Hardware.NL + "DESTREZAS:");
            Console.WriteLine("Fuerza: {0}", p.fuerza);
            Console.WriteLine("Inteligencia: {0}", p.inteligencia);
            Console.WriteLine("Destreza: {0}", p.destreza);
            Console.WriteLine("Constitucion: {0}", p.constitucion);

            Console.WriteLine(Hardware.NL + "Pulsa INTRO para volver...");
            Console.ReadLine();
            Hardware.cursorAtras.Play();
        }

        private void ShowItems()
        {
            Console.ResetColor();
            Console.Clear();

            var items = classRef.Protagonista.GetItems();

            Console.SetCursorPosition(Console.BufferWidth / 2 - 3, 2);
            Console.Write("ITEMS");
            int itemCount = 0;
            List<int> itemsIds = new List<int>();
            for (int i = 0, line = 4; i < items.Count; ++i)
            {
                if (Juego.gameItem[items[i].Item1].Type != Item.ItemType.WEAPON)
                {
                    Console.SetCursorPosition(Console.BufferWidth / 2 -5, 4 + itemCount);
                    Console.Write("{0}: {1}", Juego.gameItem[items[i].Item1].Name,
                        items[i].Item2);
                    line ++;
                    itemCount++;
                    itemsIds.Add(i);
                }
            }
            Console.SetCursorPosition(Console.BufferWidth / 2 -5, 4 + itemCount);
            Console.Write("Volver");
            Cursor c = new Cursor(Console.BufferWidth / 2 -7, 4, itemCount +1, 1, 0);
            c.Pintar();

            Console.SetCursorPosition(10, Console.WindowHeight - 2);
            Console.Write(Juego.gameItem[items[itemsIds[c.OpcionActual]].Item1].Description);

            bool exit = false;
            while (!exit)
            {
                if(c.GestionarEvento())
                {
                    c.Pintar();
                    if (c.OpcionActual != itemCount)
                    {
                        Hardware.BorrarLinea(Console.WindowHeight - 2);
                        Console.SetCursorPosition(10, Console.WindowHeight - 2);
                        Console.Write(Juego.gameItem[items[itemsIds[c.OpcionActual]].Item1].Description);
                    }
                    else
                    {
                        Hardware.BorrarLinea(Console.WindowHeight - 2);
                    }
                    if (c.Salida)
                    {
                        if(c.OpcionActual == itemCount)
                            exit = true;
                        else
                        {
                            // Consumir item
                        }
                    }
                }
            }

            Hardware.cursorAtras.Play();
        }

        private void ShowWeapons()
        {
            Console.ResetColor();
            Console.Clear();

            var items = classRef.Protagonista.GetItems();

            Console.SetCursorPosition(Console.BufferWidth / 2 - 3, 2);
            Console.Write("ARMAS");
            int itemCount = 0;
            List<int> weaponsIds = new List<int>();

            for (int i = 0, line = 4; i < items.Count; ++i)
            {
                if (Juego.gameItem[items[i].Item1].Type == Item.ItemType.WEAPON)
                {
                    Console.SetCursorPosition(Console.BufferWidth / 2 - 5, 4 + itemCount);
                    Console.Write("{0}", Juego.gameItem[items[i].Item1].Name);
                    line++;
                    itemCount++;
                    weaponsIds.Add(i);
                }
            }
            Console.SetCursorPosition(Console.BufferWidth / 2 - 5, 4 + itemCount);
            Console.Write("Volver");
            Cursor c = new Cursor(Console.BufferWidth / 2 - 7, 4, itemCount + 1, 1, 0);
            c.Pintar();

            Console.SetCursorPosition(10, Console.WindowHeight - 2);
            Console.Write(Juego.gameItem[items[weaponsIds[c.OpcionActual]].Item1].Description);

            bool exit = false;
            while (!exit)
            {
                if (c.GestionarEvento())
                {
                    c.Pintar();
                    if (c.OpcionActual != itemCount)
                    {
                        Hardware.BorrarLinea(Console.WindowHeight - 2);
                        Console.SetCursorPosition(10, Console.WindowHeight - 2);
                        Console.Write(Juego.gameItem[items[weaponsIds[c.OpcionActual]].Item1].Description);
                    }
                    else
                    {
                        Hardware.BorrarLinea(Console.WindowHeight - 2);
                    }
                    if (c.Salida)
                    {
                        if (c.OpcionActual == itemCount)
                            exit = true;
                        else
                        {
                            // Consumir item
                        }
                    }
                }
            }

            Hardware.cursorAtras.Play();
        }
    }
}
