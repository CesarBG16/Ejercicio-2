using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPorTurnos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Juego juego = new Juego();
            juego.Ejecutar();

            Console.WriteLine("\nFin del juego, presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
