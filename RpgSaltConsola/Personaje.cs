using System;
using System.Collections.Generic;

namespace RpgSaltConsola
{
    [Serializable]
    public class Personaje
    {
        /*-----ATRIBUTOS-----*/
        private string nombre;
        private string sexo;

        private int fuerza;
        private int destreza;
        private int inteligencia;
        private int constitucion;

        private int vida;
        private int vidaMax;
        private int ataque;
        private int defensa;
        private int nivel;

        private List<Tuple<string, int>> items = new List<Tuple<string, int>>();
        
        /*-----CONSTRUCTORES-----*/
        public Personaje(string nombre, string sexo, int fuerza, int destreza
            , int inteligencia, int constitucion, int vida, int ataque
            , int defensa, int nivel = 1)
        {
            this.nombre = nombre;
            this.sexo = sexo;
            this.fuerza = fuerza;
            this.destreza = destreza;
            this.inteligencia = inteligencia;
            this.constitucion = constitucion;
            this.vida = vida;
            this.ataque = ataque;
            this.defensa = defensa;
            this.nivel = nivel;

            vidaMax = constitucion * 10;
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
