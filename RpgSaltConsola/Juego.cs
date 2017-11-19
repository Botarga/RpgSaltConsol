using System;
using System.Collections.Generic;
using System.IO;

namespace RpgSaltConsola
{
    public class Juego
    {
        public const bool NO_INTRO = true;
        public static Dictionary<string, Item> gameItem;

        public Juego()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Clear();
            Console.CursorVisible = false;
            LoadItemsData();

        }

        private void LoadItemsData()
        {
            gameItem = new Dictionary<string, Item>();
            string[] content = File.ReadAllText(@"..\..\datos\items.dat").Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach(string rawInfo in content)
            {
                string[] info = rawInfo.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string keyName = info[0];
                string name = info[1];
                string description = info[2];
                Item.ItemType type = Hardware.ParseEnum<Item.ItemType>(info[3]);

                string[] targetsData = info[4].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                Item.ItemTarget[] targets = new Item.ItemTarget[targetsData.Length];
                for(int i = 0; i < targets.Length; ++i)
                    targets[i] = Hardware.ParseEnum<Item.ItemTarget>(targetsData[i]);

                string[] bonusesData = info[5].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                int[] bonuses = new int[bonusesData.Length];
                for (int i = 0; i < bonusesData.Length; ++i)
                    bonuses[i] = Convert.ToInt32(bonusesData[i]);

                gameItem.Add(keyName,
                    new Item { Name = name, Description = description, Type = type, Target = targets, Bonus=bonuses});

            }
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
                ClaseAGuardar gameData = Serializador.Cargar();
                Partida partida = new Partida(gameData);
                partida.Run();
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
