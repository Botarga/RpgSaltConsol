using System;
using System.Threading;
using System.IO;

namespace RpgSaltConsola
{
    public class Introduccion
    {
        private static Random generador = new Random(DateTime.Now.Millisecond);

        private static CancionBeep intro;
        private static Personaje p;
        private Thread hiloMusica;
        private string weapon;
        private static int fuerza, inteligencia, destreza, constitucion, atBas
            , defensa, vida, arquetipo;

        public Introduccion()
        {
            intro = new CancionBeep(Hardware.BEEP_PATH + "mainFF.txt");
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
            
            p =  new Personaje("", "", fuerza, destreza, inteligencia
                , constitucion, vida, atBas, defensa);

            p.AddItem("little_potion", 5);
            p.AddItem("strength_potion", 2);
            p.AddItem(weapon, 1);
            return p;
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

            Console.WriteLine(Hardware.NL + "Pulsa INTRO para continuar...");
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
            Console.WriteLine(Hardware.NL + "Me da igual...");
            Console.ReadLine();
            Console.WriteLine("Sexo: (masculino/femenino)?");
            Console.ReadLine();
            Console.WriteLine("Esto tampoco servía de nada...");
            Console.ReadLine();

            do
            {
                Console.Clear();
                Console.SetCursorPosition(25, 0);
                Console.WriteLine("|Interfaz de eleccion de arquetipo|" + Hardware.NL);

                Console.WriteLine("Selecciona tu arquetipo {0}" + Hardware.NL + Hardware.NL);
                for (int i = 0; i < arquetipos.Length; i++)
                    Console.WriteLine("\t\t\t{0}. {1}" + Hardware.NL + Hardware.NL, i + 1
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
                        Console.WriteLine("Constraseña incorrecta." + Hardware.NL + "Pulsa INTRO para continuar...");
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
                    
                    Console.WriteLine("ARQUETIPO GUERRERO" + Hardware.NL + Hardware.NL);
                    Console.WriteLine("El guerrero es un soldado que utiliza la espada como arma"+
                           "principal, pero esta" + Hardware.NL + "entrenado para utilizar todo tipo de"+
                           "armas." +Hardware.NL + "Tiene una gran defensa y utiliza su fuerza para "+
                           "asentar poderosos golpes" + Hardware.NL + " Viene de tierras lejanas donde"+
                           "es un poderoso heroe.");
                    Console.WriteLine(Hardware.NL + "Son muy utiles atacando de cuerpo a cuerpo, poseen una"+
                           "agilidad limitada." +Hardware.NL);
                    Console.WriteLine(Hardware.NL + "Lucha con valentia contra las fuerzas malevolas y veras"+
                           " tu recompensa..." +Hardware.NL);
 
                    Console.WriteLine(Hardware.NL + "PULSA INTRO PARA CONTINUAR...");

                    weapon = "wooden_sword";
                    break;

                case 2:
                    atBas = 15;
                    defensa = 10;

                    Console.WriteLine("ARQUETIPO ARQUERO" +Hardware.NL);
                    Console.WriteLine("El arquero es un soldado que dispara flechas con un arco,"+
                           "una varilla hecha de" +Hardware.NL + "acero, madera u otra materia "+
                           "elastica sujeta por los extremos con una cuerda o  bordon,"+
                           "de modo que forme una curva");
                    Console.WriteLine("Son muy utiles atacando a distancias largas ademas de "+
                           "poseer una gran agilidad." +Hardware.NL + "Los arqueros son provenientes "+
                           "del bosque encantado al sureste de:" +Hardware.NL + "La tierra de Salt");
                    Console.WriteLine("Lucha con valentia contra las fuerzas canis y veras tu "+
                           "recompensa...");
                    Console.WriteLine(Hardware.NL + "PULSA INTRO PARA CONTINUAR...");
                    weapon = "wooden_bow";
                    break;

                case 3:
                    atBas = 5;
                    defensa = 5;
                    
                    Console.WriteLine("ARQUETIPO MAGO" +Hardware.NL + Hardware.NL);
                    Console.WriteLine("El mago en esta version beta no esta desarrollado, como "+
                           "programadores te recomendamos reiniciar el juego y coger"+
                           "otra clase, aunque no es imposible pasarse el juego con "+
                           "esta clase, si que es un poco inutil :D");

                    Console.WriteLine(Hardware.NL + "Lucha con valentia contra las fuerzas malevolas y veras"+
                           " tu recompensa..." +Hardware.NL);
 
                    Console.WriteLine(Hardware.NL + "PULSA INTRO PARA CONTINUAR...");
                    weapon = "wooden_stick";
                    break;

                case 4:
                    atBas = 99;
                    defensa = 99;

                    Console.WriteLine("ARQUETIPO BOTARGA" +Hardware.NL);
                    Console.WriteLine(Hardware.NL + "Bienvenido a la clase botarga, como programadores nos "+
                           "llena de orgullo que " +Hardware.NL + "hayais llegado hasta este arquetipo,"+
                           " te queda un ultimo reto..." + Hardware.NL + Hardware.NL + "En alguna casilla escondida"+
                           " del reino de Salt, esta escondido el boss supremo, "+
                           Hardware.NL + "solo aparecera en una batalla aleatoria, y solo en esa"+
                           " coordenada, encuentralo " +Hardware.NL + "acaba con el y devuelve la paz"+
                           " a estas tierras, por cierto, para poder luchar" +Hardware.NL + "contra ese"+
                           " boss, te hara falta haber derrotado a los 3 bosses de las"+
                           " mazmorra " +Hardware.NL + "nuevamente, aunque ya veras que siendo botarga "+
                           " no te costara mucho");
                    weapon = "tm_costume";
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
            Console.WriteLine("|Interfaz de distribución de parámetros|" + Hardware.NL + Hardware.NL);

            Console.WriteLine("Distribuye tus puntos de desarrollo, para ello "
                + " debes de pulsar el numero " + Hardware.NL + "correspondiente de aumentar o "
                + "disminuir puntuacion...");
            Console.WriteLine("Puntos Restantes: {0:D2}" + Hardware.NL, numPuntos);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Aumentar\tParametro\tDisminuir\tTotal");
            Console.ResetColor();
            Console.WriteLine("   1    \t  Fuerza \t    2    \t {0:D2}", fuerza);
            Console.WriteLine("   3    \t Destreza\t    4    \t {0:D2}", destreza);
            Console.WriteLine("   5    \tInteligencia\t    6    \t {0:D2}", inteligencia);
            Console.WriteLine("   7    \tConstitución\t    8    \t {0:D2}", constitucion);

            Console.WriteLine(Hardware.NL + "Pulsa el numero correspondiente (9 para terminar)...");

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
