using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JuegoPorTurnos
{
    class Juego
    {
        private Jugador jugador;
        private List<Enemigo> enemigos;
        private bool juegoTerminado;

        public Juego()
        {
            enemigos = new List<Enemigo>();
            juegoTerminado = false;
        }

        public void Configurar()
        {
            Console.WriteLine("===== JUEGO POR TURNOS =====");

            Console.Write("Ingresa el nombre de tu personaje: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingresa los puntos de vida (max 100): ");
            int vidaJugador = ObtenerNumeroValido(1, 100);

            Console.Write("Ingresa los puntos de daño (max 100): ");
            int dañoJugador = ObtenerNumeroValido(1, 100);

            jugador = new Jugador(nombre, vidaJugador, dañoJugador);
            Console.WriteLine($"{nombre} ha sido creado con {vidaJugador} puntos de vida y {dañoJugador} de daño");

            Console.WriteLine("\nGenerando enemigos...");

            enemigos.Add(new EnemigoMelee(50, 15));
            enemigos.Add(new EnemigoMelee(60, 10));

            enemigos.Add(new EnemigoRango(40, 20, 3));

            Console.WriteLine($"Se han generado {enemigos.Count} enemigos.");
            Console.WriteLine("\nPresiona cualquier tecla para comenzar...");
            Console.ReadKey();
            Console.Clear();
        }

        private int ObtenerNumeroValido(int min, int max)
        {
            int valor;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out valor) && valor >= min && valor <= max)
                    return valor;

                Console.Write($"Ingresa un número entre {min} y {max}: ");
            }
        }

        public void Ejecutar()
        {
            Configurar();

            while (!juegoTerminado)
            {
                MostrarEstado();
                RealizarTurnoJugador();

                if (juegoTerminado) break;

                RealizarTurnoEnemigos();

                if (juegoTerminado) break;

                Console.WriteLine("\nPresiona cualquier tecla para el siguiente turno...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void MostrarEstado()
        {
            Console.WriteLine("===== ESTADO ACTUAL =====");
            Console.WriteLine($"Jugador: {jugador.Nombre} - Esta vivo: {jugador.EstaVivo()}");

            for (int i = 0; i < enemigos.Count; i++)
            {
                string tipo = enemigos[i] is EnemigoMelee ? "Melee" : "Rango";
                Console.WriteLine($"Enemigo {i + 1} ({tipo}) - Esta vivo: {enemigos[i].EstaVivo()}");
            }
            Console.WriteLine("========================");
        }

        private void RealizarTurnoJugador()
        {
            Console.WriteLine("\n=== TURNO DEL JUGADOR ===");

            List<Enemigo> enemigosVivos = enemigos.FindAll(e => e.EstaVivo());

            if (enemigosVivos.Count == 0)
            {
                Console.WriteLine("Victoria, has derrotado a todos los enemigos");
                juegoTerminado = true;
                return;
            }

            Console.WriteLine("Elige un enemigo para atacar:");

            for (int i = 0; i < enemigos.Count; i++)
            {
                if (enemigos[i].EstaVivo())
                {
                    string tipo = enemigos[i] is EnemigoMelee ? "Melee" : "Rango";
                    Console.WriteLine($"{i + 1}. Enemigo {tipo}");
                }
            }

            int opcion;
            while (true)
            {
                Console.Write("Elige (número): ");
                if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 1 && opcion <= enemigos.Count)
                {
                    if (enemigos[opcion - 1].EstaVivo())
                        break;
                    else
                        Console.WriteLine("Ese enemigo ya esta muerto, elige otro");
                }
                else
                {
                    Console.WriteLine("Opcion invalida");
                }
            }

            Console.WriteLine($"\n{jugador.Nombre} ataca al enemigo {opcion}");
            enemigos[opcion - 1].RecibirDaño(jugador.ObtenerDaño());

            if (!enemigos[opcion - 1].EstaVivo())
            {
                Console.WriteLine("Has derrotado al enemigo");
            }
        }

        private void RealizarTurnoEnemigos()
        {
            Console.WriteLine("\n=== TURNO DE LOS ENEMIGOS ===");

            foreach (Enemigo enemigo in enemigos)
            {
                if (enemigo.EstaVivo())
                {
                    enemigo.AtacarJugador(jugador);

                    Thread.Sleep(1000);

                    if (!jugador.EstaVivo())
                    {
                        Console.WriteLine("\nDerrota, tu personaje ha sido derrotado");
                        juegoTerminado = true;
                        return;
                    }
                }
            }
        }
    }
}
