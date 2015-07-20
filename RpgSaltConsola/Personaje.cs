using System;


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
    }
}
