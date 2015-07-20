using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace RpgSaltConsola
{
    public class Serializador
    {
        private static string ruta = @"..\..\datos\datos.dat";

        public static void Guardar (ClaseAGuardar c)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(ruta, FileMode.Create, FileAccess.Write
                , FileShare.None);
            formatter.Serialize(stream, c);
            stream.Close();
        }


        public static ClaseAGuardar Cargar ()
        {
            ClaseAGuardar c = null;

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(ruta, FileMode.Open, FileAccess.Read
                , FileShare.Read);
            c = (ClaseAGuardar)formatter.Deserialize(stream);
            stream.Close();

            return c;
        }
    }
}
