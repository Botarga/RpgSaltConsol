using System;
using System.Collections.Generic;

namespace RpgSaltConsola
{
    [Serializable]
    public class Personaje
    {
        /*-----ATRIBUTOS-----*/
        public string arquetipo;
        public int fuerza;
        public int destreza;
        public int inteligencia;
        public int constitucion;

        public int vida;
        public int vidaMax;
        public int ataque;
        public int defensa;
        public int nivel;

        public int[][] mazeKeys;

        private List<Tuple<string, int>> items = new List<Tuple<string, int>>();
        
        /*-----CONSTRUCTORES-----*/
        public Personaje(string arquetipo, string nombre, string sexo, int fuerza, int destreza
            , int inteligencia, int constitucion, int vida, int ataque
            , int defensa, int nivel = 1)
        {
            this.arquetipo = arquetipo;
            this.fuerza = fuerza;
            this.destreza = destreza;
            this.inteligencia = inteligencia;
            this.constitucion = constitucion;
            this.vida = vida;
            this.ataque = ataque;
            this.defensa = defensa;
            this.nivel = nivel;

            vidaMax = constitucion * 10;
            mazeKeys = new int[3][];
        }

        public void AddItem(string key, int quantity)
        {
            int index = items.FindIndex(i => i.Item1.CompareTo(key) == 0);
            if (index == -1)
                items.Add(new Tuple<string, int>(key, quantity));
            else
            {
                int current = items[index].Item2;
                items.RemoveAt(index);
                items.Add(new Tuple<string, int>(key, quantity + current));
            }
        }

        public void RemoveItem(string key, int quantity)
        {
            int index = items.FindIndex(i => i.Item1.CompareTo(key) == 0);
            if(index != -1)
            {
                int current = items[index].Item2;
                items.RemoveAt(index);
                items.Add(new Tuple<string, int>(key, quantity + current));
            }
        }

        public List<Tuple<string, int>> GetItems()
        {
            return items;
        }
    }
}
