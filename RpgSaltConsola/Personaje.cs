using System;


namespace RpgSaltConsola
{
    [Serializable]
    public class Personaje
    {
        private string nombre;
        private string sexo;

        private int fuerza;
        private int destreza;
        private int inteligencia;
        private int constitucion;

        private int vida;
        private int ataque;
        private int defensa;

        public Personaje(string nombre, string sexo, int fuerza, int destreza
            , int inteligencia, int constitucion, int vida, int ataque
            , int defensa)
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
        }
    }
}
