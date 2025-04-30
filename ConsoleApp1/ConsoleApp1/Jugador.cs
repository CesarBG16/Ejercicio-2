using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPorTurnos
{
    class Jugador : Personaje
    {
        public string Nombre { get; private set; }

        public Jugador(string nombre, int vida, int daño) : base(vida, daño)
        {
            Nombre = nombre;

            if (vida > 100)
                this.vida = 100;

            if (daño > 100)
                this.daño = 100;
        }

        public override void RecibirDaño(int cantidad)
        {
            base.RecibirDaño(cantidad);
            Console.WriteLine($"{Nombre} tiene ahora {vida} puntos de vida");
        }
    }
}