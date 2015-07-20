using System;
using System.Threading;
using System.IO;

namespace RpgSaltConsola
{
    public class Introduccion
    {
        private static CancionBeep intro;
        private Thread hiloMusica;

        public Introduccion()
        {
            intro = new CancionBeep(@"..\..\cancionBeep\mainFF.txt");
            hiloMusica = new Thread(intro.Reproducir);
        }


        public void Run()
        {
            Console.Clear();
            hiloMusica.Start();
            MostrarMensajes();
            EleccionArquetipo();
            DistribucionParametros();
        }

        public void MostrarMensajes()
        {
            string[] texto = { "hola", "mundo", "tercera linea", "cuarta linea"
                                 , "5", "15", "23", "24"};
            Hardware.TextoDecorado(texto, 10);
            hiloMusica.Suspend();
            Console.ResetColor();
            Console.Clear();       
        }

        public void EleccionArquetipo()
        {
            string nombre, sexo, aux;
            string[] arquetipos = { "Guerrero", "Arquero", "Mago", "Botarga" };
            int opcion;
            bool terminado = false;

            Console.WriteLine("Introduce tu nombre: ");
            nombre = Hardware.LeerString();
            Console.WriteLine("Perteneces al sexo masculino/femenino?");
            sexo = Hardware.LeerString();

            do
            {
                Console.Clear();
                Console.SetCursorPosition(25, 0);
                Console.WriteLine("|Interfaz de eleccion de arquetipo|\n");

                Console.WriteLine("Selecciona tu arquetipo {0}\n\n", nombre);
                for (int i = 0; i < arquetipos.Length; i++)
                    Console.WriteLine("\t\t\t{0}. {1}\n\n", i + 1
                        , arquetipos[i]);

                do 
                { 
                    opcion = Hardware.LeerEntero(); 
                } while (opcion < 1 || opcion > arquetipos.Length);

                Console.Clear();
                Console.WriteLine("Seguro que quieres ser {0}?"
                    , arquetipos[opcion-1]);
                Console.WriteLine("s/n");
                do
                {
                    aux =Hardware.LeerString().ToLower();
                } while (aux.CompareTo("s") != 0 && aux.CompareTo("n") != 0);

                if (aux.CompareTo("s") == 0)
                {
                    Console.WriteLine("LLegaras a ser un gran {0} pues"
                        , arquetipos[opcion-1]);
                    terminado = true;
                }
                else
                {
                    Console.WriteLine("Medita bien tu eleccion...");
                    Console.ReadLine();
                }
            } while (!terminado);

            switch(opcion)
            {
                case 1:
                    Console.WriteLine("ARQUETIPO ARQUERO\n");
                    Console.WriteLine("El arquero es un soldado que dispara flechas con un arco,"+
                           "una varilla hecha de\nacero, madera u otra materia "+
                           "elastica sujeta por los extremos con una cuerda o  bordon,"+
                           "de modo que forme una curva");
                    Console.WriteLine("Son muy utiles atacando a distancias largas ademas de "+
                           "poseer una gran agilidad.\nLos arqueros son provenientes "+
                           "del bosque encantado al sureste de:\nLa tierra de Salt");
                    Console.WriteLine("Lucha con valentia contra las fuerzas canis y veras tu "+
                           "recompensa...");
                    Console.WriteLine("\nPULSA INTRO PARA CONTINUAR...");

                    break;

                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default: break;
            }
        }

    
        public void DistribucionParametros ()
        {
            int numPuntos = 10;
            int fuerza, destreza, inteligencia, constitucion;
            bool terminado = false;
            ConsoleKeyInfo tecla;

            fuerza = destreza = inteligencia = constitucion = 5;

            Console.Clear();
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("|Interfaz de distribución de parámetros|\n\n");

            Console.WriteLine("Distribuye tus puntos de desarrollo, para ello "
                + " debes de pulsar el numero \ncorrespondiente de aumentar o "
                + "disminuir puntuacion...");
            Console.WriteLine("Puntos Restantes: {0:D2}\n", numPuntos);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Aumentar\tParametro\tDisminuir\tTotal");
            Console.ResetColor();
            Console.WriteLine("   1    \t  Fuerza \t    2    \t {0:D2}", fuerza);
            Console.WriteLine("   3    \t Destreza\t    4    \t {0:D2}", destreza);
            Console.WriteLine("   5    \tInteligencia\t    6    \t {0:D2}", inteligencia);
            Console.WriteLine("   7    \tConstitución\t    8    \t {0:D2}", constitucion);

            Console.WriteLine("\nPulsa el numero correspondiente (9 para terminar)...");

            while (!terminado)
            {
                if (Console.KeyAvailable)
                {
                    tecla = Console.ReadKey(true);
                    switch(tecla.KeyChar)
                    {
                        case '1':
                            if (numPuntos > 0)
                            {
                                fuerza++;
                                numPuntos--;
                            }

                            break;

                        case '2':
                            if (fuerza > 0)
                            {
                                fuerza--;
                                numPuntos++;
                            }

                            break;

                        case '3':
                            if (numPuntos > 0)
                            {
                                destreza++;
                                numPuntos--;
                            }

                            break;

                        case '4':
                            if (destreza > 0)
                            {
                                destreza--;
                                numPuntos++;
                            }

                            break;

                        case '5':
                            if (numPuntos > 0)
                            {
                                inteligencia++;
                                numPuntos--;
                            }

                            break;

                        case '6':
                            if (inteligencia > 0)
                            {
                                inteligencia--;
                                numPuntos++;
                            }
                            break;

                        case '7':
                            if (numPuntos > 0)
                            {
                                constitucion++;
                                numPuntos--;
                            }

                            break;

                        case '8':
                            if(constitucion > 0)
                            {
                                constitucion--;
                                numPuntos++;
                            }
                            break;

                        case '9':
                            if (numPuntos <= 0)
                                terminado = true;
                            
                            break;

                        default: break;
                    }

                    Console.SetCursorPosition(18, 5);
                    Console.Write("{0:D2}",numPuntos);
                    Console.SetCursorPosition(49, 8);
                    Console.Write("{0:D2}", fuerza);
                    Console.SetCursorPosition(49, 9);
                    Console.Write("{0:D2}", destreza);
                    Console.SetCursorPosition(49, 10);
                    Console.Write("{0:D2}", inteligencia);
                    Console.SetCursorPosition(49, 11);
                    Console.Write("{0:D2}", constitucion);
                    
                }

                System.Threading.Thread.Sleep(30);
            }

        }
    }
}
