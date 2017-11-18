using System;
using System.Threading;
using System.IO;

namespace RpgSaltConsola
{
    public class Introduccion
    {
        private static Random generador = new Random(DateTime.Now.Millisecond);


        struct Estrella
        {
            public int x;
            public int y;
            public int incX;
            public int incY;
        }

        private static CancionBeep intro;
        private static Personaje p;
        private Thread hiloMusica;
        private static string nombre, sexo;
        private static int fuerza, inteligencia, destreza, constitucion, atBas
            , defensa, vida, arquetipo;

        public Introduccion()
        {
            intro = new CancionBeep(@"..\..\cancionBeep\mainFF.txt");
            hiloMusica = new Thread(intro.Reproducir);
        }

        public Personaje Run()
        {
            Console.Clear();
            if (!Juego.NO_INTRO)
            {
                hiloMusica.Start();
                MostrarMensajes();
            }
            EleccionArquetipo();
            DistribucionParametros();
            CalculosFinales();
            
            return new Personaje(nombre, sexo, fuerza, destreza, inteligencia
                , constitucion, vida, atBas, defensa);
        }


        public void MostrarMensajes()
        {
            string[] texto = { "Aquí debería ir la historia del juego...",
                "pero realmente este juego no ha tenido nunca puta historia,",
                "y lo poco que se puso daba vergüenza ajena.",
                "2017 y aun no se puede considerar que se haya acabado la pesadilla ",
                "del juego este de mierda con los beeps que ya ni siquiera suenan ",
                "como sonaban en aquel windows XP.",
                "Pero al menos desde aquel entonces ahora se poner hilos.",
                "Voy a ver si consigo dejar esto un poco como era en su día pero multiplataforma y algo más estable. ",
                "Bienvenido al RPG SALT!",
                "Mario (siempre Botarga)"};

            int refLinea = 0, refLetra = 0;

            

            while (refLinea < texto.Length)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(12 + refLetra, (refLinea* 2) + 2);
                Console.Write(texto[refLinea][refLetra++]);
                if (refLetra == texto[refLinea].Length)
                {
                    refLetra = 0;
                    refLinea++;
                }

                Thread.Sleep(80);
            }

            Console.WriteLine("\nPulsa INTRO para continuar...");
            Console.ReadLine();
            hiloMusica.Abort();
            Console.ResetColor();
            Console.Clear();       
        }

        public void EleccionArquetipo()
        {
            string aux;
            string[] arquetipos = { "Guerrero", "Arquero", "Mago", "Botarga" };

            bool terminado = false;

            Console.WriteLine("Introduce tu nombre: ");
            Console.ReadKey();
            Console.WriteLine("\nMe da igual...");
            Console.ReadLine();
            Console.WriteLine("Sexo: (masculino/femenino)?");
            Console.ReadLine();
            Console.WriteLine("Esto tampoco servía de nada...");
            Console.ReadLine();

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
                    arquetipo = Hardware.LeerEntero(); 
                } while (arquetipo < 1 || arquetipo > arquetipos.Length);

                Console.Clear();
                Console.WriteLine("Seguro que quieres ser {0}?"
                    , arquetipos[arquetipo-1]);
                Console.WriteLine("s/n");
                do
                {
                    aux =Hardware.LeerString().ToLower();
                } while (aux.CompareTo("s") != 0 && aux.CompareTo("n") != 0);

                if(arquetipo == 4)
                {
                    Console.WriteLine("Introduce la contraseña del arquetipo supremo: ");
                    string pass = Console.ReadLine();
                    if(pass.CompareTo("iesmutxamel") != 0)
                    {
                        Console.WriteLine("Constraseña incorrecta.\nPulsa INTRO para continuar...");
                        Console.ReadLine();
                        continue;
                    }
                }
                if (aux.CompareTo("s") == 0)
                {
                    Console.WriteLine("LLegaras a ser un gran {0} pues"
                        , arquetipos[arquetipo-1]);
                    terminado = true;
                }
                else
                {
                    Console.WriteLine("Medita bien tu eleccion...");
                    Console.ReadLine();
                }
            } while (!terminado);

            Console.Clear();

            switch(arquetipo)
            {
                case 1:
                    atBas = 20;
                    defensa = 15;
                    
                    Console.WriteLine("ARQUETIPO GUERRERO\n\n");
                    Console.WriteLine("El guerrero es un soldado que utiliza la espada como arma"+
                           "principal, pero esta  \nentrenado para utilizar todo tipo de"+
                           "armas.\nTiene una gran defensa y utiliza su fuerza para "+
                           "asentar poderosos golpes\n Viene de tierras lejanas donde"+
                           "es un poderoso heroe.");
                    Console.WriteLine("\nSon muy utiles atacando de cuerpo a cuerpo, poseen una"+
                           "agilidad limitada.\n");
                    Console.WriteLine("\nLucha con valentia contra las fuerzas malevolas y veras"+
                           " tu recompensa...\n");
 
                    Console.WriteLine("\nPULSA INTRO PARA CONTINUAR...");
 
                    break;

                case 2:
                    atBas = 15;
                    defensa = 10;

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

                case 3:
                    atBas = 5;
                    defensa = 5;
                    
                    Console.WriteLine("ARQUETIPO MAGO\n\n");
                    Console.WriteLine("El mago en esta version beta no esta desarrollado, como "+
                           "programadores te recomendamos reiniciar el juego y coger"+
                           "otra clase, aunque no es imposible pasarse el juego con "+
                           "esta clase, si que es un poco inutil :D");

                    Console.WriteLine("\nLucha con valentia contra las fuerzas malevolas y veras"+
                           " tu recompensa...\n");
 
                    Console.WriteLine("\nPULSA INTRO PARA CONTINUAR...");
                    break;

                case 4:
                    atBas = 99;
                    defensa = 99;

                    Console.WriteLine("ARQUETIPO BOTARGA\n");
                    Console.WriteLine("\nBienvenido a la clase botarga, como programadores nos "+
                           "llena de orgullo que \nhayais llegado hasta este arquetipo,"+
                           " te queda un ultimo reto... \n\nEn alguna casilla escondida"+
                           " del reino de Salt, esta escondido el boss supremo, "+
                           "\nsolo aparecera en una batalla aleatoria, y solo en esa"+
                           " coordenada, encuentralo \nacaba con el y devuelve la paz"+
                           " a estas tierras, por cierto, para poder luchar\ncontra ese"+
                           " boss, te hara falta haber derrotado a los 3 bosses de las"+
                           " mazmorra \nnuevamente, aunque ya veras que siendo botarga "+
                           " no te costara mucho");

                    break;

                default: break;
            }
            Console.ReadLine();

        }

    
        public void DistribucionParametros ()
        {
            int numPuntos = 10;
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
    
        public void CalculosFinales ()
        {
            atBas += (fuerza - 5);
            defensa += (constitucion - 5);
            vida = constitucion * 10;
        }
    }
}
