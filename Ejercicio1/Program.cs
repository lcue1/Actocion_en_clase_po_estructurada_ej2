using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{

    internal class Program
    {
        private static int sumaTotal = 0;

        private static int vidasPC = 3;
        private static int vidasJugador = 3;

        static void Main(string[] args)
        {
            //Ejercicio 1
            ejercicio1();

            //Ejercicio 2
           ejercicio2();

            //Ejercicio 3
            ejercicio3();

        }


        static void ejercicio3()
        {
            /*
             * Menu opciones jugador
             * recuperar opcion jugador
             * generar aleatorio 1-4 clase Eandom metodo next()
             * 
             */
            inicializarJuego();
            do
            {
                int opcionUsuario = menu();
                int aleatorio = new Random().Next(1,4);
                logicaJuego(aleatorio, opcionUsuario);
                if (hayGanador() == true)
                {
                    if (jugarNuevamente() == "s")
                    {
                        inicializarJuego();
                    }
                    else
                    {
                        break;
                    }
                }


            } while (true);
        }
        public static void inicializarJuego()
        {
            Console.WriteLine("Bienvenido al juego piedra papel o tijera\n" +
                "**********************************************************\n");
            vidasJugador = 3;
            vidasPC = 3;
        }
        public static string jugarNuevamente()
        {
            if (vidasJugador == 0 || vidasPC == 0)
            {
                Console.WriteLine("Dese juagar nuevamente? s/n");
                return Console.ReadLine().ToLower();
            }
            return "n";
        }
        private static Boolean hayGanador()
        {
            if(vidasJugador == 0)
            {
                Console.WriteLine("Gana PC\n");
                return true;
            }else if (vidasPC == 0)
            {
                Console.WriteLine("Gana jugador\n");
                return true;
            }
            return false;
        }
        private static void logicaJuego(int pc, int jugador)
        {

            /* gana pc piedra jugador tijera 1 3
             * gana pc papel jugador piedra 2 1
             * gana pc  tijera jugador papel 3 2
             */
            string[] opcionesSeleccionadas = { "Piedra", "Papel", "Tijera" };
            Console.WriteLine($"Jugador:{opcionesSeleccionadas[jugador-1]}\n" +
                $"PC: {opcionesSeleccionadas[pc-1]}");
            bool ganaPC = (pc == 1 && jugador == 3) || (pc == 2 && jugador == 1) || (pc == 3 && jugador == 2);
            bool ganaJugador = (jugador == 1 && pc == 3) || (jugador == 2 && pc == 1) || (jugador == 3 && pc == 2);
            if (ganaPC)
            {
                vidasJugador--;
            }
            else if (ganaJugador)
            {
                vidasPC--;
            }
            Console.WriteLine($"<<<<Vidas >>>> PC : {vidasPC }, Tu: {vidasJugador}");

        }

        private static int menu() {
            Console.WriteLine("\"---------------------------\n" +
                "Seleccione\n" +
                "1 Piedra\n" +
                "2 Papel\n" +
                "3 Tijera\n" +
                "---------------------------");
            return int.Parse(Console.ReadLine());
             }    
        //Ejercicio 2 sumar numero variable global
        static void ejercicio2()
        {

            do
            {
                Console.WriteLine("Ingrese un numero ");
                int numeroIngresado = int.Parse(Console.ReadLine());
                agregarNumero(numeroIngresado);
                Console.WriteLine("Desea agregar otro numero a sumar");
                string continuar = Console.ReadLine().ToLower();
                if (continuar != "s")
                {
                    break;
                }
            } while (true);
            Console.WriteLine($"La suma es :{sumaTotal}");


        }


        static void agregarNumero(int numero)
        {
            sumaTotal += numero;
        }
        static double calcularAreaCirculo(float radio)
        {
           return Math.PI*Math.Pow(radio, 2);
        }
        //Ejercicio 1  Calcula area de un circulo
        public static  void ejercicio1()
        {
            Console.WriteLine("Calcula el area de un circulo");
            Console.WriteLine("Ingrese el radio ");
            float radio = float.Parse(Console.ReadLine());

            double area = calcularAreaCirculo(radio);
            Console.WriteLine($"El area :{area}");
        }
    }
}
