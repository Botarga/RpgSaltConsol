using System;


namespace RpgSaltConsola
{
    [Serializable]
    public class ClaseAGuardar
    {
        public Personaje Protagonista { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

    }
}
