using System;

namespace RpgSaltConsola
{
    public class Hardware
    { 
        public static void BorrarLinea (int linea)
        {
            Console.SetCursorPosition(0, linea);
            for (int i = 0; i < 80; i++)
                Console.Write(" ");
        }
    

        public static void SalvarLinea (int x)
        {
            for(int i = 0; i < Console.BufferHeight; i++)
            {
                if (i == x)
                    continue;
                for(int j = 0; j < Console.BufferWidth; j++)
                    Console.Write(" ");
            }
        }


        public static string LeerString()
        {
            string linea = null;

            try
            {
                do
                {
                    linea = Console.ReadLine();
                } while (linea == "");
            }
            catch(Exception)
            {
            }

            return linea;
        }


        public static int LeerEntero()
        {
            int n;
            
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception)
            {
                n = -1;
            }

            return n;
        }
    }
}
