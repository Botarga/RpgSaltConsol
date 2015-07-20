using System;
using System.IO;
using System.Collections.Generic;

namespace RpgSaltConsola
{
    public class CancionBeep
    {
        List<int[]> contenido;

        public CancionBeep(string ruta)
        {
            contenido = new List<int[]>();
            CargarContenido(ruta);
        }
    

        public void CargarContenido(string ruta)
        {
            string linea;
            string[] dat;
            int[] aux = new int[2];
            StreamReader reader = new StreamReader(ruta);

            do
            {
                if ((linea = reader.ReadLine())!= null)
                {
                    dat = linea.Split(' ');
                    aux[0] = Convert.ToInt32(dat[0]);
                    aux[1] = Convert.ToInt32(dat[1]);
                    contenido.Add((int[])aux.Clone());
                }
            } while (linea != null);

            reader.Close();
        }


        public void Reproducir ()
        {
            for (int i = 0; i < contenido.Count; i++)
                Console.Beep(contenido[i][0], contenido[i][1]);
            
        }
    }
}
